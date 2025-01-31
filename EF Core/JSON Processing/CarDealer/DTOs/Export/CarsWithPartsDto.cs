using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;

namespace CarDealer.DTOs.Export
{
    public class CarsWithPartsDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TraveledDistance { get; set; }
        public IEnumerable<ExportPartDto> Parts { get; set; }
    }
}
