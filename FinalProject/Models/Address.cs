using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Address
    {
        public Address()
        {
            SupplierAddresses = new HashSet<SupplierAddress>();
        }

        public int AddressId { get; set; }
        public string StreetLine1 { get; set; } = null!;
        public string? StreetLine2 { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? Zipcode { get; set; }
        public string Country { get; set; } = null!;

        public virtual ICollection<SupplierAddress> SupplierAddresses { get; set; }
    }
}
