using MetaNotes.Internationalization.Errors.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using MetaNotes.Common;

namespace MetaNotes
{
    /// <summary>Атрибут Required. Берет ключ по умолчанию</summary>
    public class RequiredFieldAttribute : RequiredAttribute
    {
        public RequiredFieldAttribute(Type resType = null, string resName = null)
        {
            if (resType == null)
            {
                ErrorMessageResourceType = typeof(SharedErrorsResources);
            }
            else ErrorMessageResourceType = resType;

            if (resName.IsNullOrWhiteSpace())
            {
                ErrorMessageResourceName = "Required";
            }
            else ErrorMessageResourceName = resName;
                        
            AllowEmptyStrings = false;
        } 
    }
}