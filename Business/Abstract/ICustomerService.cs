using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetById(int userId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Deleted(Customer customer);
    }
}
