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
    public class BuildingBIL
    {
        BuildingDAL buildingDAL = null;
        public BuildingBIL()
        {
            buildingDAL = new BuildingDAL();
        }

        #region insert
        public long insert(Building building)
        {
            long result = 0;

            try
            {
                result = buildingDAL.insert(building);
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
        public bool update(Building building)
        {
            bool result = false;

            try
            {
                result = buildingDAL.update(building);
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
                result = buildingDAL.delete(id);
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
        public Building getById(int id)
        {
            Building building = null;
            try
            {
                building = buildingDAL.getById(id);
            }
            catch
            {
                throw;
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
                buildings = buildingDAL.getAll();
            }
            catch
            {
                throw;
            }
            return buildings;
        }
        #endregion getAll
    }
}
