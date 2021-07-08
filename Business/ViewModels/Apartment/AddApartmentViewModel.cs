using Business.ViewModels.Block;
using Business.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.ViewModels.Apartment
{
    public class AddApartmentViewModel:ViewModel
    {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> BlockName { get; set; }
        public IEnumerable<SelectListItem> NameSurname { get; set; }

        [Required(ErrorMessage = "Daire durumu gereklidir.")]
        [Display(Name = "Daire Durumu")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Daire tipi gereklidir.")]
        [Display(Name = "Daire Tipi")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Bulunduğu kat gereklidir.")]
        [Display(Name = "Bulunduğu kat")]
        public string FloorLocation { get; set; }

        [Required(ErrorMessage = "Daire numarası gereklidir.")]
        [Display(Name = "Daire Numarası")]
        public string ApartmentNumber { get; set; }
    }
}
