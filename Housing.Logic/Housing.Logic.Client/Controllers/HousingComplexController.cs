﻿using Housing.Logic.Domain;
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
            ApplicationLogic logic = new ApplicationLogic();

            return Request.CreateResponse(HttpStatusCode.OK, logic.InsertHousingComplex(housingComplex));
        }

        [HttpGet]
        [Route("get-all-housing-complexes")]
        public HttpResponseMessage GetAllHousingComplexes()
        {
            ApplicationLogic logic = new ApplicationLogic();

            List<HousingComplexDTO> housingComplexes = logic.GetHousingComplexes();
            return Request.CreateResponse(HttpStatusCode.OK, housingComplexes, "application/json");
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