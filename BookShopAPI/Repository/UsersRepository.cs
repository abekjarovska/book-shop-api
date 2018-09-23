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
    public class UsersRepository :  IUsersRepository
    {
       
        private MySqlDataAdapter _sqlDA;
        private string _sqlStr;
        private string _connStr;
        public UsersRepository(String connStr)
        {
            _sqlStr = "SELECT * FROM Users";
            _connStr = connStr;
           
            _sqlDA = new MySqlDataAdapter(_sqlStr, _connStr);
        }

        public int Create(Users newUser)
        {
            try
            {

                string insStr = "INSERT INTO Users (UserId,Name,Address,City,ZIP,Country,email,Registred) Values (@UserId,@Name,@Address,@City,@ZIP,@Country,@email,@Registred)";
                MySqlConnection myConnection = new MySqlConnection(_connStr);
                MySqlCommand sqlCmd = new MySqlCommand(insStr, myConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UserId", newUser.UserId);
                sqlCmd.Parameters.AddWithValue("@Name", newUser.Name);
                sqlCmd.Parameters.AddWithValue("@Address", newUser.Address);
                sqlCmd.Parameters.AddWithValue("@City", newUser.City);
                sqlCmd.Parameters.AddWithValue("@ZIP", newUser.ZIP);
                sqlCmd.Parameters.AddWithValue("@Country", newUser.Country);
                sqlCmd.Parameters.AddWithValue("@email", newUser.email);
                sqlCmd.Parameters.AddWithValue("@Registred", newUser.registred);
                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                if (rowInserted == 0) throw new Exception("0 Users  created");
                return rowInserted;
            }
            catch (Exception e)
            {
                throw new Exception("User not created. " + e.Message);
            }

        }

        public void Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public IList<Users> FindAll()
        {
            DataTable dt = new DataTable();
            _sqlDA.SelectCommand.CommandText = _sqlStr;
            _sqlDA.Fill(dt);
            return repoHelper.GetEntities<Users>(dt);
        }

       

        public Users FindByID(string id)
        {
            DataTable dt = new DataTable();
            _sqlDA.SelectCommand.CommandText = _sqlStr + " where UserId = '" + id + "'";
            _sqlDA.Fill(dt);
            return repoHelper.GetEntities<Users>(dt).FirstOrDefault();
        }
   

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Users user)
        {
            try
            {

                string insStr = "UPDATE  Users SET  Name=@Name,Address=@Address,City=@City,ZIP=@ZIP,Country=@Country,email=@email WHERE UserID = @UserId ";
                MySqlConnection myConnection = new MySqlConnection(_connStr);
                MySqlCommand sqlCmd = new MySqlCommand(insStr, myConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Name", user.Name);
                sqlCmd.Parameters.AddWithValue("@Address", user.Address);
                sqlCmd.Parameters.AddWithValue("@City", user.City);
                sqlCmd.Parameters.AddWithValue("@ZIP", user.ZIP);
                sqlCmd.Parameters.AddWithValue("@Country", user.Country);
                sqlCmd.Parameters.AddWithValue("@email", user.email);
                sqlCmd.Parameters.AddWithValue("@UserId", user.UserId);


                myConnection.Open();
                int rowUpdated = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                if (rowUpdated == 0) throw new Exception("0 Users  updated");
            }
            catch (Exception e)
            {
                throw new Exception("User not updated. " + e.Message);
            }
        }

        public void UnRegisterUser(string UserId)
        {
            try
            {

                string insStr = "UPDATE  Users SET Registred = 0 WHERE UserID = @UserId";
                MySqlConnection myConnection = new MySqlConnection(_connStr);
                MySqlCommand sqlCmd = new MySqlCommand(insStr, myConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UserId", UserId);
                myConnection.Open();
                int rowUpdated = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                if (rowUpdated == 0) throw new Exception("0 Users  updated");
            }
            catch (Exception e)
            {
                throw new Exception("User not updated. " + e.Message);
            }

        }

    }
}
