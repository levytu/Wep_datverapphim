using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
namespace BigSchool.ModelsView
{
    public class ValidTime: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);

            return isValid ;
        }
    }
}