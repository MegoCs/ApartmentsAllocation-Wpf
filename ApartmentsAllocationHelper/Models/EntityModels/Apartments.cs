using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Apartments
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public string OccupationStatus { get; set; }
        public DateTime? OccupationDate { get; set; }
        public string ClientId { get; set; }
        public string FloorId { get; set; }
        public decimal ApartmentNumber { get; set; }
        public string ApartmentName { get; set; }

        public Clients Client { get; set; }
        public Floors Floor { get; set; }
        public ApartmentTypesPerTower Type { get; set; }
    }
}
