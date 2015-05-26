using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class ProductMapper
    {
        public static DalProduct ToDalProduct(this ProductEntity productEntity)
        {
            return new DalProduct()
            {
                Id = productEntity.Id,
                Auction_Cost = productEntity.Auction_Cost,
                AuctionStart = productEntity.AuctionStart,
                AuctionEnd = productEntity.AuctionEnd,
                Seller_Id = productEntity.Seller_Id,
                Buyer_Id = productEntity.Buyer_Id,
                Description = productEntity.Description
            };
        }

        public static ProductEntity ToBllProduct(this DalProduct dalProduct)
        {
            return new ProductEntity()
            {
                Id = dalProduct.Id,
                Auction_Cost = dalProduct.Auction_Cost,
                AuctionStart = dalProduct.AuctionStart,
                AuctionEnd = dalProduct.AuctionEnd,
                Seller_Id = dalProduct.Seller_Id,
                Buyer_Id = dalProduct.Buyer_Id,
                Description = dalProduct.Description
            };
        }
    }
}