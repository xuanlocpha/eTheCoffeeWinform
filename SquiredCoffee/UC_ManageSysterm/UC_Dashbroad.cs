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
        int totalOrder=0;
        int totalOrderOnline=0;
        int totalOrderOffline=0;
        int totalOrderCancel=0;
        int percentOrderOnline;
        int percentOrderOffline;
        int percentOrderCancel;
        string level;
        int totalUser = 0;
        int totalUserPlatium = 0;
        int totalUserGold = 0;
        int totalUserAlumium = 0;
        int percentPlatium =0;
        int percentGold = 0;
        int percentAlumium = 0;

        public UC_Dashbroad()
        {
            InitializeComponent();
        }

        private void UC_Dashbroad_Load(object sender, EventArgs e)
        {
            loadTotalReward();
            loadTotalStockProduct();
            loadTotalOrder();
            loadVoucher();
            loadOrder();
            loadProduct();
            loadStaff();
            loadUser();
        }

        public void loadTotalOrder()
        {
            decimal total = 0;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<OrderShow2> orderList = DbOrder.LoadShowOrderSearch(date);
            foreach (OrderShow2 item in orderList)
            {
                total = total + item.grandtotal;
            }
            lblTotalMoney.Text = string.Format("{0:#,##0 đ}", total);
        }

        public void loadTotalStockProduct()
        {
            int i = 0;
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductList();
            foreach (StockProduct item in stockProductList)
            {
                i = i + 1;
            }
            lblTotalStockProduct.Text = i + " Sản phẩm";
        }

        public void loadTotalReward()
        {
            int i = 0;
            List<RewardShow> rewardShowList = DbReward.LoadReward();
            foreach (RewardShow item in rewardShowList)
            {
                i = i + 1;
            }
            lblTotalReward.Text = i + " Quà tặng";
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


        public void loadOrder()
        {
            List<OrderShow2> orderList = DbOrder.LoadShowOrder();
            foreach (OrderShow2 item in orderList)
            {
                totalOrder = totalOrder + 1;
                if (item.mode == "online")
                {
                    totalOrderOnline = totalOrderOnline + 1;
                }
                if(item.mode == "offline")
                {
                    totalOrderOffline = totalOrderOffline + 1;
                }
            }
            List<OrderShow2> orderList1 = DbOrder.LoadShowOrderShowCancel();
            foreach (OrderShow2 item in orderList1)
            {
                totalOrderCancel = totalOrderCancel + 1;
            }
            PercentOrderCancel(totalOrderCancel);
            PercentOrderOffline(totalOrderOffline);
            PercentOrderOnline(totalOrderOnline);
            lblTotalOrder.Text = totalOrder.ToString();
            lblTotalOrderOffline.Text = totalOrderOffline.ToString();
            lblTotalOrderOnline.Text = totalOrderOnline.ToString();
            lblTotalOrderCancle.Text = totalOrderCancel.ToString();
            guna2ProgressBar1.Value = percentOrderOnline;
            guna2ProgressBar2.Value = percentOrderOffline;
            guna2ProgressBar3.Value = percentOrderCancel;
        }


        public void loadVoucher()
        {
            string type = "public";
            int i = 0;
            List<Voucher> voucherList = DbVoucher.LoadVoucherListToday(DateTime.Now.ToString("yyyy-MM-dd"), type);
            foreach (Voucher item in voucherList)
            {
                i = i + 1;
                dgvVoucher.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    i,
                    item.title,
                });
            }
        }

        public void PercentOrderOnline(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalOrder) * 100;
            percentOrderOnline = Convert.ToInt32(kq);
        }

        public void PercentOrderOffline(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalOrder) * 100;
            percentOrderOffline = Convert.ToInt32(kq);
        }

        public void PercentOrderCancel(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalOrder) * 100;
            percentOrderCancel = Convert.ToInt32(kq);
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


        public void PercentPlatium(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalUser) * 100;
            percentPlatium = Convert.ToInt32(kq);
        }

        public void PercentOrderGold(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalUser) * 100;
            percentGold = Convert.ToInt32(kq);
        }

        public void PercentOrderAlumium(int count)
        {
            double kq = Convert.ToDouble(count) / Convert.ToDouble(totalUser) * 100;
            percentAlumium = Convert.ToInt32(kq);
        }

        public void loadUser()
        {
          
            int i = 0;
            List<User> userList = DbUser.ListUser();
            foreach (User item in userList)
            {
                totalUser = totalUser + 1;
                i = i + 1;
                if (item.point <= 100)
                {
                    level = "Bạc";
                    totalUserAlumium = totalUserAlumium + 1;
                }
                if (item.point > 101 && item.point < 1000)
                {
                    level = "Vàng";
                    totalUserGold = totalUserGold + 1;
                }
                if (item.point > 1001)
                {
                    level = "Kim Cương";
                    totalUserPlatium = totalUserPlatium + 1;
                }
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    i,
                    item.display_name,
                    item.point,
                    level,
                });
            }
            PercentOrderAlumium(totalUserAlumium);
            PercentOrderGold(totalUserGold);
            PercentPlatium(totalUserPlatium);
            chart1.Series["Series1"].Points.AddXY("Kim cương", percentPlatium);
            chart1.Series["Series1"].Points.AddXY("Vàng", percentGold);
            chart1.Series["Series1"].Points.AddXY("Bạc", percentAlumium);
        }
    }
}
