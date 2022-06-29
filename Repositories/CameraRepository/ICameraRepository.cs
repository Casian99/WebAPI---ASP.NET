using proiectASP.NET.Entities;
using proiectASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Repositories.CameraRepository
{
    public interface ICameraRepository : IGenericRepository<Camera>
    {
        Task<Camera> GetByNumber(int number);
        Task<List<Camera>> GetAllCamerasWithHotelId();
        Task<Camera> GetByIdWithHotelId(int id);
    }
}
