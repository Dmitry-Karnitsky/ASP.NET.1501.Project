using System;
using System.Collections.Generic;
namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; }
        public DateTime RegistryDate { get; set; }
        public List<DalProduct> Products { get; set; }
        public List<DalProduct> Products1 { get; set; }
    }
}