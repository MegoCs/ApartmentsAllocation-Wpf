using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentsAllocationHelper.Models.EntityModels;

namespace ApartmentsAllocationHelper
{
    public static class Logger
    {
        static ApartmentDeliveryDbContext _dbContext; 
        public static void WriteLog(String logMessage, string className)
        {
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    _dbContext.Logs.Add(new Logs()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClassName = className,
                        LogDateTime = DateTime.Now,
                        LogDetails = logMessage
                    });
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception) {
                
            }
        }
    }
}
