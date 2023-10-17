using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string? Name { get; set; }

        public int TotalAmount { get; set; }
        public bool StatusOrder { get; set; }
        public List<OrderDetails> list_json_chitiethoadon { get; set; }
    }
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        //public int status { get; set; }
    }
}
