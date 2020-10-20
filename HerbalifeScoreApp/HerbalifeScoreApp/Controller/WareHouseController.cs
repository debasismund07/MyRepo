using HerbalifeScoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HerbalifeScoreApp.Controller
{
    public class WareHouseController : ApiController
    {
        Warehouse warehouseObject = new Warehouse();

        public HttpResponseMessage GetWareHouses(int pageNumber, int noofRows)
        {
            try
            {
                var result = warehouseObject.SelectWareHouses(pageNumber, noofRows, out int noOfRecords);
                return result.TotalItemCount > 0
? Request.CreateResponse(HttpStatusCode.OK, new { result, noOfRecords })
: Request.CreateResponse(HttpStatusCode.NoContent, "Warehouse data not added yet");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong.Try again later");
            }

        }

        [Route("api/WareHouse/GetWareHouse")]
        [HttpPost]
        public HttpResponseMessage GetDuplicateWareHouse(Warehouse warehouse)
        {
            try
            {
                int result = warehouse.SelectWareHouse(warehouse.WHCode);
                return result == 1
      ? Request.CreateResponse(HttpStatusCode.OK, "Warehouse code already exists")
      : Request.CreateResponse(HttpStatusCode.OK, "Warehouse code does not exist");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong.Try again later");
            }
        }

        [Route("api/WareHouse/Search")]
        [HttpGet]

        public HttpResponseMessage SearchWareHouses(string searchData, int pageNumber, int noofRows)
        {
            try
            {
                var result = warehouseObject.SearchWareHouse(searchData, pageNumber, noofRows, out int noOfRecords);
                return result.TotalItemCount > 0
                 ? Request.CreateResponse(HttpStatusCode.OK, new { result, noOfRecords })
                 : Request.CreateResponse(HttpStatusCode.NoContent, "Warehouse not available");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong.Try again later");
            }

        }

        public HttpResponseMessage PostWareHouse(Warehouse warehouseData)
        {
            try
            {
                int result = warehouseObject.InsertWareHouse(warehouseData);
                return result > 0
                    ? Request.CreateResponse(HttpStatusCode.Created, "Warehouse saved successfully")
                    : Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong. Try again later");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong.Try again later");
            }

        }
    }
}
