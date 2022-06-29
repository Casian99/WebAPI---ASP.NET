using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Entities.DTOs
{
    public class CameraDTO
    {
        public int Id { get; set; }
        public int NrCamera { get; set; }
        public int NrPersoane { get; set; }
        public int SeaView { get; set; }  // 0- nu are si 1-are 
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public CameraDTO(Camera camera)
        {
            this.Id = camera.Id;
            this.NrCamera = camera.NrCamera;
            this.NrPersoane = camera.NrPersoane;
            this.SeaView = camera.SeaView;
            this.HotelId = camera.HotelId;
            this.Hotel = new Hotel();

        }
    }
}
