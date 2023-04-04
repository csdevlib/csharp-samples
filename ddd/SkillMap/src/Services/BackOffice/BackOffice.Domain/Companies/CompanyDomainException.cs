using SkillMap.SharedKernel.Exceptions;

namespace BackOffice.Domain.Companies
{
    public class CompanyDomainException : DomainException
    {
        public CompanyDomainException(string description) : base(description)
        {
        }
    }
}
