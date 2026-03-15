using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository;
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ImageRepo : IImageRepo
    {
        private readonly ApplicationDBContext _context;
        public ImageRepo(ApplicationDBContext context)
        {
            
            _context = context;
        }
        public async Task AddNewAsync(Image image)
        {
            await _context.AddAsync(image);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image image)
        {
            _context.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAllAsync()
        {
         return await _context.Images.ToListAsync();
        }

        public  async Task<Image> GetByIdAsync(int id)
        {
              return await _context.Images.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Image image)
        {
           _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
