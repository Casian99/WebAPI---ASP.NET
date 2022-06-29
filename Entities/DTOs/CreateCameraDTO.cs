using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities.DTOs
{
    public class CreateCameraDTO
    {
        public int NrCamera { get; set; }
        public int NrPersoane { get; set; }
        public int SeaView { get; set; }
        public int HotelId { get; set; }

    }
}
