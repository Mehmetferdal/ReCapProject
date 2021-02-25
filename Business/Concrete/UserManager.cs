using Business.Abstract;
using Business.Constains;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Deleted(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Updated); ;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<User>> GetById(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(c => c.Id == userId),Messages.Listed); ;
        }

        public IDataResult<List<UserDetailDto>> GetUserDetailDtos()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetailDtos(), Messages.Listed);
        }
    }
}
