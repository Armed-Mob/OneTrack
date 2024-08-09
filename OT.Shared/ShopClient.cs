using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Shared
{
    public class ShopClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;       
        public string ClientPhone { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

            set
            {
                FirstName = value;
                LastName = value;
            }
        }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        public virtual ICollection<VehicleDetails> VehicleDetails { get; set; } = new List<VehicleDetails>();
    }
}
