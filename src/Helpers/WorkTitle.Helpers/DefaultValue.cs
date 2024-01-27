using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Helpers
{
    public static class DefaultValue
    {
        public static WishListDto GetDefaultWishList() 
        {
            return new WishListDto() { Name = "Default"};
        }
    }
}
