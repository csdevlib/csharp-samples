namespace BackOffice.Models;

public class Tag
{
    public string Id { get; set; }
    public Company Company { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
