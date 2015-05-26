using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IProductService : IService<ProductEntity>
    {
        IEnumerable<ProductEntity> GetProductsSoldByUser(int id);
        IEnumerable<ProductEntity> GetProductsBoughtByUser(int id);
    }
}
