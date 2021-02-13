using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int Id);
        List<Car> GetAllByColorId(int Id);
        List<Car> GetByUnitPrice(decimal min, decimal max);
        List<CarDetailDto> GetCarDetailDtos();
    }
}
