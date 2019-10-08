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
using System.Data.Sql;

namespace askwinform
{
    public partial class Form1 : Form
    {
        private DataGridView view1 = new DataGridView();
        private BindingSource binding1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        private void GetData(string selectCommand)
        {
            SqlConnection mycon = new SqlConnection("Data Source=laptop-cl08flf2;Initial Catalog=hospital;Integrated Security=SSPI");
            SqlDataAdapter myada = new SqlDataAdapter(selectCommand, mycon);
            SqlCommandBuilder combui = new SqlCommandBuilder(myada);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            myada.Fill(table);
            binding1.DataSource = table;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
          dataGridView1.DataSource = binding1;
            GetData("with cte as( select distinct patient_info.name, pd_info.number, pd_info.category, pd_info.expe, going from patient_info, doctor_info, pd_info where differ = 'true' and pd_info.phone = patient_info.phone ) select name as '姓名',number as '编号',category as '科室',expe as '门诊类别',going as '当前状态' from cte order by number");

        }

      
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = binding1;
            GetData("with cte as( select distinct patient_info.name, pd_info.number, pd_info.category, pd_info.expe, going, pd_info.address from patient_info, doctor_info, pd_info where differ = 'true' and pd_info.phone = patient_info.phone) select name as '姓名',number as '编号',category as '科室',expe as '门诊类别',address as '诊室',going as '当前状态' from cte order by number");

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
