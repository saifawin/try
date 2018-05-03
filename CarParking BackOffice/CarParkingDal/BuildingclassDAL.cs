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
    public class BuildingclassDAL
    {
        private IDbConnection db = null;
        public BuildingclassDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(BuildingClass buildingclass)
        {
            long result = 0;

            try
            {
                result = db.Insert(buildingclass);
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
        public bool update(BuildingClass buildingclass)
        {
            bool result = false;

            try
            {
                result = db.Update(buildingclass);
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
            BuildingClass buildingclass = new BuildingClass();

            try
            {
                buildingclass.Id = id;
                result = db.Delete(buildingclass);
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
        public BuildingClass getById(int id)
        {
            BuildingClass buildingclass = null;
            try
            {
                buildingclass = db.Get<BuildingClass>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingclass;
        }
        #endregion getById

        #region getAll
        public IEnumerable<BuildingClass> getAll()
        {
            IEnumerable<BuildingClass> buildingclasss = null;
            try
            {
                buildingclasss = db.GetAll<BuildingClass>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingclasss;
        }
        #endregion getAll

        #region getByBuildingId
        public IEnumerable<BuildingClassMaster> getByBuildingId(int buildingId)
        {
            IEnumerable<BuildingClassMaster> buildingclasss = null;
            try
            {
                var query = String.Format(@"   SELECT BuildingClassMaster.*,
                                                 (SELECT Id FROM BuildingClass BuildingClassSub WHERE BuildingClassSub.Id=BuildingClass.Id) AS BuildingClassId 
                                                 FROM  BuildingClassMaster
                                                 LEFT JOIN BuildingClass ON BuildingClass.BuildingClassMasterId=BuildingClassMaster.Id
                                               WHERE BuildingId={0}", buildingId);

                buildingclasss = db.Query<BuildingClassMaster>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return buildingclasss;
        }
        #endregion getByBuildingId

        #region countAllClassAvailable
        public int countAllClassAvailable(int buildingClassId)
        {
            int count = 0;
            try
            {
                var query = String.Format(@"  SELECT COUNT(Id) AS CountAllClass FROM BuildingPark 
                                                WHERE StatusId = (SELECT Id FROM General WHERE Code = 'AV' AND TypeCode = 'BOOKING') AND
                                                BuildingClassId = {0}", buildingClassId);

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
        #endregion countAllClassAvailable
    }
}
