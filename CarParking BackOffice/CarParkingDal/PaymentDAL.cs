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
    public class PaymentDAL
    {
        private IDbConnection db = null;
        public PaymentDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(Payment payment)
        {
            long result = 0;

            try
            {
                result = db.Insert(payment);
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
        public bool update(Payment payment)
        {
            bool result = false;

            try
            {
                result = db.Update(payment);
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
            Payment payment = new Payment();

            try
            {
                payment.Id = id;
                result = db.Delete(payment);
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
        public Payment getById(int id)
        {
            Payment payment = null;
            try
            {
                payment = db.Get<Payment>(id);
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
        #endregion getById

        #region getAll
        public IEnumerable<Payment> getAll()
        {
            IEnumerable<Payment> payments = null;
            try
            {
                payments = db.GetAll<Payment>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return payments;
        }
        #endregion getAll

        #region getPaymentByUserId
        public IEnumerable<Payment> getPaymentByUserId(int userid)
        {
            IEnumerable<Payment> payments = null;
            try
            {
                var query = String.Format("SELECT * FROM Payment WHERE UserId={0} AND StatusId=(SELECT Id FROM General WHERE TypeCode='PAYMENT' AND Code='NPY')", userid);
                payments = db.Query<Payment>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return payments;
        }
        #endregion getPaymentByUserId

        #region getTotalPayment
        public decimal getTotalPayment(int userid)
        {
            decimal payment = 0;
            try
            {
                var query = String.Format("SELECT ISNULL(SUM(Total),0) AS Total FROM Payment WHERE UserId={0} AND StatusId=(SELECT Id FROM General WHERE TypeCode='PAYMENT' AND Code='NPY')", userid);
                payment = db.Query<decimal>(query).FirstOrDefault();
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
        #endregion getTotalPayment

        #region getHours
        public string getHours(int userId)
        {
            string hhmm = string.Empty;
            try
            {
                var query = String.Format(@"  	SELECT CONVERT(varchar(8), DATEADD(minute, 
	                                                ISNULL(DATEDIFF(MINUTE,
	                                                (	        
		                                                SELECT (CASE WHEN BookTimeIn<TimeIn THEN BookTimeIn ELSE TimeIn END) TimeIn FROM
		                                                (
			                                                SELECT
				                                                (SELECT MAX(TimeStamp) FROM Booking WHERE UserId={0} )BookTimeIn,
				                                                (SELECT MAX(Date) FROM RfidStamp WHERE UID = (SELECT RfidUid FROM RfidConfig WHERE CarNo = (SELECT CarNo FROM Users WHERE Id={0} ))  AND Status = 'IN') TimeIn
		                                                ) AS TimeIn
	                                                )
	                                                ,
	                                                (
		                                                SELECT MAX(Date) FROM RfidStamp WHERE UID = (SELECT RfidUid FROM RfidConfig WHERE CarNo = (SELECT CarNo FROM Users WHERE Id={0} )) AND Status = 'OUT'
	                                                )
                                                ),0), 0), 114)
                                                AS TotalHour", userId);

                hhmm = db.ExecuteScalar<String>(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return hhmm;
        }
        #endregion getHours
    }
}
