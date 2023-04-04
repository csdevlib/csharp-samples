namespace BackOffice.Models;

public class Company {

    public Company(string id, string name)
    {
        Id = id;
        Name = name;
        Status = "Active";
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Approver> Approvers { get; set; }
    public IEnumerable<Recruiter> Recruiters { get; set; }
    public IEnumerable<Talent> Talents { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
    public string Status { get; set; }
}
