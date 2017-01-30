using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{
    [RoutePrefix("api/genders")]
    public class GenderController : ApiController
    {
        [HttpPost]
        [Route("add-gender")]
        public HttpResponseMessage AddGender([FromBody] GenderDTO gender)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-genders")]
        public HttpResponseMessage GetAllGenders()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<GenderDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-gender")]
        public HttpResponseMessage UpdateGender([FromBody] GenderDTO gender)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-gender")]
        public HttpResponseMessage RemoveGender([FromBody] GenderDTO gender)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}