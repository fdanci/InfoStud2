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
            UCRight ucRight = new UCRight(id, this);
            ucRight.Name = "UCRight";
            ucRight.Dock = DockStyle.Fill;
            PanelRight.Controls.Add(ucRight);
        }

        private void gridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadUCRight();
        }
    }
}