using MetaNotes.Internationalization.Errors.Shared;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes
{
    /// <summary>Атрибут Required. Берет ключ по умолчанию</summary>
    public class RequiredFieldAttribute : RequiredAttribute
    {
        public RequiredFieldAttribute()
        {
            ErrorMessageResourceName = "Required";
            ErrorMessageResourceType = typeof (SharedErrorsResources);
        } 
    }
}