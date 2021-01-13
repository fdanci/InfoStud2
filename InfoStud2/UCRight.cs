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

        public UCRight(int id, frmMain frmMain)
        {
            InitializeComponent();
            parent = frmMain;
            studentId = id;
        }

        private void LoadSubjects()
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

        private void UCRight_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }
    }
}
