namespace BackOffice.Infrastructure.EF.Repositories;

public class ReadCompanyRepository : IReadRepository<Domain.Companies.Company, string>
{
    public Task<bool> Exists(string value)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Companies.Company>> Find()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Companies.Company> FindById(string id)
    {
        throw new NotImplementedException();
    }
}
