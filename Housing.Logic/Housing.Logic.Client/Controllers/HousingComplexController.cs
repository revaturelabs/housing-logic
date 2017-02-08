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
    /// Utilizes application logic to return HousingComplex related items to UI
    /// </summary>
    [RoutePrefix("api/housingcomplex")]
    public class HousingComplexController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        //Get: api/housingcomplex
        /// <summary>
        /// Gets a list of housing complexes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingComplexDTO> a;
            try
            {
                if ((a = logic.GetHousingComplexes()) != null)
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

        //Get: api/housingcomplex/id
        /// <summary>
        /// Get a housing complex with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingComplexDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))) != null)
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

        //Post: api/housingcomplex
        /// <summary>
        /// Attempts to insert housing complex
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingComplexDTO a)
        {
            if (a != null)
            {
                try
                {
                    if (logic.InsertHousingComplex(a))
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

        //Put: api/housingcomplex/id
        /// <summary>
        /// Attempts to update given housing complex
        /// </summary>
        /// <param name="id"></param>
        /// <param name="housingComplex"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingComplexDTO housingComplex)
        {
            if (housingComplex != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.UpdateHousingComplex(id, housingComplex))
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

        //Delete: api/housingcomplex/id
        /// <summary>
        /// Attempt to delete given housing complex
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
                    if (logic.DeleteHousingComplex(id))
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