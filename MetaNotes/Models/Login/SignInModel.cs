using MetaNotes.Attributes.Validation;
using MetaNotes.Common;
using MetaNotes.Core.Entities;
using MetaNotes.Internationalization.Errors.Account;
using MetaNotes.Internationalization.UI.Account;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Models
{
    //часть локализации пропущена, т.к. мало времени было
    public class SignInModel
    {
        [RequiredField]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Login_Title")]
        [MaxLengthField(User.LoginMaxLength)]
        [MinLengthField(User.LoginMinLength)]
        public string Login { get; set; }


        [RequiredField]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Password_Title")]
        [RegularExpression(RegexConstants.Password, 
            ErrorMessageResourceType = typeof(AccountErrorsResources), 
            ErrorMessageResourceName = "PasswordRegex")]
        [MaxLengthField(LengthConstants.PasswordMax)]
        [MinLengthField(LengthConstants.PasswordMin)]
        public string Password { get; set; }
    }
}