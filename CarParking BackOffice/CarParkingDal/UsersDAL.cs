using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper.Contrib.Extensions;
using CarParkingData;
using Dapper;

namespace CarParkingDAL
{
    public class UsersDAL
    {
        private IDbConnection db = null;
        public UsersDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(Users users)
        {
            long result = 0;

            try
            {
                result = db.Insert(users);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
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
                result = db.Update(users);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return result;
        }
        #endregion update

        #region delete
        public bool delete(int id)
        {
            bool result = false;
            Users users = new Users();

            try
            {
                users.Id = id;
                result = db.Delete(users);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
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
                users = db.Get<Users>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
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
                userss = db.GetAll<Users>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return userss;
        }
        #endregion getAll

        #region getLogin
        public Users getLogin(string username,string password)
        {
            Users users = null;
            try
            {
                var query = String.Format("SELECT * FROM Users WHERE UserName='{0}' AND Password='{1}'", username, password);
                users = db.Query<Users>(query).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return users;
        }
        #endregion getLogin

        #region getUserByUID
        public Users getUserByUID(string uid)
        {
            Users users = null;
            try
            {
                var query = String.Format("SELECT * FROM Users WHERE CarNo IN (SELECT CarNo FROM RfidConfig WHERE RfidUid='{0}')", uid);
                users = db.Query<Users>(query).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return users;
        }
        #endregion getUserByUID

        #region searchByCodition
        public IEnumerable<Users> searchByCodition(string column, string value)
        {
            IEnumerable<Users> users = null;
            try
            {
                string sql = String.Format("SELECT * FROM Users WHERE {0} LIKE '%{1}%'", column, value);
                users = db.Query<Users>(sql);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return users;
        }
        #endregion searchByCodition
    }
}
