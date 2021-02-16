using Business.Abstract;
using Business.Constains;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Deleted(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Updated); ;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Customer>> GetById(int rentalId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Id == rentalId)); ;
        }
    }
}
