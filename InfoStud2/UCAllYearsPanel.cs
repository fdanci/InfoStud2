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

        public UCAllYearsPanel(frmMain frmMain, int studentId, int rowIndex)
        {
            InitializeComponent();
            parent = frmMain;
            this.studentId = studentId;
            this.rowIndex = rowIndex;
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
            // Todo load one by one all UC Controls
        }
    }
}
