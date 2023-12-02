using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BooksModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ImageBook { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public int SupplierID { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

/*        public string GenreName { get; set; }

        public string AuthorName { get; set; }
        public string SupplierName { get; set; }*/



    }
}
