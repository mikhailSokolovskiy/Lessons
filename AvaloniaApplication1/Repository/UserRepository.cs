using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Repository;

namespace AvaloniaApplication1.Repository;

public class UserRepository : IRepository<UserDTO>
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public UserDTO GetById(int id)
    {
        return _context.Users.First(x => x.Id == id);
        //TODO: Think about dispose
    }

    public IList<UserDTO> GetAll()
    {
        return _context.Users.ToList();
    }

    public UserDTO Add(UserDTO entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
        return null;
    }

    public void Update(UserDTO entity)
    {
        _context.Users.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(UserDTO entity)
    {
        _context.Users.Remove(entity);
        _context.SaveChanges();
    }
}