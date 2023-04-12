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
                    db.ExecuteNonQuery($"update product set MinCostForAgent = {(object)textBox1.Text} where articlenumber = '{form.products.Rows[form.page].ItemArray[3]}'");
                    form.products = db.ExecuteSql($"select  product.id, producttype.title, product.title, product.articlenumber, product.MinCostForAgent, product.Image, product.ProductionPersonCount, product.ProductionWorkshopNumber from product, producttype where product.ProductTypeID = producttype.id");
                    form.SelectPageData(form.products.Rows[form.page].ItemArray[5].ToString(), form.products.Rows[form.page].ItemArray[2].ToString(), form.products.Rows[form.page].ItemArray[4].ToString(), form.products.Rows[form.page].ItemArray[1].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Не удалось поменять стоимость продукции");
            }
            form.SelectPageData(form.products.Rows[form.page].ItemArray[5].ToString(), form.products.Rows[form.page].ItemArray[2].ToString(), form.products.Rows[form.page].ItemArray[4].ToString(), form.products.Rows[form.page].ItemArray[1].ToString());
            this.Close();
        }
        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
