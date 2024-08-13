namespace OT.Api.DataTransferObjects.Shop
{
    public class GetAllShopsDTO
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string? ShopOwnerFirstName { get; set; }
        public string? ShopOwnerLastName { get; set; }
        public string? ShopPhone { get; set; }
        public string? ShopEmail { get; set; }
        public string? ShopOwner
        {
            get
            {
                return ShopOwnerFirstName + " " + ShopOwnerLastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ShopOwnerFirstName = string.Empty;
                    ShopOwnerLastName = string.Empty;
                }
                else
                {
                    ShopOwnerFirstName = value;
                    ShopOwnerLastName = value;
                }
            }
        }
        public string? ShopOwnerEmail { get; set; }
        public string? ShopOwnerPhone { get; set; }
    }
}
