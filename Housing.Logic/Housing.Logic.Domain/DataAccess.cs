using Housing.Logic.Domain.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Housing.Logic.Domain
{
    /// <summary>Class is used for consuming lower level data access service</summary>
    public class DataAccess
    {
        const string apiURL = "http://localhost:57200/api/";

        #region Create
        /// <summary>Used for insert calls to data access API</summary>
        public async Task<bool> InsertItemUsingApi<T>(T itemToInsert, string controllerName) where T : class, new()
        {
            HttpClient httpClient = new HttpClient();

            var itemToInsertJson = new JavaScriptSerializer().Serialize(itemToInsert);
            HttpContent contentPost = new StringContent(itemToInsertJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(apiURL + controllerName, contentPost).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                if (data == "true" || data == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
        #endregion

        #region Read
        /// <summary>Used for GET calls to data access API</summary>
        public async Task<T> GetItemsFromApi<T>(string controllerName) where T : class, new()
        {
            T list;
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(apiURL + controllerName).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<T>(data);
                list = product;
            }
            else
            {
                list = null;
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
