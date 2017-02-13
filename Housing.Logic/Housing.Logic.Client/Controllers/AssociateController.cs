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
    /// <summary>Utilizes application logic to return associate related items to UI</summary>
    [RoutePrefix("api/associate")]
    public class AssociateController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //GET: api/associate
        /// <summary>Returns all associates in JSON format</summary>
        [HttpGet]
        public HttpResponseMessage Get()
        {

            List<AssociateDTO> a;
            try
            {
                logger.Trace("testing get");
                logger.Log(LogLevel.Trace, "Entered try block for associate get");
                if ((a = logic.GetAssociates()) != null)
                {
                    logger.Trace("sending request from get");
                    logger.Log(LogLevel.Trace, "update log from associate get on success");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Trace("testing get");
                logger.Log(LogLevel.Trace, "update log from associate get internal server error");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e,"testing get with exception handling");
                logger.Log(LogLevel.Trace, "update log from associate get on handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //GET: api/associate/id
        /// <summary>Returns an associates in JSON format</summary>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            AssociateDTO a;
            try
            {
                logger.Trace("testing get id", id.ToString());
                logger.Log(LogLevel.Trace, "from associate get using id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))) != null)
                    {
                        logger.Trace("testing values of a{0} ", a.Email);
                        logger.Log(LogLevel.Trace, "associate get using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }                    
                }
                logger.Error("Error occured in Associate Controller");
                logger.Log(LogLevel.Error, "Get of Associate by id failed, null or whitespace");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Associate Controller");
                logger.Log(LogLevel.Error, "Get of Associate by id failed, exception handled");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/associate/get-unassigned
        /// <summary>
        /// Gets all associates not assigned to a HousingUnit
        /// </summary>
        /// <returns>status code and a list of associated if successful</returns>
        [HttpGet]
        [Route("get-unassigned")]
        public HttpResponseMessage GetUnassigned()
        {
            List<AssociateDTO> a;
            try
            {
                if ((a = logic.GetUnassignedAssociates()) != null)
                {
                    logger.Trace("testing get on associates not assigned housing");
                    logger.Log(LogLevel.Trace, "Retrieved associates who are not assigned housing");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Associate Controller");
                logger.Log(LogLevel.Error, "Retrieval of Associate not assigned housing failed");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Associate Controller");
                logger.Log(LogLevel.Error, "Retrieval of Associates not assigned housing failed, exception handled");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Post: api/associate
        /// <summary>Insert an associate. Accepts AssociateDTO objects, returns bool for inserted.</summary>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] AssociateDTO a)
        {
            if (a != null)
            {
                try
                {
                    logger.Debug("trying to insert Associate, a{0} ", a);
                    logger.Log(LogLevel.Debug, "Entered try block");
                    if (logic.InsertAssociate(a))
                    {
                        logger.Debug("Inserting Associate, a{0} ", a);
                        logger.Log(LogLevel.Debug, "Associate inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Associate controller");
                        logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Associate controller");
                    logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate controller");
            logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //PUT: api/associate/id
        /// <summary>
        /// Attempts to delete an associate with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assoc"></param>
        /// <returns>OK if successful</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] AssociateDTO assoc)
        {
            if (assoc != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Debug("trying to update Associate, assoc{0} ", assoc);
                    logger.Log(LogLevel.Debug, "Entered try block updating Associate");
                    if (logic.UpdateAssociate(id, assoc))
                    {
                        logger.Debug("Updating Associate, assoc{0} ", assoc);
                        logger.Log(LogLevel.Debug, "Associate Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Associate controller");
                        logger.Log(LogLevel.Error, "Edit of Associate failed, assoc{0} ", assoc);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Associate controller");
                    logger.Log(LogLevel.Error, "Edit of Associate failed, exception was handled ");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate controller");
            logger.Log(LogLevel.Error, "Edit of Associate failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Delete: api/associate/id
        /// <summary>
        /// Attemps to 
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
                    logger.Debug("trying to delete Associate ");
                    logger.Log(LogLevel.Debug, "Entered try block deleting Associate");
                    if (logic.DeleteAssociate(id))
                    {
                        logger.Debug("Deleting Associate ");
                        logger.Log(LogLevel.Debug, "Associate Deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("trying to delete Associate ");
                        logger.Log(LogLevel.Error, "Deletion of Associate did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Associate Controller ");
                    logger.Log(LogLevel.Error, "Failed to Delete Associate");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate Controller ");
            logger.Log(LogLevel.Error, "Failed to Delete Associate, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}