using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IRepository <TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);


    }
}
