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
    /// Utilizes application logic to return HousingComplex related items to UI
    /// </summary>
    [RoutePrefix("api/housing-complexes")]
    public class HousingComplexController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();


        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingComplexDTO> a;
            try
            {
                logger.Trace("testing get complex");
                logger.Log(LogLevel.Trace, "Entering try block in complex get");
                if ((a = logic.GetHousingComplexes()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "update log for complex get");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingComplexDTO a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in get by id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))) != null)
                    {
                        logger.Trace("testing get by id", id.ToString());
                        logger.Log(LogLevel.Trace, "getting complex using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                logger.Error("Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex by id failed");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingComplexDTO a)
        {
            if (a != null)
            {
                try
                {
                    logger.Trace("testing insert complex, a{0}", a);
                    logger.Log(LogLevel.Trace, "Entered try block of complex insert");
                    if (logic.InsertHousingComplex(a))
                    {
                        logger.Trace("Inserting complex, a{0}", a);
                        logger.Log(LogLevel.Trace, "HousingComplex Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Insertion of complex did not occur, a{0} ", a);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Insert of complex failed, handled exception a{0} ", a);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Insertion of complex failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }      

        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingComplexDTO housingComplex)
        {
            if (housingComplex != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update complex", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.UpdateHousingComplex(id, housingComplex))
                    {
                        logger.Trace("Updating complex", id.ToString());
                        logger.Log(LogLevel.Trace, "Complex Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Update of complex did not occur, housingComplex {0}", housingComplex);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Update of complex failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Update of complex failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Delete HousingComplex", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.DeleteHousingComplex(id))
                    {
                        logger.Trace("Deleting HousingComplex", id.ToString());
                        logger.Log(LogLevel.Trace, "HousingComplex deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Deletion of complex did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Deletion of complex failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Deletion of complex failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}