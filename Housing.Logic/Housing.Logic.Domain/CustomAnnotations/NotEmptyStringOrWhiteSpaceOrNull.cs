using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.CustomAnnotations
{
    /// <summary>
    /// Validate DateTimes
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    class NotEmptyStringOrWhiteSpaceOrNull : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool result = true;
            string s = value as string;
            if(String.IsNullOrWhiteSpace(s) || String.IsNullOrEmpty(s))
            {
                result = false;
            }
            return result;
        }
    }
}
