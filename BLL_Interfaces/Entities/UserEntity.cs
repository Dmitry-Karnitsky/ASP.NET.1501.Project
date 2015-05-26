using System;
using System.Collections.Generic;
namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; }
        public DateTime RegistryDate { get; set; }
        public List<ProductEntity> Products { get; set; }
        public List<ProductEntity> Products1 { get; set; } 
    }
}
