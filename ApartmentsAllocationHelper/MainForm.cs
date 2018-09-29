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
using Microsoft.EntityFrameworkCore;

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
            clientsWithDoneOccupationToolStripMenuItem.Enabled = true;
        }

        private void ProjectLoaderAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            _dbContext = new ApartmentDeliveryDbContext();
            pList = _dbContext.Projects.Include(x=>x.Towers).ToList();
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

        private void AddProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectCreation newPro = new NewProjectCreation();
            newPro.ShowDialog();
            projectLoaderAgent.RunWorkerAsync();

        }

        private void AddTowersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTowersToProjectWindow obj = new AddTowersToProjectWindow();
                obj.ShowDialog();
        }

        private void CancelOccupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelOccupationWindow cancelWin = new CancelOccupationWindow();
            cancelWin.ShowDialog();
        }

        private void ClientDataViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClientsViewGrid view = new ClientsViewGrid();
            view.ShowDialog();
        }

        private void clientsWithDoneOccupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsAndUnitsReportForm rform = new ClientsAndUnitsReportForm(pList);
            rform.ShowDialog();
        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualPage page = new ManualPage();
            page.ShowDialog();
        }
    }
}
