using HotelFinder.DataAccess.Abstract;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete.GenericRepository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        private readonly HotelDbContext hoteldbContext;
        public GenericRepository(HotelDbContext _hoteldbContext)
        {
            hoteldbContext = _hoteldbContext;
        }



        public TEntity Create(TEntity entity)
        {

            hoteldbContext.Set<TEntity>().Add(entity);
            hoteldbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
                var deletedTEntity = GetById(id);
                hoteldbContext.Set<TEntity>().Remove(deletedTEntity);
                hoteldbContext.SaveChanges();
            
        }

        public List<TEntity> GetAll()
        {
          
            
                return hoteldbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
           
            
                return hoteldbContext.Set<TEntity>().Find(id);
                //return hoteldbContext.Hotels.Find(id);
            
        }

        public TEntity Update(TEntity entity)
        {
           
            
                hoteldbContext.Set<TEntity>().Update(entity);
                hoteldbContext.SaveChanges();
                return entity;
            
        }
    }
}
