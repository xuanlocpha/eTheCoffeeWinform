using System;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormSuccess : Form
    {
        public string title;
        public FormSuccess()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuccess_Load(object sender, EventArgs e)
        {
            lblTitle.Text = title;
        }
    }
}
