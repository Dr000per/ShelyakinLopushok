using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShelyakinLopushok
{
    public partial class UpdateForm : Form
    {
        MainForm form;
        public UpdateForm(MainForm form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataBase db = new DataBase())
                {
                    object price1_now = Convert.ToDouble(form.products.Rows[form.page].ItemArray[3]);
                    object price2_now = Convert.ToDouble(form.products.Rows[form.page + 1].ItemArray[3]);
                    object price3_now = Convert.ToDouble(form.products.Rows[form.page + 2].ItemArray[3]);
                    object price4_now = Convert.ToDouble(form.products.Rows[form.page + 3].ItemArray[3]);

                    object price1_new = price1_now;
                    object price2_new = price2_now;
                    object price3_new = price3_now;
                    object price4_new = price4_now;
                    if (checkBox1.Checked)
                    {
                        price1_new = Convert.ToDouble(textBox1.Text);
                        db.ExecuteNonQuery($"update product set MinCostForAgent = {price1_new} where articlenumber = '{form.products.Rows[form.page].ItemArray[3]}';");
                    }
                    if (checkBox2.Checked)
                    {
                        price2_new = Convert.ToDouble(textBox2.Text);
                        db.ExecuteNonQuery($"update product set MinCostForAgent = {price2_new} where articlenumber = '{form.products.Rows[form.page + 1].ItemArray[3]}';");
                    }
                    if (checkBox3.Checked)
                    {
                        price3_new = Convert.ToDouble(textBox3.Text);
                        db.ExecuteNonQuery($"update product set MinCostForAgent = {price3_new} where articlenumber = '{form.products.Rows[form.page + 2].ItemArray[3]}';");
                    }
                    if (checkBox4.Checked)
                    {
                        price4_new = Convert.ToDouble(textBox4.Text);
                        db.ExecuteNonQuery($"update product set MinCostForAgent = {price4_new} where articlenumber = '{form.products.Rows[form.page + 3].ItemArray[3]}';");
                    }
                    form.products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
                    form.SelectPageData(form.products.Rows[form.page].ItemArray[5].ToString(), form.products.Rows[form.page].ItemArray[2].ToString(), form.products.Rows[form.page].ItemArray[4].ToString(), form.products.Rows[form.page].ItemArray[1].ToString(), form.products.Rows[form.page].ItemArray[3].ToString(),
                    form.products.Rows[form.page + 1].ItemArray[5].ToString(), form.products.Rows[form.page + 1].ItemArray[2].ToString(), form.products.Rows[form.page + 1].ItemArray[4].ToString(), form.products.Rows[form.page + 1].ItemArray[1].ToString(), form.products.Rows[form.page + 1].ItemArray[3].ToString(),
                    form.products.Rows[form.page + 2].ItemArray[5].ToString(), form.products.Rows[form.page + 2].ItemArray[2].ToString(), form.products.Rows[form.page + 2].ItemArray[4].ToString(), form.products.Rows[form.page + 2].ItemArray[1].ToString(), form.products.Rows[form.page + 2].ItemArray[3].ToString(),
                    form.products.Rows[form.page + 3].ItemArray[5].ToString(), form.products.Rows[form.page + 3].ItemArray[2].ToString(), form.products.Rows[form.page + 3].ItemArray[4].ToString(), form.products.Rows[form.page + 3].ItemArray[1].ToString(), form.products.Rows[form.page + 3].ItemArray[3].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Не удалось поменять стоимость продукции");
            }
            form.SelectPageData(form.products.Rows[form.page].ItemArray[5].ToString(), form.products.Rows[form.page].ItemArray[2].ToString(), form.products.Rows[form.page].ItemArray[4].ToString(), form.products.Rows[form.page].ItemArray[1].ToString(), form.products.Rows[form.page].ItemArray[3].ToString(),
                form.products.Rows[form.page + 1].ItemArray[5].ToString(), form.products.Rows[form.page + 1].ItemArray[2].ToString(), form.products.Rows[form.page + 1].ItemArray[4].ToString(), form.products.Rows[form.page + 1].ItemArray[1].ToString(), form.products.Rows[form.page + 1].ItemArray[3].ToString(),
                form.products.Rows[form.page + 2].ItemArray[5].ToString(), form.products.Rows[form.page + 2].ItemArray[2].ToString(), form.products.Rows[form.page + 2].ItemArray[4].ToString(), form.products.Rows[form.page + 2].ItemArray[1].ToString(), form.products.Rows[form.page + 2].ItemArray[3].ToString(),
                form.products.Rows[form.page + 3].ItemArray[5].ToString(), form.products.Rows[form.page + 3].ItemArray[2].ToString(), form.products.Rows[form.page + 3].ItemArray[4].ToString(), form.products.Rows[form.page + 3].ItemArray[1].ToString(), form.products.Rows[form.page + 3].ItemArray[3].ToString());
            this.Close();
        }
        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
