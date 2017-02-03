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
    [RoutePrefix("api/housing-data")]
    public class HousingDataController : ApiController
    {
        [HttpPost]
        [Route("add-housing-data")]
        public HttpResponseMessage AddHousingData([FromBody] HousingDataDTO housingData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("get-all-housing-data")]
        public HttpResponseMessage GetAllHousingData()
        {
            ApplicationLogic logic = new ApplicationLogic();

            List<HousingDataDTO> housingData = logic.GetHousingData();
            return Request.CreateResponse(HttpStatusCode.OK, housingData, "application/json");
        }

        [HttpPut]
        [Route("update-housing-data")]
        public HttpResponseMessage UpdateHousingData([FromBody] HousingDataDTO housingData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("remove-housing-data")]
        public HttpResponseMessage RemoveHousingData([FromBody] HousingDataDTO housingData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}