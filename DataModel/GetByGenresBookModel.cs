using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GetByGenresBookModel
    {
        public List<BooksModel> list_json_getGenresBook_action { get; set; }
        public List<BooksModel> list_json_getGenresBook_romantic { get; set; }
        public List<BooksModel> list_json_getGenresBook_fantasy { get; set; }


    }
}
