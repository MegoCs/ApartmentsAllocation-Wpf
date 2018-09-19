using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Clients
    {
        public Clients()
        {
            Apartments = new HashSet<Apartments>();
        }

        public string Id { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }

        public ICollection<Apartments> Apartments { get; set; }
    }
}
