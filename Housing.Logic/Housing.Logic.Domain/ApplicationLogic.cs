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
        #region Associate Related
        public List<AssociateDTO> GetAssociates()
        {
            DataAccess data = new DataAccess();
            var allAssociates = data.GetItemsFromApi<List<AssociateDTO>>("Associate").Result;

            return allAssociates;
        }

        public bool InsertAssociate(AssociateDTO associateToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<AssociateDTO>(associateToInsert, "Associate").Result;

            return insertionResult;
        }
        #endregion

        #region Batch Related
        public List<BatchDTO> GetBatches()
        {
            DataAccess data = new DataAccess();
            var allBatches = data.GetItemsFromApi<List<BatchDTO>>("Batch").Result;

            return allBatches;
        }

        public bool InsertBatch(BatchDTO batchToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<BatchDTO>(batchToInsert, "Batch").Result;

            return insertionResult;
        }
        #endregion

        #region Gender Related
        public List<GenderDTO> GetGenders()
        {
            DataAccess data = new DataAccess();
            var allGenders = data.GetItemsFromApi<List<GenderDTO>>("Gender").Result;

            return allGenders;
        }

        public bool InsertGender(GenderDTO genderToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<GenderDTO>(genderToInsert, "Gender").Result;

            return insertionResult;
        }
        #endregion

        #region Housing Complex Related
        public List<HousingComplexDTO> GetHousingComplexes()
        {
            DataAccess data = new DataAccess();
            var allHousingComplexes = data.GetItemsFromApi<List<HousingComplexDTO>>("HousingComplex").Result;

            return allHousingComplexes;
        }

        public bool InsertHousingComplex(HousingComplexDTO housingComplexToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<HousingComplexDTO>(housingComplexToInsert, "HousingComplex").Result;

            return insertionResult;
        }
        #endregion

        #region Housing Data Related
        public List<HousingDataDTO> GetHousingData()
        {
            DataAccess data = new DataAccess();
            var allHousingData = data.GetItemsFromApi<List<HousingDataDTO>>("HousingData").Result;

            return allHousingData;
        }

        public bool InsertHousingData(HousingDataDTO housingDataToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<HousingDataDTO>(housingDataToInsert, "HousingData").Result;

            return insertionResult;
        }
        #endregion

        #region Housing Unit Related
        public List<HousingUnitDTO> GetHousingUnits()
        {
            DataAccess data = new DataAccess();
            var allHousingUnits = data.GetItemsFromApi<List<HousingUnitDTO>>("HousingUnit").Result;

            return allHousingUnits;
        }

        public bool InsertHousingUnit(HousingUnitDTO housingUnitToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<HousingUnitDTO>(housingUnitToInsert, "HousingUnit").Result;

            return insertionResult;
        }
        #endregion
    }
}
