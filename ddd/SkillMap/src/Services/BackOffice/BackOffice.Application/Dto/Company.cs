
namespace BackOffice.Application.Dto
{
    public record CreateCompanyDto(string id,
                          string name,
                          CreateAddressDto address,
                          IEnumerable<CreateEmployeeDto> Employees,
                          IEnumerable<CreateApproverDto> approvers,
                          IEnumerable<CreateRecruiterDto> recruiters,
                          IEnumerable<CreateTalentDto> talents,
                          IEnumerable<CreateTag> Tags,
                          string status);
    public record CreateAddressDto(string street, string city, string state, string country, string zipcode);
    public record CreateEmployeeDto(string name);
    public record CreateApproverDto(string name, string employeeId);
    public record CreateRecruiterDto(string name, string employeeId);
    public record CreateTalentDto(string name, string type);
    public record CreateTag(string name, string description = "");
    public record CompanySummaryDto (string id, string name, int employees, int approbers, int recruiters, int talents, string status);
    
    public class CompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
