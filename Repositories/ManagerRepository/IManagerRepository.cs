using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.ManagerRepository
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        Task<Manager> GetByName(string name);
        Task<List<Manager>> GetAllManagersWithHotelId();
        Task<Manager> GetByIdWithHotelId(int id);
    }
}
