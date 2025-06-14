﻿using ApartmentsAllocationHelper.Models.EntityModels;
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

            #region Config BackgroundWorker To Load Projects List
            try
            {
                projectLoaderAgent = new BackgroundWorker();
                projectLoaderAgent.DoWork += ProjectLoaderAgent_DoWork;
                projectLoaderAgent.RunWorkerCompleted += ProjectLoaderAgent_RunWorkerCompleted;
                projectLoaderAgent.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
            #endregion

        }

        private void ProjectLoaderAgent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                manageProjectToolStripMenuItem.Enabled = true;
                clientsWithDoneOccupationToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ProjectLoaderAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (_dbContext= new ApartmentDeliveryDbContext())
                {
                    pList = _dbContext.Projects.Include(x => x.Towers).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ManageProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageProjectSelection m = new ManageProjectSelection(pList);
                m.ShowDialog();
                projectLoaderAgent.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void AddClientDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AccessDbDataMigration mig = new AccessDbDataMigration();
                mig.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void AddProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewProjectCreation newPro = new NewProjectCreation();
                newPro.ShowDialog();
                projectLoaderAgent.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }

        }

        private void AddTowersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddTowersToProjectWindow obj = new AddTowersToProjectWindow();
                obj.ShowDialog();
                projectLoaderAgent.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void CancelOccupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CancelOccupationWindow cancelWin = new CancelOccupationWindow();
                cancelWin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ClientDataViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsViewGrid view = new ClientsViewGrid(false);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ClientsWithDoneOccupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsAndUnitsReportForm rform = new ClientsAndUnitsReportForm(pList);
                rform.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManualPage page = new ManualPage();
                page.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ClientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientOccupationReport report = new ClientOccupationReport();
                report.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void ApartsWithNoneOccupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EmptyApartsReportForm emptyAparts = new EmptyApartsReportForm(pList);
                emptyAparts.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }
    }
}