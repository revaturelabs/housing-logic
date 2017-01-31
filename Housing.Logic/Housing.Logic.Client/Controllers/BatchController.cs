using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{
    [RoutePrefix("api/batches")]
    public class BatchController : ApiController
    {
        [HttpPost]
        [Route("add-batch")]
        public HttpResponseMessage AddBatch([FromBody] BatchDTO batch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-batches")]
        public HttpResponseMessage GetAllBatches()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<BatchDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-batch")]
        public HttpResponseMessage UpdateBatch([FromBody] BatchDTO batch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-batch")]
        public HttpResponseMessage RemoveBatch([FromBody] BatchDTO batch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}