namespace BackOffice.GraphApi.Graphql.Mutations
{
    using BackOffice.Models;
    using HotChocolate.AspNetCore.Authorization;
    using SkillMap.SharedKernel.Domain.Interfaces;

    public class CompanyMutation
    {
        private readonly IWriteRepository<Company, string> repository;

        public CompanyMutation(IWriteRepository<Company, string> repository)
        {
            this.repository = repository;
        }

        //[Authorize(Policy = "Admin")]
        public async Task<CompanyPayload> AddCompany(CompanyInput input)
        {
            var company = new Company(Guid.NewGuid().ToString(), input.Name); ;
            
            //await repository.Save(company);
            
            return new CompanyPayload(company);
        }
    }

    public record CompanyPayload(Company? Record, string? Error = null) : Payload(Error);
    public record CompanyInput(string Name, string Status);
    public record Payload(string? Error);
}
