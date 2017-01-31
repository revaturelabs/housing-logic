using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain
{
    /// <summary>Class is used for consuming lower level data access service</summary>
    public class DataAccess
    {
        const string apiURL = "http://localhost:57200/api/";

        #region Create

        #endregion

        #region Read
        /// <summary>Used for GET calls to data access API</summary>
        public T getItemsFromApi<T>(string controllerName) where T : class, new()
        {
            HttpClient httpClient = new HttpClient();

            var httpResponse = httpClient.GetAsync(apiURL + controllerName).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var stream = httpResponse.Content.ReadAsStreamAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T items = serializer.ReadObject(stream) as T;

                return items;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
