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
    /// Utilizes application logic to return HousingData related items to UI
    /// </summary>
    [RoutePrefix("api/housingdata")]
    public class HousingDataController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Get: api/housingdata
        /// <summary>
        /// Gets list of housing data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingDataDTO> a;
            try
            {
                logger.Trace("testing get housing data");
                logger.Log(LogLevel.Trace, "Entering try block in housing data get");
                if ((a = logic.GetHousingData()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Getting Housing Data");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/housingdata/id
        /// <summary>
        /// Gets housing data with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingDataDTO a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in get by id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))) != null)
                    {
                        logger.Trace("testing get by id", id.ToString());
                        logger.Log(LogLevel.Trace, "getting housing data using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                logger.Error("Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data by id failed, a{0} ", id);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("get-housing-data-by-date")]
        public HttpResponseMessage HousingDataByDate(HousingDataRequestDTO housingDataRequest)
        {
            List<HousingDataDTO> hd;
            try
            {
                if ((hd = logic.GetHousingDataByDate(housingDataRequest)) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, hd, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Post: api/housingdata
        /// <summary>
        /// Attempts to insert a new housing data
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] HousingDataDTO a)
        {
            if (a != null)
            {
                try
                {
                    logger.Trace("testing insert housing data, a {0}", a);
                    logger.Log(LogLevel.Trace, "Entered try block of housing data insert");
                    if (logic.InsertHousingData(a))
                    {
                        logger.Trace("Inserting housing data, a {0}", a);
                        logger.Log(LogLevel.Trace, "HousingData Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Insertion of housing data did not occur, a {0} ", a);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Insert of housing data failed, handled exception a {0} ", a);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Insertion of housing data failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }                

        //Put: api/housingdata/id
        /// <summary>
        /// Attempts to update given housing data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="housingData"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] HousingDataDTO housingData)
        {
            if (housingData != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update housing data", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.UpdateHousingData(id, housingData))
                    {
                        logger.Trace("Updating housing data", id.ToString());
                        logger.Log(LogLevel.Trace, "Housing data Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Update of housing data did not occur, housingData{0}", housingData.HousingDataAltId);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Update of housing data failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Update of housing data failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Delete: api/housingdata/id
        /// <summary>
        /// Attempts to delete given housing data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Delete HousingData", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.DeleteHousingData(id))
                    {
                        logger.Trace("Deleting HousingData", id.ToString());
                        logger.Log(LogLevel.Trace, "HousingData deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Deletion of housing data did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Deletion of housing data failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Deletion of housing data failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}