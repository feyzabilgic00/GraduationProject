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
    public class EfEmailSendDal : EfEntityRepositoryBase<EmailSend>, IEmailSendDal
    {
        private readonly DbContext _context;
        public EfEmailSendDal(DbContext context) : base(context)
        {
            _context = context;
        }

    }
}
