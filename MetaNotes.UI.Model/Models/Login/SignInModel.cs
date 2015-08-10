using MetaNotes.Internationalization.UI.Account;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.UI.Model
{
    public class SignInModel
    {
        [RequiredField]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Login_Title")]
        public string Login { get; set; }

        [RequiredField]
        [Display(ResourceType = typeof(AccountIndexUIResources), Name = "Password_Title")]        
        public string Password { get; set; }
    }
}