namespace MusicStore.Catalog.Application.Queries
{
    public record IdeaModel (string Name, string Description, string[] Tags, ResourceModel[] Resources);

    public record ResourceModel (string Name, string Path,bool IsExternal);

    public record IdeaSummaryModel (string Name, string Status, int TotalTags, int Totalresources);
}
