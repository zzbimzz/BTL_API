using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PrintOrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }




        public int TotalAmount { get; set; }
        public bool StatusOrder { get; set; }
        public string Name { get; set; }

        public DateTime OrderDate { get; set; }


        public List<OrderDetail>? list_json_chitiethoadon123 { get; set; }
    }
    public class OrderDetail
    {
        public int UserID { get; set; }

        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        public string ImageBook { get; set; }
        public string Title { get; set; }

    }
}
