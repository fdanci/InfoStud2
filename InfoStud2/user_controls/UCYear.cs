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
    public partial class UCYear : UserControl
    {
        private frmMain parent;
        private string year;
        private int studentId;

        public UCYear(frmMain frmMain, string year, int studentId)
        {
            InitializeComponent();
            parent = frmMain;
            this.year = year;
            this.studentId = studentId;
        }

        private void UCYear_Load(object sender, EventArgs e)
        {
            lblYear.Text = $"Year {year}";
            LoadSubjects();
        }

        /// <summary>
        /// Read subjects from database by given id of the selected student, fill subjects grid.
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
                        cmd.Parameters.AddWithValue("@Year", year);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            gridYear.DataSource = dt;

                            // Prevent user from editing first two columns.
                            gridYear.Columns[0].ReadOnly = true;
                            gridYear.Columns[1].ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// Saves changes to database.
        /// </summary>
        public void SaveChanges()
        {
            var valuesToSave = new Dictionary<int, String>();

            if (gridYear.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in gridYear.Rows)
                {
                    int id = (int)row.Cells[0].Value;
                    string grade = "";

                    // Prevent null values from crashing the app.
                    if (row.Cells[2].Value != DBNull.Value)
                    {
                        grade = (string)row.Cells[2].Value;
                    }
                    valuesToSave.Add(id, grade);
                }
            }
            UpdateDatabase(valuesToSave);
        }

        /// <summary>
        /// Parse each grade and update it in database. The values to save come as (grade id - grade).
        /// </summary>
        /// <param name="valuesToSave"></param>
        private void UpdateDatabase(Dictionary<int, string> valuesToSave)
        {
            try
            {
                foreach (KeyValuePair<int, string> entry in valuesToSave)
                {
                    using (SqlConnection conn = new SqlConnection(parent.connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateGrade", conn))
                        {
                            conn.Open();

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@GradeId", entry.Key);
                            cmd.Parameters.AddWithValue("@Grade", entry.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// Unselect grid's first cell when grid is loaded. 
        /// This fixed annoying first cell getting selected after each grid load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridYear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridYear.ClearSelection();
        }

        public void EnterEditState(bool editState)
        {
            if(editState)
                gridYear.Columns[2].DefaultCellStyle.BackColor = Color.Yellow;
            else
                gridYear.Columns[2].DefaultCellStyle.BackColor = Color.White;
        }
    }
}
