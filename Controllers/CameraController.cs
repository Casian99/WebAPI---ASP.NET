using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectASP.NET.Entities;
using proiectASP.NET.Entities.DTOs;
using proiectASP.NET.Repositories.CameraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraRepository _repository;
        public CameraController(ICameraRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _repository.GetAllCamerasWithHotelId();

            var roomsToReturn = new List<CameraDTO>();

            foreach (var room in rooms)
            {
                roomsToReturn.Add(new CameraDTO(room));
            }

            return Ok(roomsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCameraId(int id)
        {
            var room = await _repository.GetByIdWithHotelId(id);

            return Ok(new CameraDTO(room));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCamera(CreateCameraDTO dto)
        {
            Camera newCamera = new Camera();

            newCamera.NrCamera = dto.NrCamera;
            newCamera.NrPersoane = dto.NrPersoane;
            newCamera.SeaView = dto.SeaView;
            newCamera.HotelId = dto.HotelId;

            _repository.Create(newCamera);

            await _repository.SaveAsync();

            return Ok(new CameraDTO(newCamera));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamera(int id)
        {
            var camera = await _repository.GetByIdAsync(id);

            if (camera == null)
            {
                return NotFound("Camera nu exista!!!");
            }

            _repository.Delete(camera);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCamera([FromBody] Camera camera)
        {
            var thisCamera = await _repository.GetByIdAsync(camera.Id);

            thisCamera.NrCamera = camera.NrCamera;
            thisCamera.NrPersoane = camera.NrPersoane;
            thisCamera.SeaView = camera.SeaView;
            thisCamera.HotelId = camera.HotelId;

            if (thisCamera == null)
            {
                return NotFound("Camera nu exista!!!");
            }

            _repository.Update(thisCamera);

            await _repository.SaveAsync();

            return Ok();

        }
    }


}
