using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Block
{
    public class BlockViewModel:ViewModel
    {
        public int BlockId { get; set; }
        [Required(ErrorMessage = "Blok adı gereklidir.")]
        [Display(Name = "Blok adı")]
        public string BlockName { get; set; }
    }
}
