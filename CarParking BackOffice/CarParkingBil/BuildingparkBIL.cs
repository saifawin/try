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
    public class BuildingparkBIL
    {
        BuildingparkDAL buildingparkDAL = null;
        public BuildingparkBIL()
        {
            buildingparkDAL = new BuildingparkDAL();
        }

        #region insert
        public long insert(BuildingPark buildingpark)
        {
            long result = 0;

            try
            {
                result = buildingparkDAL.insert(buildingpark);
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
        public bool update(BuildingPark buildingpark)
        {
            bool result = false;

            try
            {
                result = buildingparkDAL.update(buildingpark);
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
                result = buildingparkDAL.delete(id);
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
        public BuildingPark getById(int id)
        {
            BuildingPark buildingpark = null;
            try
            {
                buildingpark = buildingparkDAL.getById(id);
            }
            catch
            {
                throw;
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
                buildingparks = buildingparkDAL.getAll();
            }
            catch
            {
                throw;
            }
            return buildingparks;
        }
        #endregion getAll

        #region getByBuildingId
        public IEnumerable<BuildingParkMaster> getByBuildingClassId(int buildingClassId)
        {
            IEnumerable<BuildingParkMaster> buildingparks = null;
            try
            {
                buildingparks = buildingparkDAL.getByBuildingClassId(buildingClassId);
            }
            catch
            {
                throw;
            }
            return buildingparks;
        }
        #endregion getByBuildingId

        #region getByBuildingAllByClassId
        public IEnumerable<BuildingParkMaster> getByBuildingAllByClassId(int buildingClassId)
        {
            IEnumerable<BuildingParkMaster> buildingparks = null;
            try
            {
                buildingparks = buildingparkDAL.getByBuildingAllByClassId(buildingClassId);
            }
            catch
            {
                throw;
            }
            return buildingparks;
        }
        #endregion getByBuildingAllByClassId

        #region countAllParkAvailable
        public int countAllParkAvailable()
        {
            int count = 0;
            try
            {
                count = buildingparkDAL.countAllParkAvailable();
            }
            catch
            {
                throw;
            }
            return count;
        }
        #endregion countAllParkAvailable
    }
}
