using ApartmentsAllocationHelper.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmentsAllocationHelper
{
    public partial class MainForm: Form
    {
        BackgroundWorker projectLoaderAgent;
        private ApartmentDeliveryDbContext _dbContext;
        private List<Projects> pList;

        public MainForm()
        {
            InitializeComponent();
            #region Config BackGroundWorker To Load Projects List
            projectLoaderAgent = new BackgroundWorker();
            projectLoaderAgent.DoWork += ProjectLoaderAgent_DoWork;
            projectLoaderAgent.RunWorkerCompleted += ProjectLoaderAgent_RunWorkerCompleted;
            projectLoaderAgent.RunWorkerAsync();
            #endregion

        }

        private void ProjectLoaderAgent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            manageProjectToolStripMenuItem.Enabled = true;
        }

        private void ProjectLoaderAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            _dbContext = new ApartmentDeliveryDbContext();
            pList = _dbContext.Projects.ToList();
        }

        private void ManageProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProjectSelection m = new ManageProjectSelection(pList);
            m.ShowDialog();
        }

        private void AddClientDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccessDbDataMigration mig = new AccessDbDataMigration();
            mig.ShowDialog();
        }
    }
}
