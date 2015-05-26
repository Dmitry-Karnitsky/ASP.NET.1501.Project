using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Table("Products")]
    public partial class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Auction_Cost { get; set; }

        [Required]
        public DateTime AuctionStart { get; set; }

        [Required]
        public DateTime AuctionEnd { get; set; }

        [Required]
        public int Seller_Id { get; set; }

        [Required]
        public int Buyer_Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
