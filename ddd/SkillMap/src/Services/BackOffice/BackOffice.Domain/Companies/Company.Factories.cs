using BackOffice.Domain.Companies.Events;
using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Companies
{
    public partial class Company
    {
        public static Company Create(AggregateId<Company, string> id, CompanyName name)
        {
            return new Company(id, name);
        }

        public void AddTag(CompanyTag tag)
        {
            if (_tags.Any(t => t.Name.ToLower() == tag.Name.ToLower()))
                throw new CompanyDomainException($"Tag {tag.Name} exists.");

            _tags.Add(tag);
        }

        public void RemoveTag(CompanyTag tag)
        {
            _tags.Remove(tag);
        }

        public void AddEmployee(CompanyEmployee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            employee.ValidateRules(employee);

            if (!employee.IsValid)
                throw new CompanyDomainException($"Employee {employee.Name} is not valid. Errors: {employee.BrokenRules}.");

            var nameToAdd = employee.Name.ToLower();

            if (_employees.Any(e => e.Name.ToLower() == nameToAdd))
                throw new CompanyDomainException($"Employee {employee.Name} exists.");

            _employees.Add(employee);

            AddDomainEvent(new EmployeeAddedDomainEvent(employee.EmployeeId, employee.Name));
        }

        public void RemoveEmployee(CompanyEmployee employee)
        {
            var isRecruiter = _recruiters.Any(r => r.EmployeeId == employee.EmployeeId);
            
            var isApprover = _approvers.Any(r => r.EmployeeId == employee.EmployeeId);

            if (isRecruiter || isApprover)
                throw new CompanyDomainException($"Employee {employee.Name} cannot be removed due to is an recruiter or approver.");

            _employees.Remove(employee);
        }

        public void AddRecruiter(CompanyEmployee recruiter)
        {
            if (recruiter is null) throw new ArgumentNullException(nameof(recruiter));

            var recruiterToAdd = recruiter.Name.ToLower();

            if (_recruiters.Any(r => r.Name.ToLower() == recruiterToAdd))
                throw new CompanyDomainException($"Recruiter {recruiter.Name} exists.");

            _recruiters.Add(recruiter);

            AddDomainEvent(new RecruiterAddedDomainEvent(recruiter.EmployeeId));
        }

        public void RemoveRecruiter(CompanyEmployee recruiter)
        {
            _recruiters.Remove(recruiter);
        }

        public void AddApprover(CompanyEmployee approver)
        {
            if (approver is null) throw new ArgumentNullException(nameof(approver));

            var approverToAdd = approver.Name.ToLower();

            if (_approvers.Any(r => r.Name.ToLower() == approverToAdd))
                throw new CompanyDomainException($"Approver {approver.Name} exists.");

            _approvers.Add(approver);

            AddDomainEvent(new ApproverAddedDomainEvent(approver.EmployeeId));
        }

        public void RemoveApprover(CompanyEmployee approver)
        {
            _approvers.Remove(approver);
        }

        public void AddTalent(CompanyTalent talent)
        {
            if (talent is null) throw new ArgumentNullException(nameof(talent));

            if (!talent.IsValid) 
                throw new CompanyDomainException($"Talent {talent.Name} is not valid. Errors: {talent.BrokenRules}.");

            var nameToAdd = talent.Name.ToLower();

            if (_talents.Any(e => e.Name.ToLower() == nameToAdd))
                throw new CompanyDomainException($"Talent {talent.Name} exists.");

            _talents.Add(talent);

            AddDomainEvent(new TalentAddedDomainEvent(talent.TalentId, talent.Name));
        }

        public void RemoveTalent(CompanyTalent talent)
        {
            _talents.Remove(talent);
        }
    }
}
