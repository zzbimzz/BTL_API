using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataModel
{
    public class CartsModel
    {
        public int CartID { get; set; }
        public int CustomerID        { get; set; }
        public string CustomerName { get; set; }
        public string BookTitle { get; set; }
        public int BookPrice { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }


    }
}