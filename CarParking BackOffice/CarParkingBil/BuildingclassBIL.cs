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
    public class BuildingclassBIL
    {
        BuildingclassDAL buildingclassDAL = null;
        public BuildingclassBIL()
        {
            buildingclassDAL = new BuildingclassDAL();
        }

        #region insert
        public long insert(BuildingClass buildingclass)
        {
            long result = 0;

            try
            {
                result = buildingclassDAL.insert(buildingclass);
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
        public bool update(BuildingClass buildingclass)
        {
            bool result = false;

            try
            {
                result = buildingclassDAL.update(buildingclass);
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
                result = buildingclassDAL.delete(id);
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
        public BuildingClass getById(int id)
        {
            BuildingClass buildingclass = null;
            try
            {
                buildingclass = buildingclassDAL.getById(id);
            }
            catch
            {
                throw;
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
                buildingclasss = buildingclassDAL.getAll();
            }
            catch
            {
                throw;
            }
            return buildingclasss;
        }
        #endregion getAll

        #region getByBuildingId
        public IEnumerable<BuildingClassMaster> getByBuildingId(int buildingId)
        {
            IEnumerable<BuildingClassMaster> buildingClass = null;
            try
            {
                buildingClass = buildingclassDAL.getByBuildingId(buildingId);
            }
            catch
            {
                throw;
            }
            return buildingClass;
        }
        #endregion getByBuildingId

        #region countAllClassAvailable
        public int countAllClassAvailable(int buildingClassId)
        {
            int count = 0;
            try
            {
                count = buildingclassDAL.countAllClassAvailable(buildingClassId);
            }
            catch
            {
                throw;
            }
            return count;
        }
        #endregion countAllClassAvailable
    }
}
