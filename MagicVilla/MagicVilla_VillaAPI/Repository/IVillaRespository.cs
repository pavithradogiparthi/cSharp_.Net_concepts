using System.Linq.Expressions;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository
{
    public interface IVillaRespository:IRepository<Villa>
    {
       
       
        Task <Villa>UpdateAsync(Villa entity);
       
    }
}
