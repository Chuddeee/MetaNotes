using MetaNotes.Common;
using MetaNotes.Internationalization.Errors.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Attributes.Validation
{
    public class MinLengthFieldAttribute : MinLengthAttribute
    {
        public MinLengthFieldAttribute(int minLength, Type resType = null, string resName = null)
            : base(minLength)
        {
            if (resType == null)
            {
                ErrorMessageResourceType = typeof(SharedErrorsResources);
            }
            else ErrorMessageResourceType = resType;

            if (resName.IsNullOrWhiteSpace())
            {
                ErrorMessageResourceName = "MinLength";
            }
            else ErrorMessageResourceName = resName;
        }         
    }
}