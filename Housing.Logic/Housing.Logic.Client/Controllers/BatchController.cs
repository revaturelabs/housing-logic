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
    /// Utilizes application logic to return Batch related items to UI
    /// </summary>
    [RoutePrefix("api/batch")]
    public class BatchController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();

        //Get: api/batch
        /// <summary>
        /// Gets batches in json format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<BatchDTO> a;
            try
            {
                if ((a = logic.GetBatches()) != null)
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

        //Get: api/batch/id
        /// <summary>
        /// gets a batch with given id in json format
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string Id)
        {
            BatchDTO a;
            try
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    if ((a = logic.GetBatches().FirstOrDefault(m => m.Name.Equals(Id))) != null)
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

        //Post: api/batch
        /// <summary>
        /// Attempts to insert a batch
        /// </summary>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] BatchDTO batch)
        {
            if (batch != null)
            {
                try
                {
                    if (logic.InsertBatch(batch))
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

        //Put: api/batch/id
        /// <summary>
        /// Attempts to update a batch
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string Id, [FromBody] BatchDTO batch)
        {
            if (batch != null && !string.IsNullOrWhiteSpace(Id))
            {
                try
                {
                    if (logic.UpdateBatch(Id, batch))
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

        //Delete: api/batch/id
        /// <summary>
        /// Attempts to delete a batch
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
                    if (logic.DeleteBatch(id))
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