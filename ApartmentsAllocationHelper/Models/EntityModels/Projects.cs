using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Projects
    {
        public Projects()
        {
            Towers = new HashSet<Towers>();
        }

        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string WarningMessage { get; set; }

        public ICollection<Towers> Towers { get; set; }
    }
}
