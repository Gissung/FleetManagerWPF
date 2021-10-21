using FleetManager.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Data.Daos.REST.Model
{
    static class MapperExtensions
    { 
        public static Car  Map(this CarDto carDto) {
            return new Car
            {
                Id = int.Parse (carDto.Href[( carDto.Href.LastIndexOf("/")+1)..] ), 
                Location = null, 
                Brand = carDto.Brand, 
                Mileage = carDto.Mileage


            };
        }
        public static Location Map(this LocationDto locationDto) {
            return new Location
            {
                Id = int.Parse(locationDto.Href[(locationDto.Href.LastIndexOf("/") + 1)..]),
                Name = null
            };
        }
    }
}
