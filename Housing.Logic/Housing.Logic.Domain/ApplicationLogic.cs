﻿using Housing.Logic.Domain.DataTransferObjects;
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
            var allAssociates = data.GetAllAssociates().Result;

            return allAssociates;
        }
        #endregion

        #region Batch Related

        #endregion

        #region Gender Related

        #endregion

        #region Housing Complex Related

        #endregion

        #region Housing Data Related

        #endregion

        #region Housing Unit Related

        #endregion
    }
}
