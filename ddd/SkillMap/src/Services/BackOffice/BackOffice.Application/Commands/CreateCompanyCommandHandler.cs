using BackOffice.Domain.Companies;
using SkillMap.SharedKernel.Domain.ValueObjects;
using MediatR;
using SkillMap.EventBus.Commands;

namespace BackOffice.Application.Commands
{
    public class CreateCompanyCommandHandler : AbstractCommandHandlerAsync<CreateCompanyCommand>
    {
        private readonly IWriteCompanyRepository writeCompanyRepository;

        public CreateCompanyCommandHandler(IMediator mediator,
                                           IWriteCompanyRepository writeCompanyRepository) : base(mediator)
        {
            this.writeCompanyRepository = writeCompanyRepository;
        }

        protected async override Task Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = Company.Create(AggregateId<Company, string>.From(Guid.NewGuid().ToString()),
                                         CompanyName.Create(command.company.name));

            if (!company.IsValid) throw new ApplicationException($"Company is not valid. Errors: {company.BrokenRules}");

            //await writeCompanyRepository.Insert(Map(command, company));

            if (!company.DomainEvents.Any()) return;
            
            await Publish(company.PullDomainEvents());         
        }
     
        //TODO: Refactor this
        //private Company Map(CreateCompanyCommand command, Company company)
        //{
        //    command.company.Employees.ToList().ForEach(e =>
        //    {
        //        var employeeId = EntityId<string>.From(Guid.NewGuid().ToString());

        //        var employee = CompanyEmployee.Create(employeeId, EmployeeName.Create(e.name), EmployeeCompany.Create(company.Id.Value, company.Name.Value));

        //        if (!employee.IsValid) throw new ApplicationException($"Employee is not valid. Errors: {brokenRulesFormatter.Format(employee.BrokenRules)}");

        //        company.AddEmployee(employee);

        //        MapFromEmployee(command, company, employeeId, employee);
                
        //        MapTalents(command, company);

        //        MapTags(command, company);
        //    });

        //    return company;
        //}

        //private void MapTalents(CreateCompanyCommand command, Company company)
        //{
        //    command.company.talents.ToList().ForEach(t =>
        //    {
        //        var id = EntityId<string>.From(Guid.NewGuid().ToString());

        //        var talent = Talent.Create(id, TalentName.Create(t.name), TalentType.Employee, TalentCompany.Create(company.Id.Value, company.Name.Value));

        //        if (!talent.IsValid) throw new ApplicationException($"Talent is not valid. Errors: {brokenRulesFormatter.Format(talent.BrokenRules)}");

        //        company.AddTalent(talent);
        //    });
        //}

        //private void MapFromEmployee(CreateCompanyCommand command, Company company, EntityId<string> employeeId, CompanyEmployee employee)
        //{
        //    command.company.approvers.Where(a => a.employeeId == employeeId.Value).ToList().ForEach(a =>
        //    {
        //        var approver = Approver.Create(EntityId<string>.From(Guid.NewGuid().ToString()), ApproverEmployee.Create(employee.Id.Value, employee.Name.Value));

        //        if (!approver.IsValid) throw new ApplicationException($"Approver is not valid. Errors: {brokenRulesFormatter.Format(approver.BrokenRules)}");

        //        company.AddApprover(approver);
        //    });

        //    command.company.recruiters.Where(r => r.employeeId == employeeId.Value).ToList().ForEach(a =>
        //    {
        //        var recruiter = Recruiter.Create(EntityId<string>.From(Guid.NewGuid().ToString()), RecruiterEmployee.Create(employee.Id.Value, employee.Name.Value));

        //        if (!recruiter.IsValid) throw new ApplicationException($"Recruiter is not valid. Errors: {brokenRulesFormatter.Format(recruiter.BrokenRules)}");

        //        company.AddRecruiter(recruiter);
        //    });
        //}

        //private void MapTags(CreateCompanyCommand command, Company company)
        //{
        //    command.company.Tags.ToList().ForEach(t =>
        //    {
        //        var tag = Tag.Create(t.name, t.description);

        //        if (!tag.IsValid) throw new ApplicationException($"Tag is not valid. Errors: {brokenRulesFormatter.Format(tag.BrokenRules)}");

        //        company.AddTag(tag);

        //    });
        //}
    }
}
