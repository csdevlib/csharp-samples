using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Employees
{
    public class EmployeeName : MyString
    {
        private EmployeeName(string value) : base(value)
        {
        }

        public static EmployeeName Create(string value)
        {
            return new EmployeeName(value);
        }
    }
}
