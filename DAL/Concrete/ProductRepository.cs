using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using Helpers;


namespace DAL.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext context;

        public ProductRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public IEnumerable<DalProduct> GetAll()
        {
            return context.Set<Product>().Select(ormproduct => new DalProduct()
            {
                Id = ormproduct.Id,
                Auction_Cost = ormproduct.Auction_Cost,
                AuctionStart = ormproduct.AuctionStart,
                AuctionEnd = ormproduct.AuctionEnd,
                Seller_Id = ormproduct.Seller_Id,
                Buyer_Id = ormproduct.Buyer_Id,
                Description = ormproduct.Description
            });
        }

        public DalProduct GetById(int key)
        {
            var ormproduct = context.Set<Product>().FirstOrDefault(product => product.Id == key);
            return ConvertToDalProductFromOrmProduct(ormproduct);
        }

        public IEnumerable<DalProduct> GetByPredicate(Expression<Func<DalProduct, bool>> f)
        {
            var transpormer = new ExpressionTransformer<DalProduct, Product>(Expression.Parameter(typeof(Product), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Product, bool>>(transpormer.Visit(f.Body), transpormer.NewParamExpr);

            return context.Set<Product>().Where(expression).Select(ormproduct => new DalProduct()
            {
                Id = ormproduct.Id,
                Auction_Cost = ormproduct.Auction_Cost,
                AuctionStart = ormproduct.AuctionStart,
                AuctionEnd = ormproduct.AuctionEnd,
                Seller_Id = ormproduct.Seller_Id,
                Buyer_Id = ormproduct.Buyer_Id,
                Description = ormproduct.Description
            });
        }

        public void Create(DalProduct e)
        {
            var product = new Product()
            {
                Id = e.Id,
                Auction_Cost = e.Auction_Cost,
                AuctionStart = e.AuctionStart,
                AuctionEnd = e.AuctionEnd,
                Seller_Id = e.Seller_Id,
                Buyer_Id = e.Buyer_Id,
                Description = e.Description
            };
            context.Set<Product>().Add(product);
        }

        public void Delete(DalProduct e)
        {
            context.Set<Product>().Remove(context.Set<Product>().Where(m => m.Id == e.Id).FirstOrDefault());
        }

        public void Update(DalProduct e)
        {
            var product = context.Set<Product>().Where(m => m.Id == e.Id).FirstOrDefault();
            product.Auction_Cost = e.Auction_Cost;
            product.AuctionStart = e.AuctionStart;
            product.AuctionEnd = e.AuctionEnd;
            product.Seller_Id = e.Seller_Id;
            product.Buyer_Id = e.Buyer_Id;
            product.Description = e.Description;
        }

        public IEnumerable<DalProduct> GetProductsSoldByUser(int id)
        {
            var products = context.Set<Product>().Where(p => p.Seller_Id == id);

            return products.Select(ormproduct => new DalProduct()
            {
                Id = ormproduct.Id,
                Auction_Cost = ormproduct.Auction_Cost,
                AuctionStart = ormproduct.AuctionStart,
                AuctionEnd = ormproduct.AuctionEnd,
                Seller_Id = ormproduct.Seller_Id,
                Buyer_Id = ormproduct.Buyer_Id,
                Description = ormproduct.Description
            });
        }

        public IEnumerable<DalProduct> GetProductsBoughtByUser(int id)
        {
            var products = context.Set<Product>().Where(p => p.Buyer_Id == id);

            return products.Select(ormproduct => new DalProduct()
            {
                Id = ormproduct.Id,
                Auction_Cost = ormproduct.Auction_Cost,
                AuctionStart = ormproduct.AuctionStart,
                AuctionEnd = ormproduct.AuctionEnd,
                Seller_Id = ormproduct.Seller_Id,
                Buyer_Id = ormproduct.Buyer_Id,
                Description = ormproduct.Description
            });
        }

        private DalProduct ConvertToDalProductFromOrmProduct(Product ormproduct)
        {
            return new DalProduct()
            {
                Id = ormproduct.Id,
                Auction_Cost = ormproduct.Auction_Cost,
                AuctionStart = ormproduct.AuctionStart,
                AuctionEnd = ormproduct.AuctionEnd,
                Seller_Id = ormproduct.Seller_Id,
                Buyer_Id = ormproduct.Buyer_Id,
                Description = ormproduct.Description
            };
        }

        
    }
}

