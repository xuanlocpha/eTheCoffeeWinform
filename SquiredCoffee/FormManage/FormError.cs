using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormError : Form
    {
        public string title;
        public FormError()
        {
            InitializeComponent();
        }

        public void clear()
        {
            lblTitle.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            lblTitle.Text = title;
        }
    }
}
