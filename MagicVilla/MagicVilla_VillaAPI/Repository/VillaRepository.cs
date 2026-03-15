using System.Linq.Expressions;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository :Repository<Villa>,IVillaRespository
    {

        
        public VillaRepository(ApplicationDbContext db):base(db)
        {
            
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
           dbSet.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
