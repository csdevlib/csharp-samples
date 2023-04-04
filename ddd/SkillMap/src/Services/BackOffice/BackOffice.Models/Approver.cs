namespace BackOffice.Models;

public class Approver {
    public string Id { get; set; }
    public Employee Employee { get; set; }
    public string Status { get; set; }
}
