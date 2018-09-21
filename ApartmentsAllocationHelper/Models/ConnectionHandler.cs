using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApartmentsAllocationHelper.Models
{
    class ConnectionHandler
    {
        public OleDbConnection myConnection = null;
        public OleDbDataReader myReader = null;
        public OleDbCommand myCommand = null;
        public OleDbDataAdapter myAdabter = null;

        private readonly string _dbFilePath;

        public ConnectionHandler(string DbPath)
        {
            _dbFilePath = DbPath;
        }

        public void StartConnection()
        {
            String myConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbFilePath}";
            try
            {
                if (myConnection == null || myConnection.State == System.Data.ConnectionState.Closed)
                    myConnection = new OleDbConnection(myConnectionString);
            }

            catch (Exception ex)
            {
                MessageBox.Show("خطأ ف الاتصال بقاعدة البيانات" + ex.Message);
            }
        }
        public void SQLCODE(String sql, bool adabter)
        {
            try
            {
                if (!adabter)
                {
                    myCommand = new OleDbCommand(sql, myConnection);
                    if (myConnection.State == 0)
                        myConnection.Open();
                    myReader = myCommand.ExecuteReader();
                }
                else
                {
                    myAdabter = new OleDbDataAdapter(sql, myConnection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ ف العملية " + ex.Message);
                //Logger.WriteLog("[" + DateTime.Now + "] " + ex.Message + ". SqlWas: " + sql + " [ConnectionClass] By [" + SessionInfo.empName + "]");
            }
        }
    }
}
