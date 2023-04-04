using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Employees
{
    public class EmployeeType : Enumeration
    {
        public EmployeeType(int id, string name) : base(id, name)
        {
        }

        public static EmployeeStatus Approver = new(1, nameof(Approver));
        public static EmployeeStatus Recruiter = new(2, nameof(Recruiter));
    }
}
