using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ISuppliersBusiness
    {
        SuppliersModel GetDatabyID(int id);
        bool Create(SuppliersModel model);
        bool Update(SuppliersModel model);
        bool Delete(int id);
        /*        List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string Name);*/
    }
}
