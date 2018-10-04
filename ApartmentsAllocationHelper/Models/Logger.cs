using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using ApartmentsAllocationHelper.Models.EntityModels;
using Newtonsoft.Json;

namespace ApartmentsAllocationHelper
{
    public static class Logger
    {
        static ApartmentDeliveryDbContext _dbContext;
        private static Logs _obj;

        public static void WriteLog(String logMessage, string className)
        {
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    _obj = new Logs()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClassName = className,
                        LogDateTime = DateTime.Now,
                        LogDetails = logMessage
                    };
                    _dbContext.Logs.Add(_obj);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                WriteLogToFile(JsonConvert.SerializeObject(_obj));
            }
        }
        private static void WriteLogToFile(string ErrorMessage)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable)) + @"\Logs.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(ErrorMessage);
            }
        }
    }
}
