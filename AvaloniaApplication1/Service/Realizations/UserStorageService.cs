using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service.Realizations;

public class UserStorageService : IStorageService<UserDTO>
{
    public void Save(IList<UserDTO> usersList)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            foreach (var el in usersList) db.Users.Update(el);

            db.SaveChanges();
        }
    }

    public IList<UserDTO> Load()
    {
        List<UserDTO> usersList;
        using (ApplicationContext db = new ApplicationContext())
        {
            usersList = new List<UserDTO>(db.Users.ToList());
        }
        return usersList;
    }
}