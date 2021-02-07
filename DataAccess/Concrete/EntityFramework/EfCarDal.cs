using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car TEntity)
        {
            using (RecapContext context=new RecapContext())
            {
                var addedEntity = context.Entry(TEntity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car TEntity)
        {
            using (RecapContext context = new RecapContext())
            {
                var deletedEntity = context.Entry(TEntity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context=new RecapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car TEntity)
        {
            using (RecapContext context = new RecapContext())
            {
                var updateEntity = context.Entry(TEntity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
