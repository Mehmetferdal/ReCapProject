using Business.Abstract;
using Business.Constains;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //if (brand.BrandName != null)
            //{
            //    return new ErrorResult(Messages.Alert);
            //}
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Deleted(Brand brand)
        {
            if (brand.BrandName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Brand brand)
        {
            if (brand.BrandName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated); ;
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Brand>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == colorId), Messages.Listed);
        }


    }
}
