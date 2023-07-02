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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G73F02P\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           AddEditEmployeeForm addEditEmployeeForm = new AddEditEmployeeForm();
            addEditEmployeeForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            GetEmpList();
        }

        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec GetEmployees", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Get the selected employee's information from the row

                string firstName = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lastName = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string department = dataGridView1.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                float salary = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["Salary"].Value.ToString());

                // Open the AddEditEmployeeForm with the corresponding employee's information
                AddEditEmployeeForm addEditForm1 = new AddEditEmployeeForm(firstName, lastName, department, salary);
                addEditForm1.ShowDialog();

            }
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDepartment = comboBoxDepartment.SelectedItem.ToString();
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $"Department = '{selectedDepartment}'";
        }
    }
}
