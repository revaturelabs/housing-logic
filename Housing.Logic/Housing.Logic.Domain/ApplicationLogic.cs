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
            var allAssociates = data.GetItemsFromApi<List<AssociateDTO>>("associate").Result;

            return allAssociates;
        }

        public bool InsertAssociate(AssociateDTO associateToInsert)
        {
            DataAccess data = new DataAccess();
            var insertionResult = data.InsertItemUsingApi<AssociateDTO>(associateToInsert, "associate").Result;

            return insertionResult;
        }
        #endregion

        #region Batch Related
        public List<BatchDTO> GetBatches()
        {
            DataAccess data = new DataAccess();
            var allBatches = data.GetItemsFromApi<List<BatchDTO>>("batch").Result;

            return allBatches;
        }

        #endregion

        #region Gender Related
        public List<GenderDTO> GetGenders()
        {
            DataAccess data = new DataAccess();
            var allGenders = data.GetItemsFromApi<List<GenderDTO>>("gender").Result;

            return allGenders;
        }

        #endregion

        #region Housing Complex Related
        public List<HousingComplexDTO> GetHousingComplexes()
        {
            DataAccess data = new DataAccess();
            var allHousingComplexes = data.GetItemsFromApi<List<HousingComplexDTO>>("housing-complex").Result;

            return allHousingComplexes;
        }

        #endregion

        #region Housing Data Related
        public List<HousingDataDTO> GetHousingData()
        {
            DataAccess data = new DataAccess();
            var allHousingData = data.GetItemsFromApi<List<HousingDataDTO>>("housing-data").Result;

            return allHousingData;
        }
        #endregion

        #region Housing Unit Related
        public List<HousingUnitDTO> GetHousingUnits()
        {
            DataAccess data = new DataAccess();
            var allHousingUnits = data.GetItemsFromApi<List<HousingUnitDTO>>("housing-unit").Result;

            return allHousingUnits;
        }

        #endregion
    }
}
