using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllById(int Id);
        IDataResult<List<Car>> GetAllByColorId(int Id);
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
