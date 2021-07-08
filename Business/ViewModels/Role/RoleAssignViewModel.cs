using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Role
{
    public class RoleAssignViewModel:ViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exist { get; set; }
    }
}
