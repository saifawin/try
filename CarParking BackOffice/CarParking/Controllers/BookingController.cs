using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarParkingBIL;
using System.Web.Script.Serialization;
using CarParkingData;

namespace CarParking.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public string Index()
        {
            var bookings = new BookingBIL().getAll();
            return new JavaScriptSerializer().Serialize(bookings);
        }
        // GET: Booking/Details/5
        public string Details(int id)
        {
            var bookings= new BookingBIL().getById(id);
            return new JavaScriptSerializer().Serialize(bookings);
        }

        // POST: Booking/Create
        [HttpPost]
        public string Create(Booking booking)
        {
            try
            {
                // TODO: Add insert logic here
                var bookings = new BookingBIL().insert(booking);
                return new JavaScriptSerializer().Serialize(bookings);
            }
            catch(Exception ex)
            {

                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Booking/Edit
        [HttpPost]
        public string Edit(Booking booking)
        {
            try
            {
                var bookings = new BookingBIL().update(booking);
                return new JavaScriptSerializer().Serialize(bookings);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Booking/Delete
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var bookings = new BookingBIL().delete(id);
                return new JavaScriptSerializer().Serialize(bookings);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }
    }
}
