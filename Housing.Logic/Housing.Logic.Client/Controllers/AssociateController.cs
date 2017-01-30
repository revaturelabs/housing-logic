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
        [HttpGet]
        [Route("get-all-associates")]
        public HttpResponseMessage GetAllAssociates()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<AssociateDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-associate")]
        public HttpResponseMessage UpdateDriver([FromBody] UserDTO driver)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminLogic.ModifyDriver(driver));
        }

        [HttpPost]
        [Route("remove-associate")]
        public HttpResponseMessage RemoveDriver([FromBody] UserDTO driver)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminLogic.DeleteDriver(driver));
        }

    }
}