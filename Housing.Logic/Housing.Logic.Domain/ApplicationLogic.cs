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
#pragma warning disable CS1591
    /// <summary>Class is used for performing any logic needed on data acquired from data access</summary>
    public class ApplicationLogic
    {
        private DataAccess data = new DataAccess();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<AssociateDTO> GetUnassignedAssociates()
        {
            var allAssociates = data.GetItemsFromApi<List<AssociateDTO>>("associate").Result;
            var allData = data.GetItemsFromApi<List<HousingDataDTO>>("housingdata").Result;

            var toReturn = allAssociates
                    .Select(m => m)
                    .Where(o =>
                        (
                                allAssociates
                                .Select(m => m.Email)
                                .Except(
                                    allData
                                    .Select(m => m.AssociateEmail)
                                )
                        )
                        .Contains(o.Email)
                     );
            logger.Trace("List of Associates not assigned housing");
            logger.Log(LogLevel.Trace, "List of associates needing housing created, toReturn{0} ", toReturn);
            return toReturn.ToList();
        }

        public List<HousingUnitDTO> GetHousingUnitsWithAvailableBeds()
        {
            var allUnits = data.GetItemsFromApi<List<HousingUnitDTO>>("housingunit").Result;
            var allData = data.GetItemsFromApi<List<HousingDataDTO>>("housingdata").Result;

            var x = allData
                    .GroupBy(m => m.HousingUnitName)
                    .Select(group => new {
                        Metric = group.Key,
                        Count = group.Count()
                    });
            logger.Trace("all data queried");
            logger.Log(LogLevel.Trace, "all data for housing contains x{0} ", x);

            List<HousingUnitDTO> toReturn;
            foreach (var item in x)
            {
                if(allUnits.Find(m => m.HousingUnitName.Equals(item.Metric.ToString())).MaxCapacity<=item.Count)
                {
                    allUnits.Remove(allUnits.Find(m => m.HousingUnitName.Equals(item.Metric.ToString())));
                    logger.Trace("all Units query performed");
                    logger.Log(LogLevel.Trace, "all Units query returned allUnits{0} ", allUnits);
                }
            }
            toReturn = allUnits;
            logger.Trace("List of Apartments with open spots");
            logger.Log(LogLevel.Trace, "List of open beds created, toReturn{0} ", toReturn);
            return toReturn;
        }

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
            var updateResult = data.UpdateItemUsingApi<AssociateDTO>(assoc, "associate", Id).Result;
            logger.Info("Update Associate logic");
            logger.Log(LogLevel.Info, "Associate Update result bit {}", updateResult);
            return updateResult;
        }

        /// <summary>
        /// call delete from dataAccess
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if success, else returns false</returns>
        public bool DeleteAssociate(string assoc)
        {
            var deleteResult = data.DeleteItemUsingApi(assoc, "associate").Result;
            logger.Info("Delete Associate logic");
            logger.Log(LogLevel.Info, "Associate Delete result bit {}", deleteResult);
            return deleteResult;
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
            var updateResult = data.UpdateItemUsingApi<BatchDTO>(batch, "batch", Id).Result;
            logger.Info("Update Batch logic");
            logger.Log(LogLevel.Info, "Batch Update result bit {}", updateResult);
            return updateResult;
        }
               
        public bool DeleteBatch(string id)
        {
            var deleteResult = data.DeleteItemUsingApi(id, "batch").Result;
            logger.Info("Delete Batch logic");
            logger.Log(LogLevel.Info, "Batch Delete result bit {}", deleteResult);
            return deleteResult;
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
            var toReturn =  data.UpdateItemUsingApi<GenderDTO>(gender, "gender", Id).Result;
            logger.Info("Update Gender logic");
            logger.Log(LogLevel.Info, "Gender Update result bit {}", toReturn);
            return toReturn;
        }

        public bool DeleteGender(string id)
        {
            var deleteResult = data.DeleteItemUsingApi(id, "gender").Result;
            logger.Info("Delete Gender logic");
            logger.Log(LogLevel.Info, "Gender Delete result bit {}", deleteResult);
            return deleteResult;
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
            var result = data.UpdateItemUsingApi<HousingComplexDTO>(housingComplex, "housingcomplex", Id).Result;
            logger.Info("Update HousingComplex logic");
            logger.Log(LogLevel.Info, "HousingComplex Update result bit {}", result);
            return result;
        }

        public bool DeleteHousingComplex(string id)
        {
            var result = data.DeleteItemUsingApi(id, "housingcomplex").Result;
            logger.Info("Delete HousingComplex logic");
            logger.Log(LogLevel.Info, "HousingComplex Delete result bit {}", result);
            return result;
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

        public List<HousingDataDTO> GetHousingDataByDate(HousingDataRequestDTO request)
        {
            var allHousingData = data.GetItemsFromApi<List<HousingDataDTO>>("HousingData").Result;
            var housingDataMatchingUnit = allHousingData.Where(hu => (hu.HousingUnitName == request.HousingUnitName));
            var housingDataMatchingUnitAndDate = housingDataMatchingUnit.Where(hd => (hd.MoveInDate <= request.Date) && (hd.MoveOutDate >= request.Date));
            return housingDataMatchingUnitAndDate.ToList();
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
            var result = data.UpdateItemUsingApi<HousingDataDTO>(housingData, "housingdata", Id).Result;
            logger.Info("Update HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Update result bit {}", result);
            return result;
        }

        public bool DeleteHousingData(string id)
        {
            var result = data.DeleteItemUsingApi(id, "housingdata").Result;
            logger.Info("Delete HousingData logic");
            logger.Log(LogLevel.Info, "HousingData Delete result bit {}", result);
            return result;
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
            var result = data.UpdateItemUsingApi<HousingUnitDTO>(housingUnit, "housingunit", Id).Result;
            logger.Info("Update HousingUnit logic");
            logger.Log(LogLevel.Info, "HousingUnit Update result bit {}", result);
            return result;
        }

        public bool DeleteHousingUnit(string id)
        {
            var result = data.DeleteItemUsingApi(id, "housingunit").Result;
            logger.Info("Delete HousingUnit logic");
            logger.Log(LogLevel.Info, "HousingUnit Delete result bit {}", result);
            return result;
        }
        #endregion
    }
}
