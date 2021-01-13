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
    public partial class UCReport : UserControl
    {
        private frmMain parent;

        public UCReport(frmMain frmMain)
        {
            InitializeComponent();
            parent = frmMain;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            parent.PanelRight.Controls.RemoveByKey("UCReport");
            parent.gridStudents.ClearSelection();
        }
    }
}
