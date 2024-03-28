using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Enum;

public enum InventoryStatus
{
    Creating,
    Ordered,
    Available,
    Reserved,
    SoldOut,
}
