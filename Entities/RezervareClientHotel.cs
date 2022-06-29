using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities
{
    public class RezervareClientHotel
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
