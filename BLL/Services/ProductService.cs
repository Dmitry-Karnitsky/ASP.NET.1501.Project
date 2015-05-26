using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using Helpers;
using DAL.Interface.DTO;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork uow;
        private readonly IProductRepository productRepository;

        public ProductService(IUnitOfWork uow, IProductRepository repository)
        {
            this.uow = uow;
            this.productRepository = repository;
        }

        public void Create(ProductEntity entity)
        {
            productRepository.Create(entity.ToDalProduct());
            uow.Commit();
        }

        public void Edit(ProductEntity entity)
        {
            productRepository.Update(entity.ToDalProduct());
            uow.Commit();
        }

        public void Delete(ProductEntity entity)
        {
            productRepository.Delete(entity.ToDalProduct());
            uow.Commit();
        }

        public IEnumerable<ProductEntity> GetAllEntities()
        {
            return productRepository.GetAll().Select(product => product.ToBllProduct());
        }

        public ProductEntity GetById(int id)
        {
            return productRepository.GetById(id).ToBllProduct();
        }

        public IEnumerable<ProductEntity> GetByPredicate(Expression<Func<ProductEntity, bool>> p)
        {
            Expression<Func<DalProduct, bool>> expr = ExpressionTransformer<ProductEntity, DalProduct>.Transform(p);
            return productRepository.GetByPredicate(expr).Select(product => product.ToBllProduct());
        }

        public IEnumerable<ProductEntity> GetProductsSoldByUser(int id)
        {
            return productRepository.GetProductsSoldByUser(id).Select(product => product.ToBllProduct());
        }

        public IEnumerable<ProductEntity> GetProductsBoughtByUser(int id)
        {
            return productRepository.GetProductsBoughtByUser(id).Select(product => product.ToBllProduct());
        }
    }
}
