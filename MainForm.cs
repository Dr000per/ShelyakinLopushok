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

namespace ShelyakinLopushok
{
    public partial class MainForm : Form
    {
        public int page = 0;
        public DataTable products;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using(DataBase db = new DataBase())
            {
                products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
            }


            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString());
        }

        public Boolean SelectPageData(object prod_rows_cpath, object prod_rows_title, object prod_rows_cost, object prod_rows_prod_type)
        {
            string path = @"C:\Users\wfpro\Desktop\";

            string cpath = path + prod_rows_cpath.ToString();
            textBoxTitle.Text = prod_rows_title.ToString();
            textBoxCost.Text = prod_rows_cost.ToString();
            textBox_prod_type.Text = prod_rows_prod_type.ToString();

            try
            {
                pictureBox1.Image = Image.FromFile(cpath);
                return true;
            }
            catch
            {
                cpath = path + @"products\picture.png";
                pictureBox1.Image = Image.FromFile(cpath);
                return false;
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (But_Go(page, products.Rows.Count))
            {
                SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString());
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (But_Back(page))
            {
                SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete_Button(products.Rows[page].ItemArray[0], products.Rows[page].ItemArray[3]);
        }
            
        public Boolean Delete_Button(object prodid, object articnum)
        {
            object prodid1 = prodid;
            object articnum1 = articnum;
            if (MessageBox.Show("Точно удалить?", "РЕШИТЕ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (DataBase db = new DataBase())
                {
                    db.ExecuteNonQuery($"delete from productmaterial where productid = {prodid1}");
                    db.ExecuteNonQuery($"delete from product where ArticleNumber = '{articnum1}'");

                    MessageBox.Show("Вы успешно удалили данные о выбранном продукте!");

                    products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");

                    SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdForm_open();
        }

        public Boolean UpdForm_open()
        {
            try
            {
                new UpdateForm(this).Show();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd_open();
        }

        public Boolean FormAdd_open()
        {
            try
            {
                new FormAdd().Show();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean But_Back(int page1)
        {
            if (page1 > 0)
            {
                page -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean But_Go(int page1, int rows)
        {
            if (page1 < rows)
            {
                page += 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
