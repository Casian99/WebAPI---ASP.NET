using Microsoft.EntityFrameworkCore;
using proiectASP.NET.Data;
using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.ManagerRepository
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(ProiectContext context) : base(context) { }

        public async Task<List<Manager>> GetAllManagersWithHotelId()
        {
            return await _context.Managers.Include(a => a.HotelId).ToListAsync();
        }
        
        public async Task<Manager> GetByIdWithHotelId(int id)
        {
            return await _context.Managers.Include(a => a.HotelId).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Manager> GetByName(string name)
        {
            return await _context.Managers.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
