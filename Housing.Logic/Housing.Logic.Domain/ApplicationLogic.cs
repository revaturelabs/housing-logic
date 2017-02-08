using Housing.Logic.Domain.DataTransferObjects;
using Newtonsoft.Json;
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

        #region Associate Related

        /// <summary>
        /// Calls dataAccess and gets specified list
        /// </summary>
        /// <returns>list of associate dtos</returns>
        public List<AssociateDTO> GetAssociates()
        {
            var allAssociates = data.GetItemsFromApi<List<AssociateDTO>>("Associate").Result;
            return allAssociates;
        }

        public bool InsertAssociate(AssociateDTO associateToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<AssociateDTO>(associateToInsert, "Associate").Result;
            return insertionResult;
        }

        public bool UpdateAssociate(string Id, AssociateDTO assoc)
        {
            return data.UpdateItemUsingApi<AssociateDTO>(assoc, "associate", Id).Result;
        }

        /// <summary>
        /// call delete from dataAccess
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if success, else returns false</returns>
        public bool DeleteAssociate(string assoc)
        {
            return data.DeleteItemUsingApi(assoc, "associate").Result;
        }

         

        #endregion

        #region Batch Related
        public List<BatchDTO> GetBatches()
        {
            var allBatches = data.GetItemsFromApi<List<BatchDTO>>("Batch").Result;

            return allBatches;
        }

        public bool InsertBatch(BatchDTO batchToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<BatchDTO>(batchToInsert, "Batch").Result;

            return insertionResult;
        }

        public bool UpdateBatch(string Id, BatchDTO batch)
        {
            return data.UpdateItemUsingApi<BatchDTO>(batch, "batch", Id).Result;
        }
               
        public bool DeleteBatch(string id)
        {
            return data.DeleteItemUsingApi(id, "batch").Result;
        }

        #endregion

        #region Gender Related
        public List<GenderDTO> GetGenders()
        {
            var allGenders = data.GetItemsFromApi<List<GenderDTO>>("Gender").Result;

            return allGenders;
        }

        public bool InsertGender(GenderDTO genderToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<GenderDTO>(genderToInsert, "Gender").Result;

            return insertionResult;
        }
        public bool UpdateGender(string Id, GenderDTO gender)
        {
            return data.UpdateItemUsingApi<GenderDTO>(gender, "gender", Id).Result;
        }

        public bool DeleteGender(string id)
        {
            return data.DeleteItemUsingApi(id, "gender").Result;
        }
        #endregion

        #region Housing Complex Related
        public List<HousingComplexDTO> GetHousingComplexes()
        {
            var allHousingComplexes = data.GetItemsFromApi<List<HousingComplexDTO>>("HousingComplex").Result;

            return allHousingComplexes;
        }

        public bool InsertHousingComplex(HousingComplexDTO housingComplexToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<HousingComplexDTO>(housingComplexToInsert, "HousingComplex").Result;

            return insertionResult;
        }

        public bool UpdateHousingComplex(string Id, HousingComplexDTO housingComplex)
        {
            return data.UpdateItemUsingApi<HousingComplexDTO>(housingComplex, "housingcomplex", Id).Result;
        }

        public bool DeleteHousingComplex(string id)
        {
            return data.DeleteItemUsingApi(id, "housingcomplex").Result;
        }
        #endregion

        #region Housing Data Related
        public List<HousingDataDTO> GetHousingData()
        {
            var allHousingData = data.GetItemsFromApi<List<HousingDataDTO>>("HousingData").Result;

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

            return insertionResult;
        }
        public bool UpdateHousingData(string Id, HousingDataDTO housingData)
        {
            return data.UpdateItemUsingApi<HousingDataDTO>(housingData, "housingdata", Id).Result;
        }

        public bool DeleteHousingData(string id)
        {
            return data.DeleteItemUsingApi(id, "housingdata").Result;
        }
        #endregion

        #region Housing Unit Related
        public List<HousingUnitDTO> GetHousingUnits()
        {
            var allHousingUnits = data.GetItemsFromApi<List<HousingUnitDTO>>("HousingUnit").Result;

            return allHousingUnits;
        }

        public bool InsertHousingUnit(HousingUnitDTO housingUnitToInsert)
        {
            var insertionResult = data.InsertItemUsingApi<HousingUnitDTO>(housingUnitToInsert, "HousingUnit").Result;

            return insertionResult;
        }
        public bool UpdateHousingUnit(string Id, HousingUnitDTO housingUnit)
        {
            return data.UpdateItemUsingApi<HousingUnitDTO>(housingUnit, "housingunit", Id).Result;
        }

        public bool DeleteHousingUnit(string id)
        {
            return data.DeleteItemUsingApi(id, "housingunit").Result;
        }
        #endregion
    }
}
