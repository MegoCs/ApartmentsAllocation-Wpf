using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Floors
    {
        public Floors()
        {
            Apartments = new HashSet<Apartments>();
        }

        public string Id { get; set; }
        public decimal FloorNo { get; set; }
        public decimal ApartmentsNumber { get; set; }
        public string TowerId { get; set; }

        public Towers Tower { get; set; }
        public ICollection<Apartments> Apartments { get; set; }
    }
}
