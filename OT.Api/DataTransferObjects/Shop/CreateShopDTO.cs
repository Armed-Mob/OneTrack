namespace OT.Api.DataTransferObjects.Shop
{
    public class CreateShopDTO
    {
        public string ShopName { get; set; } = string.Empty;
        public string? ShopEmail { get; set; }
        public string? ShopPhone { get; set; }
        public string? ShopOwnerFirstName { get; set; } = string.Empty;
        public string? ShopOwnerLastName { get; set; } = string.Empty;
        public string? ShopOwnerEmail { get; set; }
        public string? ShopOwnerPhone { get; set; }
    }
}
