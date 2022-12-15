using Microsoft.EntityFrameworkCore;
using TaskSehirTeknolojileri_Core.DataAccess.EntityFramework;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, AppDbContextBase>, IUserDal
    {


        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new AppDbContextBase())
            {
                var result = from role in context.OperationClaims
                             join userRoles in context.UserOperationClaims
                                 on role.Id equals userRoles.OperationClaimId
                             where userRoles.UserId == user.Id
                             select new OperationClaim { Id = role.Id, Name = role.Name };
                return await result.ToListAsync();
            }
        }

      
    }
}
