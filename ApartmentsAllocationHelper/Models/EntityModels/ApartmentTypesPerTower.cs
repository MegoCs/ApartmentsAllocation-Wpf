using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class ApartmentTypesPerTower
    {
        public ApartmentTypesPerTower()
        {
            Apartments = new HashSet<Apartments>();
        }

        public string Id { get; set; }
        public decimal ApartmentArea { get; set; }
        public byte[] ApartmentImage { get; set; }
        public string TowerId { get; set; }
        public decimal TagNumber { get; set; }
        public string TagName { get; set; }

        public Towers Tower { get; set; }
        public ICollection<Apartments> Apartments { get; set; }
    }
}
