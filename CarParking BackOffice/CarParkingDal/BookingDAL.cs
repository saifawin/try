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
    public class BookingDAL
    {
        private IDbConnection db = null;
        public BookingDAL()
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            db = DbHelper.getSqlConnection();
            //ถ้าปิดอยู่ให้เปิดการทำงาน
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        #region insert
        public long insert(Booking booking)
        {
            long result = 0;

            try
            {
                result = db.Insert(booking);
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
        public bool update(Booking booking)
        {
            bool result = false;

            try
            {
                result = db.Update(booking);
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
            Booking booking = new Booking();

            try
            {
                booking.Id = id;
                result = db.Delete(booking);
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
        public Booking getById(int id)
        {
            Booking booking = null;
            try
            {
                booking = db.Get<Booking>(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return booking;
        }
        #endregion getById

        #region getAll
        public IEnumerable<Booking> getAll()
        {
            IEnumerable<Booking> bookings = null;
            try
            {
                bookings = db.GetAll<Booking>();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Close();
            }
            return bookings;
        }
        #endregion getAll

        #region getByUserId
        public Booking getByUserId(int userId)
        {
            Booking booking = null;
            try
            {
                var query = String.Format("SELECT * FROM Booking WHERE UserId={0}", userId);
                booking = db.Query<Booking>(query).FirstOrDefault();
            }
            catch(Exception ex)
            {
            
            }
            finally
            {
                db.Close();
            }
            return booking;
        }
        #endregion getByUserId
    }
}
