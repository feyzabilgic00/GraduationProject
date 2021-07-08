using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IApartmentDal:IEntityRepository<Apartment>
    {
        List<ApartmentDetailDto> GetApartmentDetail(Expression<Func<Apartment,bool>> filter = null);
        List<SelectListItem> GetSelectListBlocks();
        List<SelectListItem> GetSelectListUsers();
    }
}
