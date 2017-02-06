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
    [RoutePrefix("api/batches")]
    public class BatchController : ApiController
    {
        [HttpPost]
        [Route("add-batch")]
        public HttpResponseMessage AddBatch([FromBody] BatchDTO batch)
        {
            ApplicationLogic logic = new ApplicationLogic();

            return Request.CreateResponse(HttpStatusCode.OK, logic.InsertBatch(batch));
        }

        [HttpGet]
        [Route("get-all-batches")]
        public HttpResponseMessage GetAllBatches()
        {
            ApplicationLogic logic = new ApplicationLogic();

            List<BatchDTO> batches = logic.GetBatches();
            return Request.CreateResponse(HttpStatusCode.OK, batches, "application/json");
        }

        [HttpPut]
        [Route("update-batch")]
        public HttpResponseMessage UpdateBatch([FromBody] BatchDTO batch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpDelete]
        [Route("remove-batch")]
        public HttpResponseMessage RemoveBatch([FromBody] BatchDTO batch)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}