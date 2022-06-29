using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities
{
    public class Camera
    {
        public int Id { get; set; }
        public int NrCamera { get; set; }
        public int NrPersoane { get; set; }
        public int SeaView { get; set; }  // 0- nu are si 1-are 
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }


    }
}
