using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper.Contrib.Extensions;
using CarParkingData;

namespace CarParkingDAL
{
    public class BuildingDAL
    {
        private IDbConnection db = null;
        public BuildingDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(Building building)
        {
            long result = 0;

            try
            {
                result = db.Insert(building);
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
        public bool update(Building building)
        {
            bool result = false;

            try
            {
                result = db.Update(building);
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
            Building building = new Building();

            try
            {
                building.Id = id;
                result = db.Delete(building);
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
        public Building getById(int id)
        {
            Building building = null;
            try
            {
                building = db.Get<Building>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return building;
        }
        #endregion getById

        #region getAll
        public IEnumerable<Building> getAll()
        {
            IEnumerable<Building> buildings = null;
            try
            {
                buildings = db.GetAll<Building>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildings;
        }
        #endregion getAll
    }
}
