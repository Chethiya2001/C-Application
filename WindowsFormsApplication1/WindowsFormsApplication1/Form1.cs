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
namespace WindowsFormsApplication1


{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5FR5VA3;Initial Catalog=EMP;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void clear_controls()
        {
            tbxEmpID.Clear();
            tbxEmpName.Clear();
            tbxSalary.Clear();
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            tbxEmpID.Focus();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SqlSearch;
            SqlSearch = "select * from emp_table where empno='"+tbxEmpID.Text+"' ";
            SqlCommand cmd=new SqlCommand (SqlSearch,con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                tbxEmpName.Text = dr["name"].ToString();
                tbxSalary.Text = dr["salary"].ToString();

                String Gender;
                Gender = dr["gender"].ToString();
                if(Gender=="M")
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFemale.Checked = true;
                }
            con.Close();
                

            }
            else
            {
                MessageBox.Show("Not Found");
                clear_controls();
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string gender;
            if (rbtnMale.Checked == true)
                gender = "M";
            else
                gender = "F";

            string sqlinsert;
            sqlinsert = "insert into emp_table (empno,name,salary,gender) values('"+tbxEmpID.Text+"','"+tbxEmpName.Text+"','"+tbxSalary.Text+"','"+gender+"')";
            SqlCommand cmd = new SqlCommand(sqlinsert, con);
            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Inserted");
            clear_controls();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender;
            if (rbtnMale.Checked == true)
                gender = "M";
            else
                gender = "F";

            string sqlupdate;
            sqlupdate = "update emp_table set name='"+tbxEmpName.Text+"',salary='"+tbxSalary.Text+"', gender='"+gender+"' where empno='"+gender+"' ";
            SqlCommand cmd = new SqlCommand(sqlupdate, con);
            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show(" Succesfully Update... ");
            clear_controls();
            con.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Bye");
            Application.Exit();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Are you to Delete!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (ans==DialogResult.Yes)
            {
                string sqldelete;
                sqldelete = "delete from emp_table where empno ='" + tbxEmpID + "'";
                SqlCommand cmd = new SqlCommand(sqldelete, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                clear_controls();
                con.Close();
            }
        }
    }
}
