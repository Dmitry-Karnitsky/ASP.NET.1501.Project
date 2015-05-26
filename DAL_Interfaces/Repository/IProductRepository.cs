using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IProductRepository : IRepository<DalProduct>
    {
        IEnumerable<DalProduct> GetProductsSoldByUser(int id);
        IEnumerable<DalProduct> GetProductsBoughtByUser(int id);
    }
}
