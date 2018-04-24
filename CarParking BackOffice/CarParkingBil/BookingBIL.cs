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
    public class BookingBIL
    {
        BookingDAL bookingDAL = null;
        public BookingBIL()
        {
            bookingDAL = new BookingDAL();
        }

        #region insert
        public long insert(Booking booking)
        {
            long result = 0;

            try
            {
                // ถ้ามีข้อมูลการจองอยู่แล้วไม่ให้จองอีก
                var bookings = bookingDAL.getByUserId(Convert.ToInt32(booking.UserId));
                if(bookings!=null)
                {
                    throw new Exception("You have already reservation!");
                }
                else
                {
                    booking.TimeStamp = DateTime.Now;
                    result = bookingDAL.insert(booking);
                }
                
                if (result > 0)
                {
                    if (booking.StatusCode == "BK")
                        updateCarparkByStatus((int)booking.BuildingParkId, "BK");
                    
                }
                if (result<=0) throw new Exception("update failed!");
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion insert

        #region updateCarparkByStatus
        public bool updateCarparkByStatus(int buildingParkId,string statusCode)
        {
            BuildingparkDAL buildingparkDAL = new BuildingparkDAL();
            var buildingPark = buildingparkDAL.getById(buildingParkId);
            buildingPark.StatusId = new GeneralDAL().getByCodeAndTypeCode(statusCode, "BOOKING").Id;
            return buildingparkDAL.update(buildingPark);
        }
        #endregion updateCarparkByStatus

        #region update
        public bool update(Booking booking)
        {
            bool result = false;

            try
            {
                result = bookingDAL.update(booking);
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
                result = bookingDAL.delete(id);
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
        public Booking getById(int id)
        {
            Booking booking = null;
            try
            {
                booking = bookingDAL.getById(id);
            }
            catch
            {
                throw;
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
                bookings = bookingDAL.getAll();
            }
            catch
            {
                throw;
            }
            return bookings;
        }
        #endregion getAll
    }
}
