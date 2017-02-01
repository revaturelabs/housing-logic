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
    /// <summary>Class is used for consuming lower level data access service</summary>
    public class DataAccess
    {
        const string apiURL = "http://localhost:57200/api";

        #region Create

        #endregion

        #region Read
        /// <summary>Used for GET calls to data access API</summary>
        public async Task<List<AssociateDTO>> GetAllAssociates()
        {
            List<AssociateDTO> list = null;
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(apiURL + "/associate").Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<List<AssociateDTO>>(data);
                list = product;
            }

            return list;
        }
        #endregion

        #region Update

            #endregion

        #region Delete

            #endregion

        }
}
