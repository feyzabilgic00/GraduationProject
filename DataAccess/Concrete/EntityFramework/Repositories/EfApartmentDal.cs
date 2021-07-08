using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfApartmentDal: EfEntityRepositoryBase<Apartment>,IApartmentDal
    {
        private readonly DbContext _context;
        public EfApartmentDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public List<ApartmentDetailDto> GetApartmentDetail(Expression<Func<Apartment, bool>> filter = null)
        {
            
            var result = from a in filter == null ? _context.Set<Apartment>() : _context.Set<Apartment>().Where(filter)
                         join b in _context.Set<Block>()
                         on a.Block.Id equals b.Id
                         join u in _context.Set<User>()
                         on a.User.Id equals u.Id
                         select new ApartmentDetailDto
                         {
                             Id=a.Id,
                             NameSurname=u.NameSurname,
                             Status=a.Status,
                             Type=a.Type,
                             FloorLocation=a.FloorLocation,
                             ApartmentNumber=a.ApartmentNumber
                         };
            return result.ToList();
            
        }
        public List<SelectListItem> GetSelectListBlocks()
        {
            IEnumerable<SelectListItem> blocks = _context.Set<Block>().Select(b => new SelectListItem
            {
                Text = b.BlockName,
                Value = b.Id.ToString()
            });
            return blocks.ToList();
        }
        public List<SelectListItem> GetSelectListUsers()
        {
            IEnumerable<SelectListItem> users = _context.Set<User>().Select(u => new SelectListItem
            {
                Text = u.NameSurname,
                Value = u.Id.ToString()
            });
            return users.ToList();
        }
    }
}
