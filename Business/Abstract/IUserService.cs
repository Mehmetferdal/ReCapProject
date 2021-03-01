using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int userId);
        IDataResult<List<UserDetailDto>> GetUserDetailDtos();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Deleted(User user);
    }
}
