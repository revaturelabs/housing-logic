using Housing.Logic.Domain.DataTransferObjects;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain
{
    /// <summary>Class is used for performing any logic needed on data acquired from data access</summary>
    public class ApplicationLogic
    {
        private DataAccess data = new DataAccess();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Associate Related

        /// <summary>
        /// Calls dataAccess and gets specified list
        /// </summary>
        /// <returns>list of associate dtos</returns>
        public List<AssociateDTO> GetAssociates()
        {
            var allAssociates = data.GetItemsFromApi<List<AssociateDTO>>("Associate").Result;
            logger.Info("Get Associate logic");
            logger.Log(LogLevel.Info, "Associate Get returned allAssociates {}", allAssociates);
            return allAssociates;
        }

        public bool InsertAssociate(AssociateDTO associateToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<AssociateDTO>(associateToInsert, "Associate").Result;
            logger.Info("Insert Associate logic");
            logger.Log(LogLevel.Info, "Associate Insertion result bit {}", insertionResult);
            return insertionResult;
        }

        public bool UpdateAssociate(string Id, AssociateDTO assoc)
        {
            logger.Info("Update Associate logic");
            logger.Log(LogLevel.Info, "Associate Update result bit {}", data.UpdateItemUsingApi<AssociateDTO>(assoc, "associate", Id).Result);
            return data.UpdateItemUsingApi<AssociateDTO>(assoc, "associate", Id).Result;
        }

        /// <summary>
        /// call delete from dataAccess
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if success, else returns false</returns>
        public bool DeleteAssociate(string assoc)
        {
            logger.Info("Delete Associate logic");
            logger.Log(LogLevel.Info, "Associate Delete result bit {}", data.DeleteItemUsingApi(assoc, "associate").Result);
            return data.DeleteItemUsingApi(assoc, "associate").Result;
        }

         

        #endregion

        #region Batch Related
        public List<BatchDTO> GetBatches()
        {
            var allBatches = data.GetItemsFromApi<List<BatchDTO>>("Batch").Result;
            logger.Info("Get Batches logic");
            logger.Log(LogLevel.Info, "Batch Get returned allBatches {}", allBatches);
            return allBatches;
        }

        public bool InsertBatch(BatchDTO batchToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<BatchDTO>(batchToInsert, "Batch").Result;
            logger.Info("Insert Batch logic");
            logger.Log(LogLevel.Info, "Batch Insertion result bit {}", insertionResult);
            return insertionResult;
        }

        public bool UpdateBatch(string Id, BatchDTO batch)
        {
            logger.Info("Update Batch logic");
            logger.Log(LogLevel.Info, "Batch Update result bit {}", data.UpdateItemUsingApi<BatchDTO>(batch, "batch", Id).Result);
            return data.UpdateItemUsingApi<BatchDTO>(batch, "batch", Id).Result;
        }
               
        public bool DeleteBatch(string id)
        {
            logger.Info("Delete Batch logic");
            logger.Log(LogLevel.Info, "Batch Delete result bit {}", data.DeleteItemUsingApi(id, "batch").Result);
            return data.DeleteItemUsingApi(id, "batch").Result;
        }

        #endregion

        #region Gender Related
        public List<GenderDTO> GetGenders()
        {
            var allGenders = data.GetItemsFromApi<List<GenderDTO>>("Gender").Result;
            logger.Info("Get Genders logic");
            logger.Log(LogLevel.Info, "Gender Get returned allGenders {}", allGenders);
            return allGenders;
        }

        public bool InsertGender(GenderDTO genderToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<GenderDTO>(genderToInsert, "Gender").Result;
            logger.Info("Insert Gender logic");
            logger.Log(LogLevel.Info, "Gender Insertion result bit {}", insertionResult);
            return insertionResult;
        }
        public bool UpdateGender(string Id, GenderDTO gender)
        {
            logger.Info("Update Gender logic");
            logger.Log(LogLevel.Info, "Gender Update result bit {}", data.UpdateItemUsingApi<GenderDTO>(gender, "gender", Id).Result);
            return data.UpdateItemUsingApi<GenderDTO>(gender, "gender", Id).Result;
        }

        public bool DeleteGender(string id)
        {
            logger.Info("Delete Gender logic");
            logger.Log(LogLevel.Info, "Gender Delete result bit {}", data.DeleteItemUsingApi(id, "gender").Result);
            return data.DeleteItemUsingApi(id, "gender").Result;
        }
        #endregion

        #region Housing Complex Related
        public List<HousingComplexDTO> GetHousingComplexes()
        {
            var allHousingComplexes = data.GetItemsFromApi<List<HousingComplexDTO>>("HousingComplex").Result;
            logger.Info("Get HousingComplexes logic");
            logger.Log(LogLevel.Info, "HousingComplex Get returned allHousingComplexes {}", allHousingComplexes);
            return allHousingComplexes;
        }

        public bool InsertHousingComplex(HousingComplexDTO housingComplexToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<HousingComplexDTO>(housingComplexToInsert, "HousingComplex").Result;
            logger.Info("Insert HousingComplex logic");
            logger.Log(LogLevel.Info, "HousingComplex Insertion result bit {}", insertionResult);
            return insertionResult;
        }

        public bool UpdateHousingComplex(string Id, HousingComplexDTO housingComplex)
        {
            logger.Info("Update HousingComplex logic");
            logger.Log(LogLevel.Info, "HousingComplex Update result bit {}", data.UpdateItemUsingApi<HousingComplexDTO>(housingComplex, "housingComplex", Id).Result);
            return data.UpdateItemUsingApi<HousingComplexDTO>(housingComplex, "housingcomplex", Id).Result;
        }

        public bool DeleteHousingComplex(string id)
        {
            logger.Info("Delete HousingComplex logic");
            logger.Log(LogLevel.Info, "HousingComplex Delete result bit {}", data.DeleteItemUsingApi(id, "housingcomplex").Result);
            return data.DeleteItemUsingApi(id, "housingcomplex").Result;
        }
        #endregion

        #region Housing Data Related
        public List<HousingDataDTO> GetHousingData()
        {
            var allHousingData = data.GetItemsFromApi<List<HousingDataDTO>>("HousingData").Result;
            logger.Info("Get HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Get returned allHousingData {}", allHousingData);
            return allHousingData;
        }

        public bool InsertHousingData(HousingDataDTO housingDataToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<HousingDataDTO>(housingDataToInsert, "HousingData").Result;
            logger.Info("Insert HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Insertion result bit {}", insertionResult);
            return insertionResult;
        }
        public bool UpdateHousingData(string Id, HousingDataDTO housingData)
        {
            logger.Info("Update HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Update result bit {}", data.UpdateItemUsingApi<HousingDataDTO>(housingData, "housingData", Id).Result);
            return data.UpdateItemUsingApi<HousingDataDTO>(housingData, "housingdata", Id).Result;
        }

        public bool DeleteHousingData(string id)
        {
            logger.Info("Delete HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Delete result bit {}", data.DeleteItemUsingApi(id, "housingdata").Result);
            return data.DeleteItemUsingApi(id, "housingdata").Result;
        }
        #endregion

        #region Housing Unit Related
        public List<HousingUnitDTO> GetHousingUnits()
        {
            var allHousingUnits = data.GetItemsFromApi<List<HousingUnitDTO>>("HousingUnit").Result;
            logger.Info("Get HousingUnits logic");
            logger.Log(LogLevel.Info, "HousingUnits Get returned allHousingUnits{}", allHousingUnits);
            return allHousingUnits;
        }

        public bool InsertHousingUnit(HousingUnitDTO housingUnitToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<HousingUnitDTO>(housingUnitToInsert, "HousingUnit").Result;
            logger.Info("Insert HousingUnit logic");
            logger.Log(LogLevel.Info, "HousingUnit Insertion result bit {}", insertionResult);
            return insertionResult;
        }
        public bool UpdateHousingUnit(string Id, HousingUnitDTO housingUnit)
        {
            logger.Info("Update HousingUnit logic");
            logger.Log(LogLevel.Info, "HousingUnit Update result bit {}", data.UpdateItemUsingApi<HousingUnitDTO>(housingUnit, "housingUnit", Id).Result);
            return data.UpdateItemUsingApi<HousingUnitDTO>(housingUnit, "housingunit", Id).Result;
        }

        public bool DeleteHousingUnit(string id)
        {
            logger.Info("Delete HousingUnit logic");
            logger.Log(LogLevel.Info, "HousingUnit Delete result bit {}", data.DeleteItemUsingApi(id, "housingunit").Result);
            return data.DeleteItemUsingApi(id, "housingunit").Result;
        }
        #endregion
    }
}
