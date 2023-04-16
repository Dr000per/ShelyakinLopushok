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
        public DataTable prodmat1;
        public DataTable prodmat2;
        public DataTable prodmat3;
        public DataTable prodmat4;
        List<object> materiali1 = new List<object>();
        List<object> materiali2 = new List<object>();
        List<object> materiali3 = new List<object>();
        List<object> materiali4 = new List<object>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
                prodmat1 = db.ExecuteSql($"select productmaterial.productid, productmaterial.materialid, material.title from productmaterial, material, product where productmaterial.productid = product.id and (productmaterial.productid = {products.Rows[page].ItemArray[0]} and productmaterial.materialid = material.id);");
            }
            linkLabel5.Text = (products.Rows.Count / 4).ToString();
            foreach (DataRow Row in prodmat1.Rows)
            {
                materiali1.Add(Row.ItemArray[2]);
            }
            string mat = string.Join(", ", materiali1.ToArray());

            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
                products.Rows[page+1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
                products.Rows[page+2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
                products.Rows[page+3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
        }

        public Boolean SelectPageData(object prod_rows_cpath1, object prod_rows_title1, object prod_rows_cost1, object prod_rows_prod_type1, object prod_rows_artc1,
            object prod_rows_cpath2, object prod_rows_title2, object prod_rows_cost2, object prod_rows_prod_type2, object prod_rows_artc2,
            object prod_rows_cpath3, object prod_rows_title3, object prod_rows_cost3, object prod_rows_prod_type3, object prod_rows_artc3,
            object prod_rows_cpath4, object prod_rows_title4, object prod_rows_cost4, object prod_rows_prod_type4, object prod_rows_artc4)
        {
            DataBase db = new DataBase();
            prodmat1 = db.ExecuteSql($"select productmaterial.productid, productmaterial.materialid, material.title from productmaterial, material, product where productmaterial.productid = product.id and (productmaterial.productid = {products.Rows[page].ItemArray[0]} and productmaterial.materialid = material.id);");
            materiali1.Clear();
            foreach (DataRow Row in prodmat1.Rows)
            {
                materiali1.Add(Row.ItemArray[2]);
            }
            
            string mat1 = string.Join(", ", materiali1.ToArray());

            prodmat2 = db.ExecuteSql($"select productmaterial.productid, productmaterial.materialid, material.title from productmaterial, material, product where productmaterial.productid = product.id and (productmaterial.productid = {products.Rows[page+1].ItemArray[0]} and productmaterial.materialid = material.id);");
            materiali2.Clear();
            foreach (DataRow Row in prodmat2.Rows)
            {
                materiali2.Add(Row.ItemArray[2]);
            }

            string mat2 = string.Join(", ", materiali2.ToArray());

            prodmat3 = db.ExecuteSql($"select productmaterial.productid, productmaterial.materialid, material.title from productmaterial, material, product where productmaterial.productid = product.id and (productmaterial.productid = {products.Rows[page+2].ItemArray[0]} and productmaterial.materialid = material.id);");
            materiali3.Clear();
            foreach (DataRow Row in prodmat3.Rows)
            {
                materiali3.Add(Row.ItemArray[2]);
            }

            string mat3 = string.Join(", ", materiali3.ToArray());

            prodmat4 = db.ExecuteSql($"select productmaterial.productid, productmaterial.materialid, material.title from productmaterial, material, product where productmaterial.productid = product.id and (productmaterial.productid = {products.Rows[page+3].ItemArray[0]} and productmaterial.materialid = material.id);");
            materiali4.Clear();
            foreach (DataRow Row in prodmat4.Rows)
            {
                materiali4.Add(Row.ItemArray[2]);
            }

            string mat4 = string.Join(", ", materiali4.ToArray());

            string path = @"C:\Users\wfpro\Desktop";

            string cpath1 = path + prod_rows_cpath1.ToString();
            string cpath2 = path + prod_rows_cpath2.ToString();
            string cpath3 = path + prod_rows_cpath3.ToString();
            string cpath4 = path + prod_rows_cpath4.ToString();

            textBoxTitle_1.Text = prod_rows_title1.ToString(); textBoxCost_1.Text = prod_rows_cost1.ToString(); textBox_prod_type1.Text = prod_rows_prod_type1.ToString(); textBox_artc1.Text = prod_rows_artc1.ToString();

            textBoxTitle_2.Text = prod_rows_title2.ToString(); textBoxCost_2.Text = prod_rows_cost2.ToString(); textBox_prod_type2.Text = prod_rows_prod_type2.ToString(); textBox_artc2.Text = prod_rows_artc2.ToString();

            textBoxTitle_3.Text = prod_rows_title3.ToString(); textBoxCost_3.Text = prod_rows_cost3.ToString(); textBox_prod_type3.Text = prod_rows_prod_type3.ToString(); textBox_artc3.Text = prod_rows_artc3.ToString();

            textBoxTitle_4.Text = prod_rows_title4.ToString(); textBoxCost_4.Text = prod_rows_cost4.ToString(); textBox_prod_type4.Text = prod_rows_prod_type4.ToString(); textBox_artc4.Text = prod_rows_artc4.ToString();

            if (mat1 != "")
            {
                textBox_mat1.Text = mat1;
            }
            else
            {
                textBox_mat1.Text = "Нет материалов!";
            }

            if (mat2 != "")
            {
                textBox_mat2.Text = mat2;
            }
            else
            {
                textBox_mat2.Text = "Нет материалов!";
            }

            if (mat3 != "")
            {
                textBox_mat3.Text = mat3;
                
            }
            else
            {
                textBox_mat3.Text = "Нет материалов!";
            }

            if (mat4 != "")
            {
                textBox_mat4.Text = mat4;
            }
            else
            {
                textBox_mat4.Text = "Нет материалов!";
            }

            try
            {
                pictureBox1.Image = Image.FromFile(cpath1);
                pictureBox3.Image = Image.FromFile(cpath2);
                pictureBox4.Image = Image.FromFile(cpath3);
                pictureBox5.Image = Image.FromFile(cpath4);
                return true;
            }
            catch
            {
                cpath1 = path + @"\products\picture.png";
                cpath2 = path + @"\products\picture.png";
                cpath3 = path + @"\products\picture.png";
                cpath4 = path + @"\products\picture.png";
                pictureBox1.Image = Image.FromFile(cpath1);
                pictureBox3.Image = Image.FromFile(cpath2);
                pictureBox4.Image = Image.FromFile(cpath3);
                pictureBox5.Image = Image.FromFile(cpath4);
                return false;
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

                    SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
                    products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
                    products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
                    products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page > 11)
            {
                page = page - 4;
                linkLabel3.Text = (Convert.ToInt32(linkLabel3.Text) - 1).ToString();
                linkLabel4.Text = (Convert.ToInt32(linkLabel4.Text) - 1).ToString();
                
                SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
                products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
                products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
                products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
            }
            else if(page > 3)
            {
                page = page - 4;
                linkLabel3.Text = 2.ToString();
                linkLabel4.Text = 3.ToString();

                SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
                products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
                products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
                products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page < (products.Rows.Count - 4))
            {
                page += 4;
                if(Convert.ToInt32(linkLabel4.Text) < ((products.Rows.Count/4) - 1 ))
                {
                    linkLabel3.Text = (Convert.ToInt32(linkLabel3.Text) + 1).ToString();
                    linkLabel4.Text = (Convert.ToInt32(linkLabel4.Text) + 1).ToString();
                }
                SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
                products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
                products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
                products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = 0;
            linkLabel3.Text = 3.ToString();
            linkLabel4.Text = 4.ToString();
            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
            products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
            products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
            products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = (Convert.ToInt32(linkLabel3.Text) * 4) - 4;
            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
            products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
            products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
            products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = (Convert.ToInt32(linkLabel4.Text)* 4) - 4;
            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
            products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
            products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
            products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = products.Rows.Count - 4;
            linkLabel3.Text = ((products.Rows.Count / 4) - 2).ToString();
            linkLabel4.Text = ((products.Rows.Count / 4) - 1).ToString();
            SelectPageData(products.Rows[page].ItemArray[5].ToString(), products.Rows[page].ItemArray[2].ToString(), products.Rows[page].ItemArray[4].ToString(), products.Rows[page].ItemArray[1].ToString(), products.Rows[page].ItemArray[3].ToString(),
            products.Rows[page + 1].ItemArray[5].ToString(), products.Rows[page + 1].ItemArray[2].ToString(), products.Rows[page + 1].ItemArray[4].ToString(), products.Rows[page + 1].ItemArray[1].ToString(), products.Rows[page + 1].ItemArray[3].ToString(),
            products.Rows[page + 2].ItemArray[5].ToString(), products.Rows[page + 2].ItemArray[2].ToString(), products.Rows[page + 2].ItemArray[4].ToString(), products.Rows[page + 2].ItemArray[1].ToString(), products.Rows[page + 2].ItemArray[3].ToString(),
            products.Rows[page + 3].ItemArray[5].ToString(), products.Rows[page + 3].ItemArray[2].ToString(), products.Rows[page + 3].ItemArray[4].ToString(), products.Rows[page + 3].ItemArray[1].ToString(), products.Rows[page + 3].ItemArray[3].ToString());
        }
    }
}
