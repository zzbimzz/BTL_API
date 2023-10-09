﻿

using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class BooksBusiness : IBooksBusiness
    {
        private IBooksRepository _res;
        public BooksBusiness(IBooksRepository res)
        {
            _res = res;
        }
        public BooksModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(BooksModel model)
        {
            return _res.Create(model);
        }
        public bool Update(BooksModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        /*public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name, string Address)
        {
            return _res.Search(pageIndex, pageSize, out total, Name, Address);
        }*/
    }
}