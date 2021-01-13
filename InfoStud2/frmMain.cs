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


        public frmMain()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings[
                "InfoStud2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.database1DataSet.Student);
            gridStudents.ClearSelection();
        }

        public void ReloadStudents()
        {
            this.studentTableAdapter.Fill(this.database1DataSet.Student);
            gridStudents.ClearSelection();
        }

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

        private void LoadUCNewStudent()
        {
            PanelRight.Controls.Clear();
            UCNewStudent ucNew = new UCNewStudent(this);
            ucNew.Name = "UCNew";
            ucNew.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucNew);
        }

        private void gridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadUCRight();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadUCNewStudent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = gridStudents.DataSource;
            bs.Filter = gridStudents.Columns[1].HeaderText.ToString() + " LIKE '%" + txtSearch.Text + "%'";
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
    }
}