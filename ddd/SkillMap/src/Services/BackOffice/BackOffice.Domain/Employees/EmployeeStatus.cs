using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Employees
{
    public class EmployeeStatus : Enumeration
    {

        public EmployeeStatus(int id, string name) : base(id, name)
        {
        }

        public static EmployeeStatus Active = new(1, nameof(Active));
        public static EmployeeStatus Inactive = new(2, nameof(Inactive));
    }
}
