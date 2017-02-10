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
    /// Utilizes application logic to return Gender related items to UI
    /// </summary>
    
    [RoutePrefix("api/gender")]
    public class GenderController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        ////Get: api/gender
        /// <summary>
        /// Gets a list of genders in json format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<GenderDTO> a;
            try
            {
                logger.Trace("testing get genders");
                logger.Log(LogLevel.Trace, "update log for genders get");
                if ((a = logic.GetGenders()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Retrieving Genders");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Genders failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Genders failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/gender/id
        /// <summary>
        /// Gets a gender in json format
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            GenderDTO a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "from gender get using id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if ((a = logic.GetGenders().FirstOrDefault(m => m.Name.Equals(id))) != null)
                    {
                        logger.Trace("testing values of a{0} ", a.Name);
                        logger.Log(LogLevel.Trace, "gender get using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                logger.Error("Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Gender failed");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        ////Post: api/gender
        /// <summary>
        /// Attempts to insert gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] GenderDTO gender)
        {
            if (gender != null)
            {
                try
                {
                    logger.Trace("testing insert gender, gender {0}", gender);
                    logger.Log(LogLevel.Trace, "Entered try block of gender insert");
                    if (logic.InsertGender(gender))
                    {
                        logger.Trace("Inserting Gender, gender {0}", gender);
                        logger.Log(LogLevel.Trace, "Gender Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Insertion of Gender did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Insert of Gender failed, handled exception gender {0} ", gender);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Insertion of Gender failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        ////Put: api/gender/id
        /// <summary>
        /// Attempts to update a gender
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] GenderDTO gender)
        {
            if (gender != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update Gender", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.UpdateGender(id, gender))
                    {
                        logger.Trace("Updating Gender", id.ToString());
                        logger.Log(LogLevel.Trace, "Gender Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Update of Gender did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Update of Gender failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Update of Gender failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        ////Delete: api/gender/id
        /// <summary>
        /// Attempts to delete a gender
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
                    logger.Trace("Delete Gender", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.DeleteGender(id))
                    {
                        logger.Trace("Deleting Gender", id.ToString());
                        logger.Log(LogLevel.Trace, "Gender deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Deletion of Gender did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Deletion of Gender failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Deletion of Gender failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}