﻿using System;
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
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            gridDetails.DataSource = dt;

                            // Prevent user from editing first two columns.
                            gridDetails.Columns[0].ReadOnly = true;
                            gridDetails.Columns[1].ReadOnly = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SwapEditSaveMode();
            gridDetails.Columns[2].DefaultCellStyle.BackColor = Color.White;
            SaveChanges();
        }

        /// <summary>
        /// Read grades from each row of the grid and update the database.
        /// </summary>
        private void SaveChanges()
        {
            var valuesToSave = new Dictionary<int, String>();

            if (gridDetails.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in gridDetails.Rows)
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
        /// Parse each grade and update it in database.
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

                            int numRes = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SwapEditSaveMode();
            gridDetails.Columns[2].DefaultCellStyle.BackColor = Color.Yellow;
        }

        /// <summary>
        /// Change state between edit mode and save mode.
        /// </summary>
        private void SwapEditSaveMode()
        {
            btnEdit.Visible = !btnEdit.Visible;
            btnSave.Visible = !btnSave.Visible;
            btnDelete.Enabled = !btnDelete.Enabled;
            btnCancel.Visible = !btnCancel.Visible;
            btnClose.Visible = !btnClose.Visible;
            gridDetails.Enabled = !gridDetails.Enabled;
            lblHint.Visible = !lblHint.Visible;
            lblTitleDetails.Visible = !lblTitleDetails.Visible;
            lblTitleEdit.Visible = !lblTitleEdit.Visible;
        }

        /// <summary>
        /// Unselect details grid first cell when grid is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridDetails.ClearSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SwapEditSaveMode();
            gridDetails.Columns[2].DefaultCellStyle.BackColor = Color.White;
        }
    }
}