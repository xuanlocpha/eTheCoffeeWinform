using SquiredCoffee.Class;
using SquiredCoffee.DB;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Dashbroad : UserControl
    {
        public int totalProduct;
        public int totalProductDrink;
        public int totalProductFood;
        public int percentFood;
        public int percentDrink;
        int countProduct = 0;
        int countProductDrink = 0;
        int countProductFood = 0;

        public UC_Dashbroad()
        {
            InitializeComponent();
        }

        private void UC_Dashbroad_Load(object sender, EventArgs e)
        {
            loadProduct();
            loadStaff();
        }


        public void loadProduct()
        {
           
            List<ProductShow2> productShow2List = DbProduct.LoadProductList2();
            foreach (ProductShow2 item in productShow2List)
            {
                countProduct = countProduct + 1;
                if(item.type_category == "drink")
                {
                    countProductDrink = countProductDrink + 1;
                }
                if (item.type_category == "food")
                {
                    countProductFood = countProductFood + 1;
                }
            }
            PercentProductDrink(countProductDrink);
            PercentProductFood(countProductFood);
            lblTotalProduct.Text = countProduct.ToString();
            lblTotalDrink.Text = countProductFood.ToString() + " Sản phẩm";
            lblTotalFood.Text = countProductDrink.ToString() + " Sản phẩm";
            lblPercentDrink.Text = percentDrink + "%";
            lblPercentFood.Text = percentFood + "%";
            percentProduct.Value = percentDrink;
        }



        public void loadStaff()
        {
            int totalStaff = 0;
            int totalStaffMale = 0;
            int totalStaffFemale = 0;
            List<Staff> staffList = DbStaff.LoadStaffList();
            foreach (Staff item in staffList)
            {
                totalStaff = totalStaff + 1;
                if(item.gender == "male")
                {
                    totalStaffMale = totalStaffMale + 1;
                }
                if(item.gender == "female")
                {
                    totalStaffFemale = totalStaffFemale + 1;
                }
            }
            lblTotalStaff.Text = totalStaff.ToString();
            lblTotalStaffMale.Text = totalStaffMale.ToString()+ " Nhân Viên";
            lblTotalFemale.Text = totalStaffFemale.ToString() + " Nhân Viên";
        }

        public void PercentProductDrink(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(countProduct)*100;
            percentDrink = Convert.ToInt32(kq);
        }

        public void PercentProductFood(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(countProduct) * 100;
            percentFood = Convert.ToInt32(kq);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
