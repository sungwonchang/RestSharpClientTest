using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpLib.Models.Request
{
    
    public class OrderRequest
    {
        public long Id{ get; set; }
        public int PetId { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public bool Complete { get; set; }
    }

}
