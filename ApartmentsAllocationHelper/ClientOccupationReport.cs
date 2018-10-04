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

namespace ApartmentsAllocationHelper
{
    public partial class ClientOccupationReport : Form
    {
        public Clients ClientForReport { get; set; }
        public ClientOccupationReport()
        {
            InitializeComponent();
        }

        private void ShowClientsDataBtn_Click(object sender, EventArgs e)
        {
            ClientsViewGrid clients = new ClientsViewGrid(true);
            clients.ShowDialog();
            nationalIDTxt.Text = clients.SelectedClient.NationalId;
        }

        private void ShowReportBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nationalIDTxt.Text)) {
                // TODO: This line of code loads data into the 'ClientReportPerOccupation.DataTable1' table. You can move, or remove it, as needed.
                this.DataTable1TableAdapter.Fill(this.ClientReportPerOccupation.DataTable1,nationalIDTxt.Text);
                this.reportViewer1.RefreshReport();
            }

        }

        private void ClientOccupationReport_Load(object sender, EventArgs e)
        {

        }
    }
}
