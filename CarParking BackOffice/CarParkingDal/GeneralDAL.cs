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
    public class GeneralDAL
    {
        private IDbConnection db = null;
        public GeneralDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(General general)
        {
            long result = 0;

            try
            {
                result = db.Insert(general);
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
        public bool update(General general)
        {
            bool result = false;

            try
            {
                result = db.Update(general);
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
            General general = new General();

            try
            {
                general.Id = id;
                result = db.Delete(general);
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
        public General getById(int id)
        {
            General general = null;
            try
            {
                general = db.Get<General>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return general;
        }
        #endregion getById

        #region getAll
        public IEnumerable<General> getAll()
        {
            IEnumerable<General> generals = null;
            try
            {
                generals = db.GetAll<General>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return generals;
        }
        #endregion getAll

        #region getByCodeAndTypeCode
        public General getByCodeAndTypeCode(string code, string typeCode)
        {
            General general = null;
            try
            {
                var query = String.Format("SELECT * FROM General WHERE Code='{0}' AND TypeCode='{1}'", code, typeCode);
                general = db.Query<General>(query).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return general;
        }
        #endregion getLogin
    }
}
