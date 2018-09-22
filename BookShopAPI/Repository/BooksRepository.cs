using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MySql.Data.MySqlClient;
using Contracts;
using Entities;
using Entities.Models;
using System.Data;
using System.Reflection;
using System.Linq;

namespace Repository
{
     public class BooksRepository :  IBooksRepository
    {
        private MySqlDataAdapter _sqlDA;
        private string _sqlStr;
        private string _connStr;
        public BooksRepository(string connStr)
        {
            _sqlStr = "SELECT * FROM Books";
            _connStr = connStr;
            _sqlDA = new MySqlDataAdapter(_sqlStr, _connStr);
        }
        public int Create(Books newBook)
        {
            try
            {

                string insStr = "INSERT INTO Books (BookId,Title,Author,Price) Values (@BookId,@Title,@Author,@Price)";
                MySqlConnection myConnection = new MySqlConnection(_connStr);
                MySqlCommand sqlCmd = new MySqlCommand(insStr, myConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@BookId", newBook.BookId);
                sqlCmd.Parameters.AddWithValue("@Title", newBook.Title);
                sqlCmd.Parameters.AddWithValue("@Author", newBook.Author);
                sqlCmd.Parameters.AddWithValue("@Price", newBook.Price);
                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                if (rowInserted == 0) throw new Exception("0 Books  created");
                return rowInserted;
            }
            catch(Exception e)
            {
                throw new Exception("Book not created. " +e.Message );
            }

        }

        public void Delete(Books entity)
        {
            throw new NotImplementedException();
        }

        public IList<Books> FindAll()
        {
            DataTable dt = new DataTable();
            _sqlDA.SelectCommand.CommandText = _sqlStr;
            _sqlDA.Fill(dt);
            return repoHelper.GetEntities<Books>(dt);
            
        }

        public Books FindByID(string id)
        {
            DataTable dt = new DataTable();
            _sqlDA.SelectCommand.CommandText = _sqlStr + " where BookId = '" + id + "'";
            _sqlDA.Fill(dt);
            return repoHelper.GetEntities<Books>(dt).FirstOrDefault();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Books entity)
        {
            throw new NotImplementedException();
        }

    }
}
