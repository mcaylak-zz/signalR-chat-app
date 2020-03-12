using Core.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
    {
    }
}
