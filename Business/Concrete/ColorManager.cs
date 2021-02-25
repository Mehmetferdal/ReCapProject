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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (color.ColorName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Deleted(Color color)
        {
            if (color.ColorName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Color color)
        {
            if (color.ColorName != null)
            {
                return new ErrorResult(Messages.Alert);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId), Messages.Listed);

        }


    }
}
