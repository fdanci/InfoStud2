using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoStud2
{
    /// <summary>
    /// Acts as a panel. Contains inside other user control cildren.
    /// </summary>
    public partial class UCAllYearsPanel : UserControl
    {
        private frmMain parent;
        private int studentId;
        private int rowIndex;
        private string studentName;
        private string studentEmail;
        private string year;

        public UCAllYearsPanel(frmMain frmMain, int studentId, 
            int rowIndex, string name, string email, string year)
        {
            InitializeComponent();
            parent = frmMain;
            this.studentId = studentId;
            this.rowIndex = rowIndex;
            studentName = name;
            studentEmail = email;
            this.year = year;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            parent.PanelMain.Controls.RemoveByKey("UCAllYears");
            parent.SwapLeftRightVisibility();
            parent.gridStudents.Rows[rowIndex].Selected = true;
            parent.LoadUCRight();
        }

        private void UCAllYearsPanel_Load(object sender, EventArgs e)
        {
            lblName.Text = studentName;
            lblEmail.Text = studentEmail;

            LoadUCYear(panelY1, "1");
            LoadUCYear(panelY2, "2");
            LoadUCYear(panelY3, "3");
            LoadUCYear(panelY4, "4");
        }

        public void LoadUCYear(Panel panel, string year)
        {
            panel.Controls.Clear();

            UCYear ucRight = new UCYear(parent, year, studentId);
            ucRight.Name = "UCYear" + year;
            ucRight.Dock = DockStyle.Fill;
            panel.Controls.Add(ucRight);
        }
    }
}
