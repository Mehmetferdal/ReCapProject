﻿using Business.Abstract;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            //if (car.CarName.Length < 2)
            //{
            //    return new ErrorResult(Messages.NameInvalid);
            //}
            if (car.CarName == null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
            

        }
        public IResult Update(Car car)
        {
            if (car.CarName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        public IResult Delete(Car car)
        {
            if (car.CarName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == Id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id));
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(), Messages.Listed);
        }


    }
}
