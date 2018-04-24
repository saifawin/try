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
    public class RfidStampController : Controller
    {
        // GET: RfidStamp
        public string Index()
        {
            var rfidStamp = new RfidStampBIL().getAll();
            return new JavaScriptSerializer().Serialize(rfidStamp);
        }
        // GET: RfidStamp/Details/5
        public string Details(int id)
        {
            var rfidStamp= new RfidStampBIL().getById(id);
            return new JavaScriptSerializer().Serialize(rfidStamp);
        }
        // GET: RfidStamp/Save?uid=12225
        public string Save(string uid)
        {
            RfidStamp rfidStamp = new RfidStamp();
            rfidStamp.UID = uid;
            var result = new RfidStampBIL().insert(rfidStamp);
            return new JavaScriptSerializer().Serialize(result);
        }
        // POST: RfidStamp/Create
        [HttpPost]
        public string Create(RfidStamp rfidStamp)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new RfidStampBIL().insert(rfidStamp);
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

        // POST: RfidStamp/Edit
        [HttpPost]
        public string Edit(RfidStamp rfidStamp)
        {
            try
            {
                var result = new RfidStampBIL().update(rfidStamp);
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

        // POST: RfidStamp/Delete
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var rfidStamp = new RfidStampBIL().delete(id);
                return new JavaScriptSerializer().Serialize(rfidStamp);
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
