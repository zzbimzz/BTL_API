using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class StatiѕticModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public int Subtotal { get; set; }

    }

}
