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
    /// <summary>Utilizes application logic to return associate related items to UI</summary>
    [RoutePrefix("api/associates")]
    public class AssociateController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        //GET: api/associates
        /// <summary>Returns all associates in JSON format</summary>
        [HttpGet]
        public HttpResponseMessage GetAllAssociates()
        {

            List<AssociateDTO> a;
            try
            {
                if ((a = logic.GetAssociates()) != null)
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

        //GET: api/associates/id
        /// <summary>Returns an associates in JSON format</summary>
        [HttpGet]
        public HttpResponseMessage GetAllAssociates(string id)
        {
            AssociateDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))) != null)
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

        //Post: api/associate
        /// <summary>Insert an associate. Accepts AssociateDTO objects, returns bool for inserted.</summary>
        [HttpPost]
        public HttpResponseMessage AddAssociate([FromBody] AssociateDTO a)
        {
            if (a != null)
            {
                try
                {
                    if (logic.InsertAssociate(a))
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

        //PUT: api/associate/id
        /// <summary>
        /// Attempts to delete an associate with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assoc"></param>
        /// <returns>OK if successful</returns>
        [HttpPut]
        public HttpResponseMessage UpdateDriver(string id, [FromBody] AssociateDTO assoc)
        {
            if (assoc != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.UpdateAssociate(id, assoc))
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

        //Delete: api/associate/id
        /// <summary>
        /// Attemps to 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoveDriver(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (logic.DeleteAssociate(logic.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))))
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