using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context;

namespace TaskSehirTeknolojileri_Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(AppDbContextBase context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
