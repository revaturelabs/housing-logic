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
    /// Utilizes application logic to return HousingData related items to UI
    /// </summary>
    [RoutePrefix("api/housingdata")]
    public class HousingDataController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        //Get: api/housingdata
        /// <summary>
        /// Gets list of housing data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingDataDTO> a;
            try
            {
                if ((a = logic.GetHousingData()) != null)
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

        //Get: api/housingdata/id
        /// <summary>
        /// Gets housing data with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingDataDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))) != null)
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

        //Post: api/housingdata
        /// <summary>
        /// Attempts to insert a new housing data
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingDataDTO a)
        {
            if (a != null)
            {
                try
                {
                    if (logic.InsertHousingData(a))
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

        //Put: api/housingdata/id
        /// <summary>
        /// Attempts to update given housing data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="housingData"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingDataDTO housingData)
        {
            if (housingData != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.UpdateHousingData(id, housingData))
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

        //Delete: api/housingdata/id
        /// <summary>
        /// Attempts to delete given housing data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.DeleteHousingData(id))
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