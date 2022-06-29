using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities.DTOs
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }


        public ManagerDTO(Manager manager)
        {
            this.Id = manager.Id;
            this.Nume = manager.Nume;
            this.HotelId = manager.HotelId;
            this.Hotel = new Hotel();

        }
    }
}
