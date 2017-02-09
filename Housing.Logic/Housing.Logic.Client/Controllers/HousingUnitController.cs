using Housing.Logic.Domain;
using Housing.Logic.Domain.DataTransferObjects;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Logic.Client.Controllers
{


    /// <summary>
    /// Utilizes application logic to return HousingUnit related items to UI
    /// </summary>
    [RoutePrefix("api/housing-units")]
    public class HousingUnitController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingUnitDTO> a;
            try
            {
                logger.Trace("testing get housing units");
                logger.Log(LogLevel.Trace, "Entering try block in housing units get");
                if ((a = logic.GetHousingUnits()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Getting Housing Units");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing units failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing units failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingUnitDTO a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in housing unit get by id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))) != null)
                    {
                        logger.Trace("testing get by id", id.ToString());
                        logger.Log(LogLevel.Trace, "getting housing unit using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                logger.Error("Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing unit by id failed, a{0} ", id);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing unit by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingUnitDTO housingUnit)
        {
            if (housingUnit != null)
            {
                try
                {
                    logger.Trace("testing insert housing unit, housingUnit{0}", housingUnit.HousingUnitName);
                    logger.Log(LogLevel.Trace, "Entered try block of housing unit insert");
                    if (logic.InsertHousingUnit(housingUnit))
                    {
                        logger.Trace("Inserting housing unit, housingUnit{0}", housingUnit);
                        logger.Log(LogLevel.Trace, "HousingUnit Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Insertion of housing unit did not occur, housingUnit{0} ", housingUnit);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Insert of housing unit failed, handled exception housingUnit{0} ", housingUnit);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Insertion of housing unit failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingUnitDTO housingUnit)
        {
            if (housingUnit != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update housing unit", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.UpdateHousingUnit(id, housingUnit))
                    {
                        logger.Trace("Updating housing unit", id.ToString());
                        logger.Log(LogLevel.Trace, "Housing unit Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Update of housing unit did not occur, housingUnit{0}", housingUnit);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Update of housing unit failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Update of housing unit failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Delete HousingUnit", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.DeleteHousingUnit(id))
                    {
                        logger.Trace("Deleting HousingUnit", id.ToString());
                        logger.Log(LogLevel.Trace, "Housingnit deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Deletion of housing unit did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Deletion of housing unit failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Deletion of housing unit failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}