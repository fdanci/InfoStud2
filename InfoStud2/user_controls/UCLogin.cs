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
    public partial class UCLogin : UserControl
    {
        private readonly frmMain parent;

        public UCLogin(frmMain frmMain)
        {
            InitializeComponent();
            parent = frmMain;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            parent.PanelMain.Controls.RemoveByKey("UCLogin");
            parent.SwapLoginState();
            parent.ReloadStudents();
        }

        private void UCLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
