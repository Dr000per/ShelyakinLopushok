using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelyakinLopushok
{
    public partial class FormAdd : Form
    {
        DataBase db = new DataBase();
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            comboBox_product_type.Items.Clear();
            DataTable productTypes = db.ExecuteSql("select * from ProductType");
            foreach (DataRow row in productTypes.Rows)
            {

                comboBox_product_type.Items.Add(row.ItemArray[1]);
            }
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            if (Insert_But(textBox_title.Text, textBox_artic_num.Text, textBox_min_cost_for_ag.Text, textBox_image_path.Text, textBox_prod_per_count.Text, textBox_prod_workshop_num.Text, comboBox_product_type.SelectedItem))
            {
                MessageBox.Show("Продукт успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Не получилось!");
            }

        }

        public Boolean Insert_But(string title1, string article1, object mincost1, string image1, object pers_count1, object workshop_num1, object comboBox)
        {
            string title = title1;
            string article = article1;
            double mincost = Convert.ToDouble(mincost1);
            string image = image1;
            int pers_count = Convert.ToInt32(pers_count1);
            int workshop_num = Convert.ToInt32(workshop_num1);
            object comb_title = comboBox;
            try
            {
                db.ExecuteNonQuery($"insert into Product values ((select id from producttype where title = '{comb_title}'), '{title}', '{article}', {mincost}, '{image}', {pers_count}, {workshop_num});");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
