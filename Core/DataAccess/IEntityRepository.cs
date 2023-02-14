using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class : referans tip
    //IEntity : IEntity olabilir veya onu iplemente eden bir nesne olabilir 
    //new : new 'lenebilir olmalı
    public interface IEntityRepository<T> //generic yapı ...çalışacağım tip o an neyse T o olacak(car,brand,color vs.) //DataAcess.Abstract içindeki interfaceler için
                                          //yazılan ortak kodlar . CRUD işlemleri
        where T :class,IEntity , new ()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //expression filtre vermemizi sağlar
        T Get(Expression<Func<T, bool>> filter); //tek bir data getirmek için kullanılır 
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
       
    }
}
