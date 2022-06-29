using Microsoft.EntityFrameworkCore;
using proiectASP.NET.Data;
using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.HotelRepository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ProiectContext context) : base(context) { }


        public async Task<List<Hotel>> GetAllHotelsWithManager()
        {
            return await _context.Hotels.Include(a => a.Manager).ToListAsync();
        }

        public async Task<Hotel> GetByIdWithManager(int id)
        {
            return await _context.Hotels.Include(a => a.Manager).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Hotel> GetByName(string name)
        {
            return await _context.Hotels.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync();
        }

 
    }
}
