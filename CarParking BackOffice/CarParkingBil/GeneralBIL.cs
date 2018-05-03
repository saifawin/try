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
    public class GeneralBIL
    {
        GeneralDAL generalDAL = null;
        public GeneralBIL()
        {
            generalDAL = new GeneralDAL();
        }

        #region insert
        public long insert(General general)
        {
            long result = 0;

            try
            {
                result = generalDAL.insert(general);
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
        public bool update(General general)
        {
            bool result = false;

            try
            {
                result = generalDAL.update(general);
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
                result = generalDAL.delete(id);
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
        public General getById(int id)
        {
            General general = null;
            try
            {
                general = generalDAL.getById(id);
            }
            catch
            {
                throw;
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
                generals = generalDAL.getAll();
            }
            catch
            {
                throw;
            }
            return generals;
        }
        #endregion getAll
    }
}
