using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Role
{
    public class RoleViewModel:ViewModel
    {
        public string Id { get; set; }

        [Display(Name="Role ismi")]
        [Required(ErrorMessage ="Role ismi gereklidir.")]
        public string Name { get; set; }
    }
}
