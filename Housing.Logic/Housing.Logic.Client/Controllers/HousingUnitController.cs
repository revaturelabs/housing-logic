using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{
    [RoutePrefix("api/housing-units")]
    public class HousingUnitController : ApiController
    {
        [HttpPost]
        [Route("add-housing-unit")]
        public HttpResponseMessage AddHousingUnit([FromBody] HousingUnitDTO housingUnit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-housing-units")]
        public HttpResponseMessage GetAllHousingUnits()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<HousingUnitDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-housing-unit")]
        public HttpResponseMessage UpdateHousingUnit([FromBody] HousingUnitDTO housingUnit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-housing-unit")]
        public HttpResponseMessage RemoveHousingUnit([FromBody] HousingUnitDTO housingUnit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}