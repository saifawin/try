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
    public class BuildingparkDAL
    {
        private IDbConnection db = null;
        public BuildingparkDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(BuildingPark buildingpark)
        {
            long result = 0;

            try
            {
                result = db.Insert(buildingpark);
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
        public bool update(BuildingPark buildingpark)
        {
            bool result = false;

            try
            {
                result = db.Update(buildingpark);
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
            BuildingPark buildingpark = new BuildingPark();

            try
            {
                buildingpark.Id = id;
                result = db.Delete(buildingpark);
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
        public BuildingPark getById(int id)
        {
            BuildingPark buildingpark = null;
            try
            {
                buildingpark = db.Get<BuildingPark>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingpark;
        }
        #endregion getById

        #region getAll
        public IEnumerable<BuildingPark> getAll()
        {
            IEnumerable<BuildingPark> buildingparks = null;
            try
            {
                buildingparks = db.GetAll<BuildingPark>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingparks;
        }
        #endregion getAll

        #region getByBuildingId
        public IEnumerable<BuildingParkMaster> getByBuildingClassId(int buildingClassId)
        {
            IEnumerable<BuildingParkMaster> buildingPark = null;
            try
            {
                var query = String.Format(@"  SELECT BuildingParkMaster.*,
                                                (CASE General.Code WHEN 'AV' THEN 'green' WHEN 'NAV' THEN 'red' ELSE 'gold' END) Color,
                                                BuildingPark.Id BuildingParkId 
                                                FROM  BuildingParkMaster
                                                LEFT JOIN BuildingPark ON BuildingPark.BuildingParkMasterId = BuildingParkMaster.Id 
                                                LEFT JOIN General	   ON General.Id=BuildingPark.StatusId AND General.TypeCode='BOOKING'
                                              WHERE BuildingClassId={0} AND General.Code='AV'", buildingClassId);

                buildingPark = db.Query<BuildingParkMaster>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingPark;
        }
        #endregion getByBuildingId

        #region getByBuildingAllByClassId
        public IEnumerable<BuildingParkMaster> getByBuildingAllByClassId(int buildingClassId)
        {
            IEnumerable<BuildingParkMaster> buildingPark = null;
            try
            {
                var query = String.Format(@"  SELECT BuildingParkMaster.*,
                                                (CASE General.Code WHEN 'AV' THEN 'green' WHEN 'NAV' THEN 'red' ELSE 'gold' END) Color,
                                                BuildingPark.Id BuildingParkId 
                                                FROM  BuildingParkMaster
                                                LEFT JOIN BuildingPark ON BuildingPark.BuildingParkMasterId = BuildingParkMaster.Id 
                                                LEFT JOIN General	   ON General.Id=BuildingPark.StatusId AND General.TypeCode='BOOKING'
                                              WHERE BuildingClassId={0}", buildingClassId);

                buildingPark = db.Query<BuildingParkMaster>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingPark;
        }
        #endregion getByBuildingAllByClassId

        #region countAllParkAvailable
        public int countAllParkAvailable()
        {
            int count = 0;
            try
            {
                var query ="SELECT COUNT(Id) AS CountAllPark FROM BuildingPark WHERE StatusId = (SELECT Id FROM General WHERE Code = 'AV' AND TypeCode = 'BOOKING')";
                count = db.ExecuteScalar<int>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return count;
        }
        #endregion countAllParkAvailable
    }
}
