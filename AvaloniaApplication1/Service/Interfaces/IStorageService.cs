using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaApplication1.Models;


namespace AvaloniaApplication1.Service;

public interface IStorageService<T>
{
    void Save(IList<T> tasksList);
    IList<T> Load();
    
}