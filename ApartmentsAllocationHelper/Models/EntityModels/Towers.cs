using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Towers
    {
        public Towers()
        {
            ApartmentTypesPerTower = new HashSet<ApartmentTypesPerTower>();
            Floors = new HashSet<Floors>();
        }

        public string Id { get; set; }
        public string TowerName { get; set; }
        public string ProjectId { get; set; }
        public decimal FloorsNumber { get; set; }
        public decimal ApartmentsPerFloor { get; set; }
        public byte[] TowerImage { get; set; }

        public Projects Project { get; set; }
        public ICollection<ApartmentTypesPerTower> ApartmentTypesPerTower { get; set; }
        public ICollection<Floors> Floors { get; set; }
    }
}
