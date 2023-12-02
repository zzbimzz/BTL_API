using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SearchOrderModel
    {
        public int OrderID_O { get; set; }
        public int CustomerID { get; set; }

        public int TotalAmount { get; set; }
        public bool StatusOrder { get; set; }
        public int OrderDetailID { get; set; }
        public int BookID_OD { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        public string CustomerName { get; set; }
        public string BookTitle { get; set; }
        public string ImageBook { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails>? list_json_chitiethoadon { get; set; }
    }

}
