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
    public class UsersController : Controller
    {
        // GET: Users
        public string Index()
        {
            var users = new UsersBIL().getAll();
            return new JavaScriptSerializer().Serialize(users);
        }
        // GET: Users Login
        public string Login(string username,string password)
        {
            var users = new UsersBIL().getLogin(username, password);
            return new JavaScriptSerializer().Serialize(users);
        }
        // GET: Users/Details/5
        public string Details(int id)
        {
            var users= new UsersBIL().getById(id);
            return new JavaScriptSerializer().Serialize(users);
        }

        // POST: Users/Create
        [HttpPost]
        public string Create(Users user)
        {
            try
            {
                // TODO: Add insert logic here
                var users = new UsersBIL().insert(user);
                return new JavaScriptSerializer().Serialize(users);
            }
            catch(Exception ex)
            {

                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Users/Edit
        [HttpPost]
        public string Edit(Users user)
        {
            try
            {
                var users = new UsersBIL().update(user);
                return new JavaScriptSerializer().Serialize(users);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Users/Delete
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var users = new UsersBIL().delete(id);
                return new JavaScriptSerializer().Serialize(users);
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
