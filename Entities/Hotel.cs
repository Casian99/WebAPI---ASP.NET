using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int NrStele { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Camera> Camere { get; set; }
        public ICollection<RezervareClientHotel> RezervariClientHotel { get; set; }


    }
}
