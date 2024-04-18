using PhoenixDataAccess.Models;

namespace PhoenixBussiness.Interfaces;

public interface IGuestRepository
{
    public Guest GetByUsername(string username);
    public void Insert(Guest guest);
}
