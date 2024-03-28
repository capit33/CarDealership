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
    public string ModelTrim {  get; set; }
    public int Year { get; set; }
}
