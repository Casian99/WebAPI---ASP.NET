using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectASP.NET.Entities;
using proiectASP.NET.Entities.DTOs;
using proiectASP.NET.Repositories.HotelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _repository;
        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _repository.GetAllHotelsWithManager();

            var hotelsToReturn = new List<HotelDTO>();

            foreach(var hotel in hotels)
            {
                hotelsToReturn.Add(new HotelDTO(hotel));
            }

            return Ok(hotelsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelyId(int id)
        {
            var hotel = await _repository.GetByIdWithManager(id);

            return Ok(new HotelDTO(hotel));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelDTO dto)
        {
            Hotel newHotel = new Hotel();

            newHotel.Nume = dto.Nume;
            newHotel.NrStele = dto.NrStele;

            _repository.Create(newHotel);

            await _repository.SaveAsync();

            return Ok(new HotelDTO(newHotel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _repository.GetByIdAsync(id);

            if (hotel == null)
            {
                return NotFound("Hotelul nu exista!!!");
            }

            _repository.Delete(hotel);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            var thisHotel = await _repository.GetByIdAsync(hotel.Id);

            thisHotel.Nume = hotel.Nume;
            thisHotel.NrStele = hotel.NrStele;

            if (thisHotel == null)
            {
                return NotFound("Hotelul nu exista!!!");
            }

            _repository.Update(thisHotel);

            await _repository.SaveAsync();

            return Ok();

        }

    }
}

/*
[HttpPut]
public async Task<IActionResult> UpdateClient([FromBody] Client client)
{
    var clientCurent = await _repository.GetByIdAsync(client.Id);
    clientCurent.Nume = client.Nume;
    clientCurent.Telefon = client.Telefon;

    if (clientCurent == null)
    {
        return NotFound("Clientul nu exista!");
    }

    _repository.Update(clientCurent);

    await _repository.SaveAsync();

    return Ok();
}
*/