using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaApplication1.Models;


namespace AvaloniaApplication1.Repository;

public interface IRepository<T> // IRepository<T>
{
    T GetById(int id);
    IList<T> GetAll();
    T Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}