using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectASP.NET.Entities;
using proiectASP.NET.Entities.DTOs;
using proiectASP.NET.Repositories.ManagerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly IManagerRepository _repository;
        public ManagerController(IManagerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManagers()
        {
            var managers = await _repository.GetAllManagersWithHotelId();

            var managersToReturn = new List<ManagerDTO>();

            foreach (var manager in managers)
            {
                managersToReturn.Add(new ManagerDTO(manager));
            }

            return Ok(managersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelyId(int id)
        {
            var manager = await _repository.GetByIdWithHotelId(id);

            return Ok(new ManagerDTO(manager));
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateManagerDTO dto)
        {
            Manager newManager = new Manager();

            newManager.Nume = dto.Nume;
            newManager.HotelId = dto.HotelId;

            _repository.Create(newManager);

            await _repository.SaveAsync();

            return Ok(new ManagerDTO(newManager));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _repository.GetByIdAsync(id);

            if (manager == null)
            {
                return NotFound("Managerul nu exista!!!");
            }

            _repository.Delete(manager);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManager([FromBody] Manager manager)
        {
            var thisManager = await _repository.GetByIdAsync(manager.Id);

            thisManager.Nume = manager.Nume;
            thisManager.HotelId = manager.HotelId;

            if (thisManager == null)
            {
                return NotFound("Managerul nu exista!!!");
            }

            _repository.Update(thisManager);

            await _repository.SaveAsync();

            return Ok();

        }
    }
}
