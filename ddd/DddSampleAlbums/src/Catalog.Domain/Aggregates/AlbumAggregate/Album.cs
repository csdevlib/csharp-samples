using BeyondNet.Patterns.NetDdd.Entities;
using BeyondNet.Patterns.NetDdd.Entities.Contracts;
using BeyondNet.Patterns.NetDdd.Exceptions;
using BeyondNet.Patterns.NetDdd.ValueObjects;
using Catalog.Domain.Aggregates.AlbumAggregate.ValueObjects;
using Catalog.Domain.Events;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Services;
using System;
using System.Collections.Generic;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class Album : Entity, IAggregateRoot
    {
        private readonly IDurationFormatter _durationFormatter;

        public string Id { get; private set; }
        
        private int _albumTypeId;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Author Author { get; private set; }

        private readonly List<string> _tags;
        public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();

        private readonly List<Song> _songs;

        public IReadOnlyCollection<Song> Songs => _songs.AsReadOnly();
        public Audit Audit { get; private set; }
        public EAlbumStatus Status { get; set; }

        private Album(IDurationFormatter durationFormatter)
        {
            _durationFormatter = durationFormatter;
        }

        private Album(int albumTypeId, string name, string description, Author author, List<string> tags)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Author = author;
            _albumTypeId = albumTypeId;
            _tags = tags;
            _songs = new List<Song>();
            Audit = Audit.Create(DateTimeOffset.Now, author.UserName);
            Status = EAlbumStatus.Pending;

            AddAlbumCreatedDomainEvent(_albumTypeId, Id, Name, Description, Author, _tags);
        }

        public void SetAlbumTypeId(int id)
        {
            _albumTypeId     = id;
        }

        private void AddAlbumCreatedDomainEvent(int albumTypeId, string id, string name, string description, Author author, List<string> tags)
        {
            var createdEvent = new AlbumCreatedDomainEvent(albumTypeId, id, name, description, author.UserName, tags.ToArray());

            AddDomainEvent(createdEvent);
        }

        public static Album Create(int albumTypeId, string name, string description, Author author, List<string> tags)
        {
            return new Album(albumTypeId, name, description, author, tags);
        }

        public void SendToLab()
        {
            if (Status != EAlbumStatus.Pending)
                StatusChangeException(EAlbumStatus.InLab);

            Status = EAlbumStatus.InLab;

            AddDomainEvent(new AlbumSentToLabDomainEvent(Id));
        }

        public void SendToSales()
        {
            if (Status != EAlbumStatus.InLab)
                StatusChangeException(EAlbumStatus.InSales);

            Status = EAlbumStatus.InLab;

            AddDomainEvent(new AlbumSentToSalesDomainEvent(Id));
        }

        public void Cancel()
        {
            if (Status != EAlbumStatus.Pending)
                StatusChangeException(EAlbumStatus.Canceled);

            Status = EAlbumStatus.Canceled;

            AddDomainEvent(new AlbumCanceledDomainEvent(Id));
        }

        public void Close()
        {
            if (Status != EAlbumStatus.InSales)
                StatusChangeException(EAlbumStatus.Closed);

            Status = EAlbumStatus.Closed;

            AddDomainEvent(new AlbumClosedDomainEvent(Id));
        }

        public void AddSong(string name, string description, double duration, List<string> tags, Author author)
        {
            if (ExistsSong(name))
                throw new DomainException($"Song named {name} exists.");

            _songs.Add(Song.Create(name, description, duration, _durationFormatter.Format(duration), tags, author));
        }

        public void RemoveSong(string name)
        {
            if (!ExistsSong(name))
                throw new DomainException($"Song named {name} does not exists.");

            var song = _songs.Find(p => p.Name.ToLower() == name.ToLower());

            _songs.Remove(song);
        }

        private bool ExistsSong(string name)
        {
            return _songs.Exists(p => p.Name.ToLower() == name.ToLower());
        }

        private void StatusChangeException(EAlbumStatus albumStatusToChange)
        {
            throw new AlbumDomainException($"Is not possible to change the order status from {Status.Name} to {albumStatusToChange.Name}.");
        }
    }
}
