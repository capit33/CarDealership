using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Invoice;

public class CustomerInvoice : BaseInvoice
{
    public string CustomerId { get; set; }
}
