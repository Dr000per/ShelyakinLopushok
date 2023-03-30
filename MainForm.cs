using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolovovLopushok
{
    public partial class MainForm : Form
    {
        public int page = 0;
        public DataTable products;
        DataTable prodID;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using(DataBase db = new DataBase())
            {
                products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
                prodID = db.ExecuteSql($"select productid from productmaterial");
            }


            SelectPageData();
        }

        public void SelectPageData()
        {
            string path = @"C:\Users\wfpro\Desktop\";

            string cpath = path + products.Rows[page].ItemArray[5].ToString();
            textBoxTitle.Text = products.Rows[page].ItemArray[2].ToString();
            textBoxCost.Text = products.Rows[page].ItemArray[4].ToString();
            textBox_prod_type.Text = products.Rows[page].ItemArray[1].ToString();

            try
            {
                pictureBox1.Image = Image.FromFile(cpath);
            }
            catch
            {
                cpath = path + @"products\picture.png";
                pictureBox1.Image = Image.FromFile(cpath);
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (page < products.Rows.Count)
                {
                    page += 1;
                    SelectPageData();
                }
            }
            catch
            {

            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (page > 0)
                {
                    page -= 1;
                    SelectPageData();
                }
            }
            catch
            {

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using(DataBase db = new DataBase())
            {
                db.ExecuteNonQuery($"delete from productmaterial where productid = {products.Rows[page].ItemArray[0]}");
                db.ExecuteNonQuery($"delete from product where ArticleNumber = '{products.Rows[page].ItemArray[3]}'");

                MessageBox.Show("Вы успешно удалили данные о выбранном продукте!");

                products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
                prodID = db.ExecuteSql($"select productid from productmaterial");
                
                SelectPageData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            new UpdateForm(this).Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new FormAdd().Show();
        }
    }
}
