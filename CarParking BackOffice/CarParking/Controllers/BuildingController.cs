using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarParkingBIL;
using System.Web.Script.Serialization;
using CarParkingData;
using CarParkingDAL;

namespace CarParking.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public string Index()
        {
            var building = new BuildingBIL().getAll();
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/BuildingPark/1
        public string BuildingPark(int id)
        {
            var building = new BuildingparkBIL().getByBuildingClassId(id);
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/BuildingParkAll/1
        public string BuildingParkAll(int id)
        {
            var building = new BuildingparkBIL().getByBuildingAllByClassId(id);
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/BuildingClass/1
        public string BuildingClass(int id)
        {
            var building = new BuildingclassBIL().getByBuildingId(id);
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/countAllParkAvailable
        public string countAllParkAvailable()
        {
            var building = new BuildingparkBIL().countAllParkAvailable();
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/countAllClassAvailable/1
        public string countAllClassAvailable(int id)
        {
            var building = new BuildingclassBIL().countAllClassAvailable(id);
            return new JavaScriptSerializer().Serialize(building);
        }
        // GET: Building/Details/5
        public string Details(int id)
        {
            var building = new BuildingBIL().getById(id);
            return new JavaScriptSerializer().Serialize(building);
        }

        // POST: Building/Create
        [HttpPost]
        public string Create(Building building)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new BuildingBIL().insert(building);
                return new JavaScriptSerializer().Serialize(building);
            }
            catch (Exception ex)
            {

                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }
        // POST: Building/Edit
        [HttpPost]
        public string Edit(Building building)
        {
            try
            {
                var buildings = new BuildingBIL().update(building);
                return new JavaScriptSerializer().Serialize(buildings);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        static int countSensor = 0;
        // GET: Building/SaveParking?buildingParkId=1&code=AV&sensor=1
        public string SaveParking(int buildingParkId, string code, string sensor)
        {
            try
            {
                var buildingParks = new BuildingparkBIL().getById(buildingParkId);
                buildingParks.StatusId = new GeneralDAL().getByCodeAndTypeCode(code, "BOOKING").Id;
                var result = new BuildingparkBIL().update(buildingParks);
                return new JavaScriptSerializer().Serialize(result);

                //if (code == "NAV")
                //{
                //    if (sensor == "1")
                //        countSensor = 1;
                //    else if (sensor == "2")
                //        countSensor += 1;

                //    if (countSensor >= 2)
                //    {
                //        var buildingParks = new BuildingparkBIL().getById(buildingParkId);
                //        buildingParks.StatusId = new GeneralDAL().getByCodeAndTypeCode(code, "BOOKING").Id;
                //        var result = new BuildingparkBIL().update(buildingParks);
                //        countSensor = 0;
                //       //return new JavaScriptSerializer().Serialize(result);
                //    }
                //}
                //else if(code == "AV" && countSensor==0)
                //{
                //    var buildingParks = new BuildingparkBIL().getById(buildingParkId);
                //    buildingParks.StatusId = new GeneralDAL().getByCodeAndTypeCode(code, "BOOKING").Id;
                //    var result = new BuildingparkBIL().update(buildingParks);
                //    countSensor = 0;
                //    //return new JavaScriptSerializer().Serialize(result);
                //}
                //return new JavaScriptSerializer().Serialize(countSensor);
            }
            catch (Exception ex)
            {
                ExceptionHandler Exception = new ExceptionHandler();
                Exception.Code = "01";
                Exception.Message = ex.Message;
                return new JavaScriptSerializer().Serialize(Exception);
            }
        }

        // POST: Building/Delete
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var building = new BuildingBIL().delete(id);
                return new JavaScriptSerializer().Serialize(building);
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
