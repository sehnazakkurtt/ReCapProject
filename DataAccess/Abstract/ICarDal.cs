using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //burası benim car nesnesi ile ilgili vt yapacağım operasyonları içeren interface CRUD işlemeleri 
    {
        List<CarDetailDto> GetCarDetailDtos();

    }
}
