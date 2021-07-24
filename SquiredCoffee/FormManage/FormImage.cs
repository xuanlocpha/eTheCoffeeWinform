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
    public partial class FormImage : Form
    {
        Bitmap image;
        public FormImage()
        {
            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
             "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pbImage.Image = (Image)image;

                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                rtbBase64.Text = base64Text;
            }
        }
    }
}
