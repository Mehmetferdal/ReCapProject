using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RecapContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetailDtos()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new UserDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.Firstname,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 //Password = u.Password,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RecapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
