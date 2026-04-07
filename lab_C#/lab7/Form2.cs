using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab6
{
    public partial class Form2 : Form
    {

        SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        BindingSource bs = new BindingSource();

        public Form2()
        {
            InitializeComponent();
            dataAdapter1.SelectCommand = new SqlCommand("Select * from Ведомости", DBConnection.Instance().Connection);
            dataAdapter1.Fill(ds1, "Ведомости");
            bs.DataSource = ds1;
            bs.DataMember = "Ведомости";

            dataGridView1.DataSource = bs;

            bindingNavigator1.BindingSource = bs;

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
