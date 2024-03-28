using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Order;

public class CustomerOrder : BaseOrder
{
    public string CustomerId { get; set; }
    public string CarFileId { get; set; }
}
