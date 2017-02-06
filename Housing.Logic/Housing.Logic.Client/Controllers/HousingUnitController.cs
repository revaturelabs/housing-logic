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
    [RoutePrefix("api/housing-units")]
    public class HousingUnitController : ApiController
    {
        [HttpPost]
        [Route("add-housing-unit")]
        public HttpResponseMessage AddHousingUnit([FromBody] HousingUnitDTO housingUnit)
        {
            ApplicationLogic logic = new ApplicationLogic();

            return Request.CreateResponse(HttpStatusCode.OK, logic.InsertHousingUnit(housingUnit));
        }

        [HttpGet]
        [Route("get-all-housing-units")]
        public HttpResponseMessage GetAllHousingUnits()
        {
            ApplicationLogic logic = new ApplicationLogic();

            List<HousingUnitDTO> housingUnits = logic.GetHousingUnits();
            return Request.CreateResponse(HttpStatusCode.OK, housingUnits, "application/json");
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