using BackOffice.Models;
using SkillMap.SharedKernel.Domain.Interfaces;

namespace BackOffice.GraphApi.GraphQL.Resolvers
{
    public class CompanyQuery
    {
        private readonly IReadRepository<Company, string> companyRepository;

        public CompanyQuery(IReadRepository<Company, string> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public List<Company> GetCompanies() => companyRepository.Find().Result.ToList();

        public Company GetCompanyById(string id) => companyRepository.FindById(id).Result;

        public bool Exists(string name) => companyRepository.Exists(name).Result;
    }

}
