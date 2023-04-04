namespace BackOffice.Application.Dto
{
    public record TagDto (string Id, string Name, string Description);
    public record CreateTagDto(string Name, string Description);
}
