using Housing.Logic.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{
    [RoutePrefix("api/housing-complexes")]
    public class HousingComplexController : ApiController
    {
        [HttpPost]
        [Route("add-housing-complex")]
        public HttpResponseMessage AddHousingComplex([FromBody] HousingComplexDTO housingComplex)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-housing-complexes")]
        public HttpResponseMessage GetAllHousingComplexes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new List<HousingComplexDTO>(), "application/json");
        }

        [HttpPut]
        [Route("update-housing-complex")]
        public HttpResponseMessage UpdateHousingComplex([FromBody] HousingComplexDTO housingComplex)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-housing-complex")]
        public HttpResponseMessage RemoveHousingComplex([FromBody] HousingComplexDTO housingComplex)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}