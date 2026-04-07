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
    public partial class Form4 : Form
    {

        SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        BindingSource bs = new BindingSource();

        public Form4()
        {
            InitializeComponent();
            dataAdapter1.SelectCommand = new SqlCommand("Select * from Кафедры", DBConnection.Instance().Connection);
            dataAdapter1.Fill(ds1, "Кафедры");
            bs.DataSource = ds1;
            bs.DataMember = "Кафедры";

            dataGridView1.DataSource = bs;

            bindingNavigator1.BindingSource = bs;


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
