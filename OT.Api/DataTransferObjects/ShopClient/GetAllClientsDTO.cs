namespace OT.Api.DataTransferObjects.ShopClient
{
    public class GetAllClientsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ClientPhone { get; set; } = string.Empty;
        public string? ClientEmail { get; set; } = string.Empty;
        public int ShopId { get; set; }
    }
}
