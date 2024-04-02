using System.Collections.Generic;
using System.Threading.Tasks;
using MiPrimeraAppMvc.Models;

namespace MiPrimeraAppMvc.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
         Task<IEnumerable<Producto>> GetAll();

         Task<Producto> GetById(int Id);

         Task<int> Create(Producto producto);

         Task<int> Update(Producto producto);

         Task<bool> DeleteById(int Id);

    }
}