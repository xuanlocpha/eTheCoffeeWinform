using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.Report
{
    public partial class PrintPaymentForm : Form
    {
        List<ReceiptShow> _list;
        string _total;
        public PrintPaymentForm(List<ReceiptShow> list,string total)
        {
            InitializeComponent();
            _list = list;
            _total = total;
        }

        public object ReceiptBindingSource { get; private set; }

        private void PrintPaymentForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_total)
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
