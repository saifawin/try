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
    public class RfidStampDAL
    {
        private IDbConnection db = null;
        public RfidStampDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(RfidStamp rfidstamp)
        {
            long result = 0;

            try
            {
                result = db.Insert(rfidstamp);
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
        public bool update(RfidStamp rfidstamp)
        {
            bool result = false;

            try
            {
                result = db.Update(rfidstamp);
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
            RfidStamp rfidstamp = new RfidStamp();

            try
            {
                rfidstamp.Id = id;
                result = db.Delete(rfidstamp);
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
        public RfidStamp getById(int id)
        {
            RfidStamp rfidstamp = null;
            try
            {
                rfidstamp = db.Get<RfidStamp>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return rfidstamp;
        }
        #endregion getById

        #region getAll
        public IEnumerable<RfidStamp> getAll()
        {
            IEnumerable<RfidStamp> rfidstamps = null;
            try
            {
                rfidstamps = db.GetAll<RfidStamp>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return rfidstamps;
        }
        #endregion getAll

        #region getByStatus
        public int getByStatus(string uid, string status)
        {
            int rfidStamp = 0;
            try
            {
                var query = String.Format(@"  SELECT COUNT(Id) 
                                                  FROM RfidStamp
                                                  WHERE UID = '{0}'
                                                  AND Status = '{1}'
                                                  AND Date = (SELECT MAX(Date) FROM RfidStamp WHERE UID = '{0}')", uid, status);

                rfidStamp = db.Query<int>(query).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return rfidStamp;
        }
        #endregion getByStatus

        #region getPayment
        public decimal getPayment(string uid)
        {
            decimal payment = 0;
            try
            {
                var query = String.Format(@"  	SELECT
	                                                ISNULL(DATEDIFF(Hour,
	                                                    (	        
				                                            SELECT (CASE WHEN BookTimeIn<TimeIn THEN BookTimeIn ELSE TimeIn END) TimeIn FROM
				                                            (
					                                            SELECT
					                                              (SELECT MAX(TimeStamp) FROM Booking WHERE UserId=(  SELECT Id FROM Users WHERE CarNo=(SELECT CarNo FROM RfidConfig WHERE RfidUid='{0}'))) BookTimeIn,
					                                              (SELECT MAX(Date) FROM RfidStamp WHERE UID = '{0}' AND Status = 'IN') TimeIn
				                                            ) AS TimeIn
		                                                )
		                                                ,
		                                                (
		                                                    SELECT MAX(Date) FROM RfidStamp WHERE UID = '{0}' AND Status = 'OUT'
		                                                )
	                                                ),0) * (SELECT Name FROM General WHERE Code='HOUR' AND TypeCode='PAY')
                                                AS TotalHour", uid);

                payment = db.ExecuteScalar<decimal>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return payment;
        }
        #endregion getPayment
    }
}
