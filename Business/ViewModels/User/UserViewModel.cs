using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.User
{
    public class UserViewModel: ViewModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        [Display(Name = "Adı Soyadı")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "TC Kimlik numarası gerekldir.")]
        [Display(Name = "TC Kimlik")]
        public string TcNo { get; set; }

        [Display(Name = "Tel No:")]
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Araç plakası gereklidir.")]
        [Display(Name = "Araç Plakası")]
        public string PlateNumber { get; set; }
    }
}

