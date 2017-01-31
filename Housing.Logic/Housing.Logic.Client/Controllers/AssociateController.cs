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

        [HttpPost]
        [Route("add-associate")]
        public HttpResponseMessage AddAssociate([FromBody] AssociateDTO associate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        /// <summary>Returns all associates in JSON format</summary>
        [HttpGet]
        [Route("get-all-associates")]
        public HttpResponseMessage GetAllAssociates()
        {
            ApplicationLogic logic = new ApplicationLogic();

            List<AssociateDTO> allAssociates = logic.GetAssociates();
            return Request.CreateResponse(HttpStatusCode.OK, allAssociates, "application/json");
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