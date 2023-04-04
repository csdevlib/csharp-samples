namespace BackOffice.Infrastructure.EF.Repositories;

public class WriteCompanyRepository : IWriteCompanyRepository
{
    private readonly BackOfficeContext context;

    public WriteCompanyRepository(BackOfficeContext context)
    {
        this.context = context;
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Domain.Companies.Company item)
    {
        throw new NotImplementedException();
    }
}
