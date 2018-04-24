using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarParkingData;
using CarParkingDAL;

namespace CarParkingBIL
{
    public class UsersBIL
    {
        UsersDAL usersDAL = null;
        public UsersBIL()
        {
            usersDAL = new UsersDAL();
        }

        #region insert
        public long insert(Users users)
        {
            long result = 0;

            try
            {
                result = usersDAL.insert(users);
                if (result<=0) throw new Exception("update failed!");
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion insert

        #region update
        public bool update(Users users)
        {
            bool result = false;

            try
            {
                result = usersDAL.update(users);
                if (!result) throw new Exception("update failed!");
            }
            catch
            {
                throw;
            }

            return result;
        }
        #endregion update

        #region delete
        public bool delete(int id)
        {
            bool result = false;
            try
            {
                result = usersDAL.delete(id);
                if (!result) throw new Exception("delete failed!");
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion delete

        #region getById
        public Users getById(int id)
        {
            Users users = null;
            try
            {
                users = usersDAL.getById(id);
            }
            catch
            {
                throw;
            }
            return users;
        }
        #endregion getById

        #region getAll
        public IEnumerable<Users> getAll()
        {
            IEnumerable<Users> userss = null;
            try
            {
                userss = usersDAL.getAll();
            }
            catch
            {
                throw;
            }
            return userss;
        }
        #endregion getAll

        #region getLogin
        public Users getLogin(string username, string password)
        {
            Users users = null;
            try
            {
                users = usersDAL.getLogin(username, password);
            }
            catch
            {
                throw;
            }
            finally
            {
                
            }
            return users;
        }
        #endregion getLogin

        #region searchByCodition
        public IEnumerable<Users> searchByCodition(string column, string value)
        {
            IEnumerable<Users> users = null;
            try
            {
                users = usersDAL.searchByCodition(column, value);
            }
            catch
            {
                throw;
            }
            return users;
        }
        #endregion searchByCodition
    }
}
