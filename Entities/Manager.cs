using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
