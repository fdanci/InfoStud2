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
    public partial class UCRight : UserControl
    {
        private readonly frmMain parent;
        private readonly int studentId;
        private readonly string studentName;
        private readonly string studentYear;
        private readonly string studentEmail;

        public UCRight(int id, frmMain frmMain, string name, string year, string email)
        {
            InitializeComponent();
            parent = frmMain;
            studentId = id;
            studentName = name;
            studentYear = year;
            studentEmail = email;
        }

        /// <summary>
        /// Read subjects from database, by given id of the selected student.
        /// </summary>
        private void LoadSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(parent.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetStudentSubjects", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            gridDetails.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void UCRight_Load(object sender, EventArgs e)
        {
            lblName.Text = studentName;
            lblEmail.Text = studentEmail;
            lblYear.Text = $"Year: {studentYear}";
            LoadSubjects();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            parent.PanelRight.Controls.RemoveByKey("UCRight");
            parent.gridStudents.ClearSelection();
        }

        /// <summary>
        /// Delete selected student from database and close the details user control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(parent.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteStudent", conn))
                    {
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", studentId);

                        int numRes = cmd.ExecuteNonQuery();

                        if (numRes > 0)
                        {
                            MessageBox.Show("Student deleted!");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!");
                        }
                    }
                }

                parent.PanelRight.Controls.RemoveByKey("UCRight");
                parent.ReloadStudents();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
