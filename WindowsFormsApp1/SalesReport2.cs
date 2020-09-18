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
    public partial class SalesReport2 : Form
    {
        public SalesReport2()
        {
            InitializeComponent();
        }

        private void fullOrderDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fullOrderDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet2);

        }

        private void SalesReport2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.fullOrderDetails' table. You can move, or remove it, as needed.
            this.fullOrderDetailsTableAdapter.Fill(this.database1DataSet2.fullOrderDetails);
            SalesCrystalReport2 salesReport = new SalesCrystalReport2();
            salesReport.SetDataSource(this.database1DataSet2);
            ReportViewer.ReportSource = salesReport;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            adminDashboard adb = new adminDashboard();
            adb.Show();
            this.Hide();
        }
    }
}
