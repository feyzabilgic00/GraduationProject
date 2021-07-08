using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRoleDal:EfEntityRepositoryBase<Role>,IRoleDal
    {
        public EfRoleDal(DbContext context) : base(context)
        {

        }
    }
}
