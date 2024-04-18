using PhoenixDataAccess.Models;

namespace PhoenixBussiness.Interfaces;

public interface IAdministratorRepository
{
    public Administrator GetByUsername(string username);
    public List<Administrator> GetAll(int pageNumber, int pageSize);
    public int CountAll();
    public void Insert(Administrator administrator);
    public void Update(Administrator administrator);
}
