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
    public partial class frmMain : Form
    {
        public readonly string connectionString;
        public SqlConnection connection;


        public Panel PanelRight
        {
            get { return panelRight; }
            set { panelRight = value; }
        }

        public Panel PanelMain
        {
            get { return panelMain; }
            set { panelMain = value; }
        }


        public frmMain()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings[
                "InfoStud2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUCLogin();
        }

        /// <summary>
        /// Reread students from database and clear initial selection.
        /// </summary>
        public void ReloadStudents()
        {
            this.studentTableAdapter.Fill(this.database1DataSet.Student);
            gridStudents.ClearSelection();
        }

        /// <summary>
        /// Unselects selected students and removes any atached user controls on the right panel.
        /// </summary>
        private void ClearMainScreen()
        {
            gridStudents.ClearSelection();
            PanelRight.Controls.Clear();
        }


        /// <summary>
        /// Filter students grid when text has changed inside search textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = gridStudents.DataSource;
            bs.Filter = gridStudents.Columns[1].HeaderText.ToString() 
                + " LIKE '%" + txtSearch.Text + "%'";
            gridStudents.DataSource = bs;

            ClearUCPanel();
        }

        /// <summary>
        /// Removes any atached user control on the right panel.
        /// </summary>
        private void ClearUCPanel()
        {
            if (PanelRight.Controls.ContainsKey("UCRight"))
            {
                PanelRight.Controls.RemoveByKey("UCRight");
                gridStudents.ClearSelection();
            }
            else if (PanelRight.Controls.ContainsKey("UCNew"))
            {
                PanelRight.Controls.RemoveByKey("UCNew");
                gridStudents.ClearSelection();
            } 
            else
            {
                gridStudents.ClearSelection();
            }
        }


        /**
         * User controls.
         */

        private void GridStudents_CellClick(object sender, DataGridViewCellEventArgs e) { LoadUCRight(); }

        private void BtnNew_Click(object sender, EventArgs e) { LoadUCNewStudent(); }

        private void BtnReport_Click(object sender, EventArgs e) { LoadUCReport(); }


        /// <summary>
        /// Atach on the uc panel, the user control with details about a student.
        /// </summary>
        private void LoadUCRight()
        {
            PanelRight.Controls.Clear();
            int id = (int)gridStudents.CurrentRow.Cells[0].Value;
            string name = (string)gridStudents.CurrentRow.Cells[1].Value;
            string email = (string)gridStudents.CurrentRow.Cells[2].Value;
            string year = (string)gridStudents.CurrentRow.Cells[3].Value;
            UCRight ucRight = new UCRight(id, this, name, year, email);
            ucRight.Name = "UCRight";
            ucRight.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucRight);
        }

        public void LoadUCRight(int year)
        {
            PanelRight.Controls.Clear();
            int id = (int)gridStudents.CurrentRow.Cells[0].Value;
            string name = (string)gridStudents.CurrentRow.Cells[1].Value;
            string email = (string)gridStudents.CurrentRow.Cells[2].Value;
            UCRight ucRight = new UCRight(id, this, name, year.ToString(), email);
            ucRight.Name = "UCRight";
            ucRight.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucRight);
        }

        /// <summary>
        /// Atach on the uc panel the user control with means of adding new student in the system.
        /// </summary>
        private void LoadUCNewStudent()
        {
            ClearMainScreen();
            UCNewStudent ucNew = new UCNewStudent(this);
            ucNew.Name = "UCNew";
            ucNew.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucNew);
        }

        /// <summary>
        /// Atach on the uc panel the report user control.
        /// </summary>
        private void LoadUCReport()
        {
            ClearMainScreen();
            UCReport ucReport = new UCReport(this);
            ucReport.Name = "UCReport";
            ucReport.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucReport);
        }


        private void LoadUCLogin()
        {
            ClearMainScreen();
            UCLogin ucLogin = new UCLogin(this);
            ucLogin.Name = "UCLogin";
            ucLogin.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(ucLogin);
        }

        /// <summary>
        /// Hides/shows lefts side and right side content. 
        /// I use it to hide everything as long as login screen should be visible.
        /// </summary>
        public void SwapLeftRightVisibility()
        {
            PanelRight.Visible = !PanelRight.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;
            gridStudents.Visible = !gridStudents.Visible;
            lblSearch.Visible = !lblSearch.Visible;
            txtSearch.Visible = !txtSearch.Visible;
            btnNew.Visible = !btnNew.Visible;
            btnReport.Visible = !btnReport.Visible;
            btnLogout.Visible = !btnLogout.Visible;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SwapLeftRightVisibility();
            LoadUCLogin();
        }
    }
}