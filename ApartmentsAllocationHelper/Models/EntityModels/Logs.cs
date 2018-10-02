using System;
using System.Collections.Generic;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class Logs
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public DateTime LogDateTime { get; set; }
        public string LogDetails { get; set; }
    }
}
