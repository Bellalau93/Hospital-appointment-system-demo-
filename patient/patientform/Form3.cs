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
    public partial class Form3 : Form
    {
        SqlConnection mycon = new SqlConnection("Data Source=laptop-cl08flf2;Initial Catalog=hospital;Integrated Security=SSPI");
        public Form3()
        {
            InitializeComponent();
            mycon.Open();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.number++; 
            //string  insert1=" insert into patient_info(category,expe,phone,number) values('"+listBox1.Text+"','"+listBox2.Text+"','"+textBox1.Text+"','"+Class1.number+"') ";
            string insert2 = "insert into pd_info(number,category,expe,differ,going,phone) values('" + Class1.number + "','" + listBox1.Text + "','" + listBox2.Text + "','true','等待中','"+textBox1.Text+"')";
            SqlCommand insertcon = new SqlCommand(insert2, mycon);
            insertcon.ExecuteNonQuery();
            SqlDataAdapter mydataadapter = new SqlDataAdapter("select * from patient_info", mycon);
            DataSet mypatient = new DataSet();
            mydataadapter.Fill(mypatient, "patient_info");
            MessageBox.Show("提交成功,请耐心等待叫号");
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
