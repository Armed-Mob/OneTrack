using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Shared
{
    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty; 
        public string? ShopOwnerFirstName { get; set; } = string.Empty;
        public string? ShopOwnerLastName { get; set; } = string.Empty;
        public string? ShopOwnerPhone { get; set; } = string.Empty;
        public string? ShopOwnerEmail { get; set; } = string.Empty;

        public virtual ICollection<ShopClient> ShopClients { get; set; } = new List<ShopClient>();
    }
}
