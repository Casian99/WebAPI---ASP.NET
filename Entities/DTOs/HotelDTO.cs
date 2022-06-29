using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities.DTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int NrStele { get; set; }
        public Manager Manager { get; set; }
        public List<Camera> Camere { get; set; }
        public List<RezervareClientHotel> RezervariClientHotel { get; set; }

        public HotelDTO(Hotel hotel)
        {
            this.Id = hotel.Id;
            this.Nume = hotel.Nume;
            this.NrStele = hotel.NrStele;
            this.Manager = new Manager();
            this.Camere = new List<Camera>();
            this.RezervariClientHotel = new List<RezervareClientHotel>();

        }
    }
}
