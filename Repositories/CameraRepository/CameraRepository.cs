using Microsoft.EntityFrameworkCore;
using proiectASP.NET.Data;
using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.CameraRepository
{
    public class CameraRepository : GenericRepository<Camera>, ICameraRepository
    {

        public CameraRepository(ProiectContext context) : base(context) { }

        public async Task<List<Camera>> GetAllCamerasWithHotelId()
        {
            return await _context.Camere.Include(a => a.HotelId).ToListAsync();
        }

        public async Task<Camera> GetByIdWithHotelId(int id)
        {
            return await _context.Camere.Include(a => a.HotelId).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Camera> GetByNumber(int number)
        {
            return await _context.Camere.Where(a => a.NrCamera.Equals(number)).FirstOrDefaultAsync();
        }
    }
}
