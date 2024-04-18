using PhoenixBussiness.Interfaces;
using PhoenixDataAccess.Models;

namespace PhoenixBussiness.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly PhoenixContext _dbContext;
    public GuestRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guest GetByUsername(string username)
    {
        return _dbContext.Guests.Find(username)?? throw new NullReferenceException("Username or Password or Role is incorrect");
    }

    public void Insert(Guest guest)
    {
        _dbContext.Guests.Add(guest);
        _dbContext.SaveChanges();
    }
}
