using BeyondNet.Patterns.NetDdd.Entities;
using BeyondNet.Patterns.NetDdd.Entities.Contracts;
using BeyondNet.Patterns.NetDdd.Exceptions;
using BeyondNet.Patterns.NetDdd.ValueObjects;
using Catalog.Domain.Aggregates.AlbumAggregate.ValueObjects;
using Catalog.Domain.Events;
using Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class Song : Entity, IAggregateRoot
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Duration { get; private set; }
        public string DurationFormatted { get; private set; }
        public bool Draft { get; private set; }
        public Author Author { get; private set; }

        private List<string> _tags;
        public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();

        private List<File> _files;
        public IReadOnlyCollection<File> Files => _files.AsReadOnly();
        public Audit Audit { get; private set; }
        public ESongStatus Status { get; set; }

        private Song(string name, string description, double duration, string durationFormatted, List<string> tags, Author author)
        {
            Name = name;
            Description = description;
            Duration = duration;
            DurationFormatted = durationFormatted;
            _tags = tags;
            _files = new List<File>();
            Audit = Audit.Create(DateTimeOffset.Now, author.UserName);
            Status = ESongStatus.Pending;

            AddSongCreatedDomainEvent(Id, name, durationFormatted, Draft, author.UserName);
        }

        private void AddSongCreatedDomainEvent(string id, string name, string durationFormatted, bool isDraft, string author)
        {
            var songCreated = new SongCreatedDomainEvent(id, name, durationFormatted, isDraft, author);

            AddDomainEvent(songCreated);
        }

        public static Song Create(string name, string description, double duration, string durationFormatted, List<string> tags, Author author)
        {
            return new Song(name, description, duration, durationFormatted, tags, author);
        }

        public void MarkAsDraft()
        {
            if (Status != ESongStatus.Pending)
                throw new DomainException($"Song cannot be marked as draft. Status: {Status.Name}");

            Draft = true;
        }

        public void Promote()
        {
            if (Status != ESongStatus.Pending)
                StatusChangeException(ESongStatus.Promoted);
            if (Duration < 3)
                throw new DomainException("A song cannot be promoted if the duration is less than 4 minutes");

            Status = ESongStatus.Promoted;

            AddDomainEvent(new SongPromotedDomainEvent(Id));
        }

        public void Release()
        {
            if (Status != ESongStatus.Promoted)
                StatusChangeException(ESongStatus.Released);

            Status = ESongStatus.Released;

            AddDomainEvent(new SongReleasedDomainEvent(Id));
        }

        public void Cancel() {
            if (Status == ESongStatus.Promoted || Status == ESongStatus.Released || Status == ESongStatus.Canceled)
                StatusChangeException(ESongStatus.Canceled);

            Status = ESongStatus.Canceled;

            AddDomainEvent(new SongCanceledDomainEvent(Id));
        }

        public void AddTag(string name)
        {
            if (ExistTag(name)) throw new DomainException($"Tag {name} exists.");

            _tags.Add(name);
        }

        public void RemoveTag(string name)
        {
            if (!ExistTag(name)) throw new DomainException($"Tag {name} does not exists.");

            _tags.Remove(name);
        }

        private bool ExistTag(string name)
        {
            return _tags.Exists(p => p.ToLower() == name.ToLower());
        }

        public void AddFile(string name, string path)
        {
            if (ExistsFile(name))
                throw new DomainException($"File {name} exists.");

            _files.Add(File.Upload(name, path));
        }

        public void RemoveFile(string name)
        {
            if (!ExistsFile(name))
                throw new DomainException($"File {name} does not exists.");
            
            var file = _files.Find(p => p.Name.ToLower() == name.ToLower());           
            _files.Remove(file);
        }

        private bool ExistsFile(string name)
        {
            return _files.Exists(p => p.Name.ToLower() == name.ToLower());
        }

        private void StatusChangeException(ESongStatus songStatusToChange)
        {
            throw new SongDomainException($"Is not possible to change the order status from {Status.Name} to {songStatusToChange.Name}.");
        }
    }
}
