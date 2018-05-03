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
    public class RfidConfigBIL
    {
        RfidConfigDAL rfidConfigDAL = null;
        public RfidConfigBIL()
        {
            rfidConfigDAL = new RfidConfigDAL();
        }

        #region insert
        public long insert(RfidConfig rfidConfig)
        {
            long result = 0;

            try
            {
                result = rfidConfigDAL.insert(rfidConfig);
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
        public bool update(RfidConfig rfidConfig)
        {
            bool result = false;

            try
            {
                result = rfidConfigDAL.update(rfidConfig);
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
                result = rfidConfigDAL.delete(id);
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
        public RfidConfig getById(int id)
        {
            RfidConfig rfidConfig = null;
            try
            {
                rfidConfig = rfidConfigDAL.getById(id);
            }
            catch
            {
                throw;
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
                rfidConfigs = rfidConfigDAL.getAll();
            }
            catch
            {
                throw;
            }
            return rfidConfigs;
        }
        #endregion getAll

        #region searchByCodition
        public IEnumerable<RfidConfig> searchByCodition(string column, string value)
        {
            IEnumerable<RfidConfig> rfidConfigs = null;
            try
            {
                rfidConfigs = rfidConfigDAL.searchByCodition(column, value);
            }
            catch
            {
                throw;
            }
            return rfidConfigs;
        }
        #endregion searchByCodition
    }
}
