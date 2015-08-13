using MetaNotes.Common;
using MetaNotes.Core.Entities;
using MetaNotes.Internationalization.Errors.Account;
using MetaNotes.Internationalization.Errors.Shared;
using MetaNotes.Internationalization.UI.Account;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Models
{
    /*чтобы убрать этот ужас с атрибутами можно определить свои атрибуты 
     но в этом случае нужно писать клиентскую логику валидации, т.к. клиентская валидация
     перестает работать, даже если просто унаследоваться от Required атрибута.
     
     Либо можно заюзать https://github.com/Haacked/mvc-metadata-conventions*/
    public class SignInModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Login_Title")]
        [MaxLength(User.LoginMaxLength, 
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MaxLength")]
        [MinLength(User.LoginMinLength,
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MinLength")]
        public string Login { get; set; }



        [Required(ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Password_Title")]
        [RegularExpression(RegexConstants.Password,
            ErrorMessageResourceType = typeof(AccountErrorsResources),
            ErrorMessageResourceName = "PasswordRegex")]
        [MaxLength(LengthConstants.PasswordMax,
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MaxLength")]
        [MinLength(LengthConstants.PasswordMin,
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MinLength")]
        public string Password { get; set; }
    }
}