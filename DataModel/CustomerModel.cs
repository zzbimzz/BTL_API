using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataModel
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string TenKH { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

    }
}