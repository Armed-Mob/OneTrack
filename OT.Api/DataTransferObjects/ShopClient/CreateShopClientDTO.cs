namespace OT.Api.DataTransferObjects.ShopClient
{
    public class CreateShopClientDTO
    {
        public int Id { get; set; }
        public int ShopId { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
