namespace MusicStore.Catalog.Application.Queries
{
    public record GetIdeaListQuery() : IRequest<List<IdeaModel>>;
}
