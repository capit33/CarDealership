using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Car;

public class CarModel
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Engine { get; set; }
    public string FuelType { get; set; }
    public string Transmission { get; set; }
    public string BodyType { get; set; }
    public string Color { get; set; }
    public List<CarSpecific> Specification { get; set; }
}
