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
    /// Utilizes application logic to return Batch related items to UI
    /// </summary>
    [RoutePrefix("api/batch")]
    public class BatchController : ApiController
    {
        private ApplicationLogic logic = new ApplicationLogic();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Get: api/batch
        /// <summary>
        /// Gets batches in json format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<BatchDTO> a;
            try
            {
                logger.Trace("testing get batches");
                logger.Log(LogLevel.Trace, "update log for batch get");
                if ((a = logic.GetBatches()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Retrieving Batches");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Get: api/batch/id
        /// <summary>
        /// gets a batch with given id in json format
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string Id)
        {
            BatchDTO a;
            try
            {
                logger.Trace("testing get by id", Id.ToString());
                logger.Log(LogLevel.Trace, "from batch get using id");
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    if ((a = logic.GetBatches().FirstOrDefault(m => m.Name.Equals(Id))) != null)
                    {
                        logger.Trace("testing values of a{0} ", a.Name);
                        logger.Log(LogLevel.Trace, "batch get using id");
                        return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                    }
                }
                logger.Error("Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed ");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, handled exception ");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        //Post: api/batch
        /// <summary>
        /// Attempts to insert a batch
        /// </summary>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] BatchDTO batch)
        {
            if (batch != null && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("testing insert batch, batch{0}", batch);
                    logger.Log(LogLevel.Trace, "Entered try block for batch insert");
                    if (logic.InsertBatch(batch))
                    {
                        logger.Trace("inserting batch, batch{0}", batch);
                        logger.Log(LogLevel.Trace, "batch inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Insertion of Batch did not occur, batch{0} ", batch);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Insert of Batch failed, handled exception batch{0} ", batch);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Insertion of Batch failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Put: api/batch/id
        /// <summary>
        /// Attempts to update a batch
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(string Id, [FromBody] BatchDTO batch)
        {
            if (batch != null && !string.IsNullOrWhiteSpace(Id) && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("Update Batch", Id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.UpdateBatch(Id, batch))
                    {
                        logger.Trace("Batch update", Id.ToString());
                        logger.Log(LogLevel.Trace, "Updating the Batch");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Update of Batch did not occur, batch{0} ", batch);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Update of Batch failed, handled exception batch{0} ", batch);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Update of Batch failed, null or whitespace batch{0} ", batch);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //Delete: api/batch/id
        /// <summary>
        /// Attempts to delete a batch
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
                    logger.Trace("Delete Batch", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (logic.DeleteBatch(id))
                    {
                        logger.Trace("Deleting Batch", id.ToString());
                        logger.Log(LogLevel.Trace, "Batch Deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Deletion of Batch did not occur ");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Deletion of Batch failed due to a handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Deletion of Batch failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}