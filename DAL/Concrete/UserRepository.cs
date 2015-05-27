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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(ormuser => new DalUser()
            {
                Id = ormuser.Id,
                Login = ormuser.Login,
                E_mail = ormuser.E_mail,
                Password = ormuser.Password,
                Role_Id = ormuser.Role_Id,
                RegistryDate = ormuser.RegistryDate,
                Products = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList(),
                Products1 = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList()
            });
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return ConvertToDalUserFromOrmUser(ormuser);
        }       

        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            var transpormer = new ExpressionTransformer<DalUser, User>(Expression.Parameter(typeof(User), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<User, bool>>(transpormer.Visit(f.Body), transpormer.NewParamExpr);
            return context.Set<User>().Where(expression).Select(ormuser => new DalUser()
            {
                Id = ormuser.Id,
                Login = ormuser.Login,
                E_mail = ormuser.E_mail,
                Password = ormuser.Password,
                Role_Id = ormuser.Role_Id,
                RegistryDate = ormuser.RegistryDate,
                Products = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList(),
                Products1 = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList()
            });
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Login = e.Login,
                Role_Id = e.Role_Id,
                Password = e.Password,
                RegistryDate = DateTime.Now,
                E_mail = e.E_mail                
            };
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            context.Set<User>().Remove(context.Set<User>().Where(m => m.Id == e.Id).FirstOrDefault());
        }

        public void Update(DalUser e)
        {
            var user = context.Set<User>().Where(m => m.Id == e.Id).FirstOrDefault();
            user.Login = e.Login;
            user.Password = e.Password;
            user.RegistryDate = e.RegistryDate;
            user.Role_Id = e.Role_Id;
            user.E_mail = e.E_mail;
        }

        public DalUser GetByLogin(string user)
        {
            return ConvertToDalUserFromOrmUser(context.Set<User>().Where(m => m.Login == user).FirstOrDefault());
        }

        private DalUser ConvertToDalUserFromOrmUser(User ormuser)
        {
            return new DalUser()
            {
                Id = ormuser.Id,
                Login = ormuser.Login,
                E_mail = ormuser.E_mail,
                Password = ormuser.Password,
                Role_Id = ormuser.Role_Id,
                RegistryDate = ormuser.RegistryDate,
                Products = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList(),
                Products1 = ormuser.Products.Select(product => new DalProduct()
                {
                    Id = product.Id,
                    Auction_Cost = product.Auction_Cost,
                    AuctionStart = product.AuctionStart,
                    AuctionEnd = product.AuctionEnd,
                    Seller_Id = product.Seller_Id,
                    Buyer_Id = product.Buyer_Id,
                    Description = product.Description
                }).ToList()
            };
        }
    }
}
