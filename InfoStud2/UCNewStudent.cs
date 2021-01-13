using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace InfoStud2
{
    public partial class UCNewStudent : UserControl
    {
        private readonly frmMain parent;
        private bool nameValid = false;
        private bool emailValid = false;
        private bool yearValid = false;

        public UCNewStudent(frmMain frmMain)
        {
            InitializeComponent();
            parent = frmMain;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            parent.PanelRight.Controls.RemoveByKey("UCNew");
            parent.gridStudents.ClearSelection();
        }

        private void UCNewStudent_Load(object sender, EventArgs e)
        {
            PopulateComboYear();
        }

        private void PopulateComboYear()
        {
            string[] items = {
                "1",
                "2",
                "3",
                "4"
            };

  
            comboYear.DataSource = items;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.BackColor = Color.Red;
                nameValid = false;
            }
            else
            {
                txtName.BackColor = Color.White;
                nameValid = true;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.Red;
                emailValid = false;
            }
            else
            {
                txtEmail.BackColor = Color.White;
                emailValid = true;
            }
        }

        private void comboYear_Validating(object sender, CancelEventArgs e)
        {
            if (comboYear.Text == "")
            {
                comboYear.BackColor = Color.Red;
                yearValid = false;
            }
            else
            {
                comboYear.BackColor = Color.White;
                yearValid = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!nameValid || !emailValid || !yearValid)
            {
                MessageBox.Show("Enter valid data!");
            }
            else
            {
                AddNewStudent();
            }
        }

        private void AddNewStudent()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(parent.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateStudent", conn))
                    {
                        conn.Open();

                        string year = (string)comboYear.SelectedValue;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentName", txtName.Text.ToString());
                        cmd.Parameters.AddWithValue("@StudentEmail", txtEmail.Text.ToString());
                        cmd.Parameters.AddWithValue("@StudentYear", comboYear.SelectedValue.ToString());

                        int numRes = cmd.ExecuteNonQuery();

                        if (numRes > 0)
                        {
                            MessageBox.Show("Student added!");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!");
                        }
                    }
                }

                parent.PanelRight.Controls.RemoveByKey("UCNew");
                parent.ReloadStudents();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
