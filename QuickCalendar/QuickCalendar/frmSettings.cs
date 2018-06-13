using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickCalendar
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }


        private void chkBtn1Pad_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBtn1Pad.Checked.Equals(false))
            {
                lblBtn1Pad.Enabled.Equals(false);
                txtBtn1Pad.Enabled.Equals(false);
            }
            else
            {
                lblBtn1Pad.Enabled.Equals(true);
                txtBtn1Pad.Enabled.Equals(true);
            }
        }

        private void chkBtn2Pad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtn2Pad.Checked.Equals(false))
            {
                lblBtn2Pad.Enabled.Equals(false);
                txtBtn2Pad.Enabled.Equals(false);
            }
            else
            {
                lblBtn2Pad.Enabled.Equals(true);
                txtBtn2Pad.Enabled.Equals(true);
            }
        }

        private void chkBtn3Pad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtn3Pad.Checked.Equals(false))
            {
                lblBtn3Pad.Enabled.Equals(false);
                txtBtn3Pad.Enabled.Equals(false);
            }
            else
            {
                lblBtn3Pad.Enabled.Equals(true);
                txtBtn3Pad.Enabled.Equals(true);
            }
        }
    }
}
