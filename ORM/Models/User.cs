using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
            Products1 = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string E_mail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Role_Id { get; set; } 

        [Required]
        public DateTime RegistryDate { get; set; }

        [ForeignKey("Role_Id")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Product> Products1 { get; set; }

        
    }
}
