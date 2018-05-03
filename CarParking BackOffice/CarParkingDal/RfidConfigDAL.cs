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
    public class RfidConfigDAL
    {
        private IDbConnection db = null;
        public RfidConfigDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(RfidConfig rfidConfig)
        {
            long result = 0;

            try
            {
                result = db.Insert(rfidConfig);
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
        public bool update(RfidConfig rfidConfig)
        {
            bool result = false;

            try
            {
                result = db.Update(rfidConfig);
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
            RfidConfig rfidConfig = new RfidConfig();

            try
            {
                rfidConfig.Id = id;
                result = db.Delete(rfidConfig);
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
        public RfidConfig getById(int id)
        {
            RfidConfig rfidConfig = null;
            try
            {
                rfidConfig = db.Get<RfidConfig>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return rfidConfig;
        }
        #endregion getById

        #region getAll
        public IEnumerable<RfidConfig> getAll()
        {
            IEnumerable<RfidConfig> rfidConfigs = null;
            try
            {
                rfidConfigs = db.GetAll<RfidConfig>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return rfidConfigs;
        }
        #endregion getAll

        #region getByUID
        public RfidConfig getByUID(string uid)
        {
            RfidConfig rfidConfig = null;
            try
            {
                var query = String.Format("SELECT * FROM RfidConfig WHERE RfidUid='{0}'", uid);
                rfidConfig = db.Query<RfidConfig>(query).FirstOrDefault();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                db.Close();
            }
            return rfidConfig;
        }
        #endregion getByUID

        #region searchByCodition
        public IEnumerable<RfidConfig> searchByCodition(string column, string value)
        {
            IEnumerable<RfidConfig> categorys = null;
            try
            {
                string sql = String.Format("SELECT * FROM RfidConfig WHERE {0} LIKE '%{1}%'", column, value);
                categorys = db.Query<RfidConfig>(sql);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return categorys;
        }
        #endregion searchByCodition

    }
}
