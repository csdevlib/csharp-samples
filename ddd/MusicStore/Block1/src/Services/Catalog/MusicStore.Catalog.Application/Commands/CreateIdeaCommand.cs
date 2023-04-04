namespace MusicStore.Catalog.Application.Commands
{
    public record CreateIdeaCommand(string Name, string Description, List<string> Tags, List<Resource> Resources) : IRequest<bool>;
    public record Resource(string Name, string Path, bool IsExternal, bool IsShared);
}
