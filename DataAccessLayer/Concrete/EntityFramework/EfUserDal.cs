using Core.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NortwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NortwindContext()) {
                var result = from operationClaim in context.OperationClaims
                             join userOpertaionClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOpertaionClaim.OperationClaimId
                             where userOpertaionClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
