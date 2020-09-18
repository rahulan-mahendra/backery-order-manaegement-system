using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SlaesReport : Form
    {
        public SlaesReport()
        {
            InitializeComponent();
        }

        private void fullOrderDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fullOrderDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void SlaesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.fullOrderDetails' table. You can move, or remove it, as needed.
            this.fullOrderDetailsTableAdapter.Fill(this.database1DataSet.fullOrderDetails);
            SalesCrystalReport2 salesReport = new SalesCrystalReport2();
            salesReport.SetDataSource(this.database1DataSet);
            ReportViewer.ReportSource = salesReport;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            adminDashboard adb = new adminDashboard();
            adb.Show();
            this.Hide();
        }

        private void ReportViewer_Load_1(object sender, EventArgs e)
        {

        }
    }
}
