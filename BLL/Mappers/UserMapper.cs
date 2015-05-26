using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            List<DalProduct> products = null;
            if (userEntity.Products != null)            
                 products = userEntity.Products.Select(e => e.ToDalProduct()).ToList();

            List<DalProduct> products1 = null;

            if (userEntity.Products1 != null) 
                 products1 = userEntity.Products1.Select(e => e.ToDalProduct()).ToList();
            
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                E_mail = userEntity.E_mail,
                Password = userEntity.Password,
                Role_Id = userEntity.Role_Id,
                RegistryDate = userEntity.RegistryDate,
                Products = products,
                Products1 = products1
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            List<ProductEntity> products = null;
            if (dalUser.Products != null)
                products = dalUser.Products.Select(e => e.ToBllProduct()).ToList();

            List<ProductEntity> products1 = null;

            if (dalUser.Products1 != null)
                products1 = dalUser.Products1.Select(e => e.ToBllProduct()).ToList();
            
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                E_mail = dalUser.E_mail,
                Password = dalUser.Password,
                Role_Id = dalUser.Role_Id,
                RegistryDate = dalUser.RegistryDate,
                Products = products,
                Products1 = products1
            };
        }
    }
}
