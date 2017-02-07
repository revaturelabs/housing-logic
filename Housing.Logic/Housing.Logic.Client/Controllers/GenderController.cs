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
    /// Utilizes application logic to return Gender related items to UI
    /// </summary>
    [RoutePrefix("api/genders")]
    public class GenderController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        ////Get: api/gender
        /// <summary>
        /// Gets a list of genders in json format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<GenderDTO> a;
            try
            {
                if ((a = logic.GetGenders()) != null)
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

        //Get: api/gender/id
        /// <summary>
        /// Gets a gender in json format
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            GenderDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetGenders().FirstOrDefault(m => m.Name.Equals(id))) != null)
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

        ////Post: api/gender
        /// <summary>
        /// Attempts to insert gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] GenderDTO gender)
        {
            if (gender != null)
            {
                try
                {
                    if (logic.InsertGender(gender))
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

        ////Put: api/gender/id
        /// <summary>
        /// Attempts to update a gender
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] GenderDTO gender)
        {
            if (gender != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.UpdateGender(id, gender))
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

        ////Delete: api/gender/id
        /// <summary>
        /// Attempts to delete a gender
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
                    if (logic.DeleteGender(id))
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