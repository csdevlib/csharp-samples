namespace BackOffice.Models;

public class Employee
{
    public string Id { get; set; }
    public Company Company { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }

    public Employee(string id, Company company, string name)
    {
        Id = id;
        Company = company;
        Name = name;
    }
}
