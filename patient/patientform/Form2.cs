using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace patientform
{
    public partial class Form2 : Form
    {
        SqlConnection mycon = new SqlConnection("Data Source=laptop-cl08flf2;Initial Catalog=hospital;Integrated Security=SSPI");
       
        public Form2()
        {
            InitializeComponent();
            mycon.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

      
        private void button4_Click(object sender, EventArgs e)
        {
            string insert1 = "insert into patient_info(name,sex,phone,idno,identity1) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + listBox1.Text + "')";
            SqlCommand con = new SqlCommand(insert1, mycon);
            con.ExecuteNonQuery();
            SqlDataAdapter mydataadapter = new SqlDataAdapter("select * from patient_info", mycon);
            DataSet mypatient = new DataSet();
            mydataadapter.Fill(mypatient, "patient_info");
            MessageBox.Show("提交成功");
            Form3 frm3 = new Form3();
            new Form3().Show();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
