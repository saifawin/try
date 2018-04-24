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
    public class PaymentController : Controller
    {
        // GET: Payment
        public string Index()
        {
            var payment = new PaymentBIL().getAll();
            return new JavaScriptSerializer().Serialize(payment);
        }
        // GET: Payment/Details/5
        public string Details(int id)
        {
            var payment= new PaymentBIL().getById(id);
            return new JavaScriptSerializer().Serialize(payment);
        }
        // GET: Payment/Save?userId=1
        public string Save(int userId,string cardNo)
        {
            try
            {
                var result = new PaymentBIL().update(userId, cardNo);
                return new JavaScriptSerializer().Serialize(result);
            }
            catch (Exception ex)
            {

                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
           
        }
        // GET: Payment/GetTotalPayment?userId=1
        public string GetTotalPayment(int userId)
        {
            var result = new PaymentBIL().getTotalPayment(userId);
            return new JavaScriptSerializer().Serialize(result);
        }

        // GET: Payment/GetHour?userId=1
        public string GetHour(int userId)
        {
            var result = new PaymentBIL().getHours(userId);
            return new JavaScriptSerializer().Serialize(result);
        }
        // POST: Payment/Create
        [HttpPost]
        public string Create(Payment payment)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new PaymentBIL().insert(payment);
                return new JavaScriptSerializer().Serialize(result);
            }
            catch(Exception ex)
            {

                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Payment/Edit
        [HttpPost]
        public string Edit(Payment payment)
        {
            try
            {
                var result = new PaymentBIL().update(payment);
                return new JavaScriptSerializer().Serialize(result);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Payment/Delete
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var payment = new PaymentBIL().delete(id);
                return new JavaScriptSerializer().Serialize(payment);
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
