using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
       
        private String _connStr;
        private IUsersRepository _Users;
        private IBooksRepository _Books;
        private IPurchaseServiceRepository _PurchaseService;

        public IUsersRepository Users
        {
            get
            {
                if (_Users == null)
                {
                    
                    _Users = new UsersRepository(_connStr);
                }

                return _Users;
            }
        }

        public IBooksRepository Books
        {
            get
            {
                if (_Books == null)
                {
                    
                    _Books = new BooksRepository(_connStr);
                }

                return _Books;
            }
        }

   

        public IPurchaseServiceRepository PurchaseService
        {
            get
            {
                if (_PurchaseService == null)
                {

                    _PurchaseService = new PurchaseServiceRepository(_connStr,this);
                }

                return _PurchaseService;
            }
        }


        public RepositoryWrapper(String cstr)
        {
            this._connStr = cstr;
       
        }
    }
}
