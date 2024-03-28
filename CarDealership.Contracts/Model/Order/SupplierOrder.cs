using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Contracts.Model.Car;
using CarDealership.Contracts.Enum;

namespace CarDealership.Contracts.Model.Order;

public class SupplierOrder : BaseOrder
{
    public string SupplierName { get; set; }
}
