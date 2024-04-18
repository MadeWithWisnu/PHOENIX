using PhoenixBussiness.Interfaces;
using PhoenixDataAccess.Models;

namespace PhoenixBussiness.Repositories;

public class AdministratorRepostirory : IAdministratorRepository
{
    private readonly PhoenixContext _dbContext;
    public AdministratorRepostirory(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CountAll()
    {
        return _dbContext.Administrators.Count();
    }

    public List<Administrator> GetAll(int pageNumber, int pageSize)
    {
        return _dbContext.Administrators
        .Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
    }

    public Administrator GetByUsername(string username)
    {
        return _dbContext.Administrators.Find(username)?? throw new NullReferenceException("Username or Password or Role is incorrect");
    }

    public void Insert(Administrator administrator)
    {
        _dbContext.Administrators.Add(administrator);
        _dbContext.SaveChanges();
    }

    public void Update(Administrator administrator)
    {
        _dbContext.Administrators.Update(administrator);
        _dbContext.SaveChanges();
    }
}
