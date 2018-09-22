using System.Linq.Expressions;
using System.Text;
using MySql.Data.MySqlClient;
using Contracts;
using Entities;
using Entities.Models;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Repository
{
   public class PurchaseServiceRepository:IPurchaseServiceRepository
    {
        private MySqlDataAdapter _sqlDA;
        private string _sqlStr;
        private string _connStr;
        private IRepositoryWrapper _repoWrapper;

      

        public PurchaseServiceRepository(string connStr, IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _sqlStr = "SELECT * FROM PurchaseItems";
            _connStr = connStr;
            _sqlDA = new MySqlDataAdapter(_sqlStr, _connStr);
        }

        public int PurchaseBook(string UserId, IList<PurchaseItems> purchaseItems)
        {

            
            MySqlConnection myConnection = new MySqlConnection(_connStr);
            myConnection.Open();
            MySqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction();

            try
            {

              
                string insStr = "INSERT INTO Purchases (DateOfPurchase,PurchasedBy) Values (@DateOfPurchase,@PurchasedBy);SELECT LAST_INSERT_ID()";

                MySqlCommand sqlCmd = new MySqlCommand(insStr, myConnection);
                sqlCmd.Transaction = myTrans;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@PurchasedBy", UserId);


                UInt64 purchaseId = (UInt64)sqlCmd.ExecuteScalar();

                if (purchaseId == 0)
                {
                    myConnection.Close();
                    throw new Exception("0 Purchases  created");
                }
              
                foreach (PurchaseItems newPurchaseItem in purchaseItems)
                {
                    Books book = _repoWrapper.Books.FindByID(newPurchaseItem.Book);


                    string insStr1 = "INSERT INTO PurchaseItems (Purchase,Book,Qty,UnitPrice,Note) Values (@Purchase,@Book,@Qty,@UnitPrice,@Note)";
                    MySqlCommand sqlCmd1 = new MySqlCommand(insStr1, myConnection);
                    sqlCmd1.CommandType = CommandType.Text;
                    sqlCmd1.Parameters.AddWithValue("@Purchase", purchaseId);
                    sqlCmd1.Parameters.AddWithValue("@Book", newPurchaseItem.Book);
                    sqlCmd1.Parameters.AddWithValue("@Qty", newPurchaseItem.Qty);
                    sqlCmd1.Parameters.AddWithValue("@UnitPrice", book.Price);
                    sqlCmd1.Parameters.AddWithValue("@Note", newPurchaseItem.Note);
                    if (sqlCmd1.ExecuteNonQuery() == 0) throw new Exception("0 PurchaseItems  created");
                }
                myTrans.Commit();
                myConnection.Close();
                return (int)purchaseId;
            }
            catch (Exception e)
            {
               
                    myTrans.Rollback();

                throw new Exception("PurchaseItem not created. " + e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }


        public IList<History> PurchaseHistory(string UserId)
        {
            DataTable dt = new DataTable();
            _sqlDA.SelectCommand.CommandText = "SELECT p.PurchaseID,p.DateOfPurchase,p.Status,p.DeliveredOn,i.Book,i.Note,b.Title,b.Author,i.Qty, i.UnitPrice FROM Purchases p INNER JOIN PurchaseItems i on p.PurchaseID = i.Purchase INNER JOIN Books b on i.Book = b.BookId WHERE p.PurchasedBy = '" + UserId + "' ORDER BY DateOfPurchase desc";
            _sqlDA.Fill(dt);
            return repoHelper.GetEntities<History>(dt);
        }


    }
}
