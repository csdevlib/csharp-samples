namespace MusicStore.Catalog.Domain.Ideas
{
    public class Idea : AggregateRoot
    {
        public AggregateId<Idea, string> Id { get; init; }
        public IdeaName Name { get; init; }
        public IdeaDescription Description { get; init; }
        public Owner Owner { get; init; }
        public IdeaDraft IsDraft { get; init; }
        public IdeaStatus Status { get; private set; }

        private List<Tag> _tags;
        public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();

        private List<IdeaResource> _resources;
        public IReadOnlyList<IdeaResource> Resources => _resources.AsReadOnly();

        private Idea(AggregateId<Idea, string> id, IdeaName name, IdeaDescription description, Owner owner) 
        {
            Id = id;
            Name = name;
            Description = description;
            IsDraft = IdeaDraft.Default;
            Status = IdeaStatus.Created;
            Owner = owner;

            _tags = new List<Tag>();
            _resources = new List<IdeaResource>();

            AddIdeaCreatedDomainEvent(Id.Value, Name.Value);
        }

        public static Idea Create(AggregateId<Idea, string> id, IdeaName name, IdeaDescription description, Owner owner)
        {
            return new Idea(id, name, description, owner);
        }

        public void Draft()
        {
            Status = IdeaStatus.Draft;
        }

        public void UnDraft()
        {
            Status = IdeaStatus.Created;
        }

        public void Close()
        {
            Status = IdeaStatus.Closed;
        }

        public void Cancel()
        {
            Status = IdeaStatus.Canceled;
        }

        public void Promote()
        {
            Status = IdeaStatus.Promoted;

            AddIdeaPromotedDomainEvent(Id.Value);
        }

        public void AddResource(IdeaResourceName name, IdeaResourcePath path, IdeaResourceIsExternal isExternal)
        {
            var resourceId = EntityId<string>.From(Guid.NewGuid().ToString());

            var resource = IdeaResource.Create(resourceId, name, path, isExternal);

            _resources.Add(resource);

            if (isExternal.Value) 
                AddIdeaResourceCreatedDomainEvent(resourceId.Value, name.Value, path.Value, isExternal.Value);
        }

        public void RemoveResource(IdeaResource resource)
        {
            _resources.Remove(resource);
        }

        public void ShareResource(IdeaResource resource)
        {
            resource.Share();

            AddIdeaResourceSharedDomainEvent(resource.Id.Value);
        }

        public void AddTag(Tag tag)
        {
            _tags.Add(tag);

            AddIdeaTagCreatedDomainEvent(tag.Value);
        }

        public void Removetag(Tag tag)
        {
            _tags.Remove(tag);
        }

        private void AddIdeaCreatedDomainEvent(string id, string name)
        {
            var createdEvent = new IdeaCreatedDomainEvent(id, name);

            AddDomainEvent(createdEvent);
        }

        private void AddIdeaPromotedDomainEvent(string id)
        {
            var createdEvent = new IdeaPromotedDomainEvent(id);

            AddDomainEvent(createdEvent);
        }

        private void AddIdeaResourceCreatedDomainEvent(string id, string name, string path, bool isExternal)
        {
            var createdEvent = new IdeaResourceCreatedDomainEvent(id, name, path, isExternal);

            AddDomainEvent(createdEvent);
        }

        private void AddIdeaResourceSharedDomainEvent(string id)
        {
            var createdEvent = new IdeaResourceSharedDomainEvent(id);

            AddDomainEvent(createdEvent);
        }

        private void AddIdeaTagCreatedDomainEvent(string name)
        {
            var createdEvent = new IdeaTagCreatedDomainEvent(name);

            AddDomainEvent(createdEvent);
        }

    }
}
