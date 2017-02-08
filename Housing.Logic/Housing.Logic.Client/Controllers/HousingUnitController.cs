using Housing.Logic.Domain;
using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{


    /// <summary>
    /// Utilizes application logic to return HousingUnit related items to UI
    /// </summary>
    [RoutePrefix("api/housingunit")]
    public class HousingUnitController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        //Get: api/housingunit
        /// <summary>
        /// Gets all housing units
        /// </summary>
        /// <returns>List of HousingUnitDTO's</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingUnitDTO> a;
            try
            {
                if ((a = logic.GetHousingUnits()) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/housingunit/id
        /// <summary>
        /// Gets housing unit with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Requested housingUnitDto or error code</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingUnitDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))) != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/housingunit/available
        /// <summary>
        /// Gets all Housing units with available beds
        /// </summary>
        /// <returns>status code and a list of units if successful</returns>
        [HttpGet]
        [Route("available")]
        public HttpResponseMessage GetUnitsWithAvailableBeds()
        {
            List<HousingUnitDTO> a;
            try
            {
                if ((a = logic.GetHousingUnitsWithAvailableBeds()) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Post: api/housingunit
        /// <summary>
        /// Inserts housingunit into db
        /// </summary>
        /// <param name="housingUnit"></param>
        /// <returns>success/failure status code</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingUnitDTO housingUnit)
        {
            if (housingUnit != null)
            {
                try
                {
                    if (logic.InsertHousingUnit(housingUnit))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Put: api/housingunit/id
        /// <summary>
        /// Attempts to update given housing unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="housingUnit"></param>
        /// <returns>success/failure status code</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingUnitDTO housingUnit)
        {
            if (housingUnit != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.UpdateHousingUnit(id, housingUnit))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Delete: api/housingunit/id
        /// <summary>
        /// Attemp to delete given housing unit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>success/failure status code</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.DeleteHousingUnit(id))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}