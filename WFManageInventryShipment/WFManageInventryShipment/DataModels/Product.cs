using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFManageInventryShipment.DataModels
{
    public class Product
    {
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantityinstock { get; set; }
        public Decimal Price { get; set; }

    }
}
