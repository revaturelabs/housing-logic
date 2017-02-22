using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Housing.Logic.Domain.CustomAnnotations
{
    /// <summary>
    /// Validate DateTimes
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DateTimeNotMinValue : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool result = true;
            if ((DateTime)value <= DateTime.MinValue)
            {
                result = false;
            }
            return result;
        }


    }
}
