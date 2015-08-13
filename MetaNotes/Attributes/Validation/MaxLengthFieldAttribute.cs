using MetaNotes.Common;
using MetaNotes.Internationalization.Errors.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Attributes.Validation
{
    public class MaxLengthFieldAttribute : MaxLengthAttribute
    {
        public MaxLengthFieldAttribute(int maxLength, Type resType = null, string resName = null)
            : base(maxLength)
        {
            if (resType == null)
            {
                ErrorMessageResourceType = typeof(SharedErrorsResources);
            }
            else ErrorMessageResourceType = resType;

            if (resName.IsNullOrWhiteSpace())
            {
                ErrorMessageResourceName = "MaxLength";
            }
            else ErrorMessageResourceName = resName;
        }         
    }
}