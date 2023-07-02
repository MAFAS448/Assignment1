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

namespace Assignment1
{
    public partial class AddEditEmployeeForm : Form
    {
        public AddEditEmployeeForm(string firstName, string lastName)
        {
            InitializeComponent();
        }

        public AddEditEmployeeForm(string firstName, string lastName, string department, float salary) : this(firstName, lastName)
        {
        }

        public AddEditEmployeeForm()
        {
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G73F02P\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = textBox1.Text, LastName = textBox2.Text, Department = textBox3.Text;
            float Salary = float.Parse(textBox4.Text);
          
            con.Open();
            SqlCommand c = new SqlCommand("exec AddEmployee '"+FirstName+ "','"+LastName+ "','"+Department+ "','"+Salary+"' ", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Successfully Added...");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                string department = textBox3.Text;
                float salary = float.Parse(textBox4.Text);

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-G73F02P\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UpdateEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                       // cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Salary", salary);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Successfully Updated...");

              
                this.Close();
                
           


        }
    }
}
