using Core.DataAccessLayer;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
