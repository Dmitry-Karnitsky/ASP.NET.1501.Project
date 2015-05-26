using System;
namespace BLL.Interface.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public decimal Auction_Cost { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public int Seller_Id { get; set; }
        public int Buyer_Id { get; set; }
        public string Description { get; set; }
    }
}
