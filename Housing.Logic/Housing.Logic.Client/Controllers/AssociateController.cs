using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{
    [RoutePrefix("api/associates")]
    public class AssociateController : ApiController
    {
        [HttpPost]
        [Route("add-associate")]
        public HttpResponseMessage AddAssociate([FromBody] AssociateDTO associate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-associates")]
        public HttpResponseMessage GetAllAssociates()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<AssociateDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-associate")]
        public HttpResponseMessage UpdateDriver([FromBody] AssociateDTO associate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-associate")]
        public HttpResponseMessage RemoveDriver([FromBody] AssociateDTO associate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

    }
}