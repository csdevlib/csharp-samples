namespace MusicStore.Catalog.Application.Queries
{
    public record GetIdeaByIdQuery(string id) : IRequest<IdeaModel>;
}
