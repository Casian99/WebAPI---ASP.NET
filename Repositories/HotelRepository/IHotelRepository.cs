using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.HotelRepository
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<Hotel> GetByName(string name);
        Task<List<Hotel>> GetAllHotelsWithManager();
        Task<Hotel> GetByIdWithManager(int id);
    }
}
