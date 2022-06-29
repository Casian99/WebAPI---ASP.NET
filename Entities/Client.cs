using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public ICollection<RezervareClientHotel> RezervariClientHotel { get; set; }

    }
}
