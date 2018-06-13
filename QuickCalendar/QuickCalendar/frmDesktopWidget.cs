using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace QuickCalendar
{
    public partial class frmDesktopWidget : Form
    {
        public frmDesktopWidget()
        {
            InitializeComponent();
        }

        private void createAppointment(string startTime, string endTime, String subject, String body, int busyStat)
        {
            Outlook._Application _app = new Outlook.Application();
            Outlook.AppointmentItem ai = (Outlook.AppointmentItem)_app.CreateItem(Outlook.OlItemType.olAppointmentItem);



            //MessageBox.Show("startTimeString: " + startTime + " endTime: " + endTime, "data", MessageBoxButtons.OK);
            ai.Subject = subject;
            ai.AllDayEvent = false;
            ai.Start = DateTime.Parse(startTime);
            ai.End = DateTime.Parse(endTime);

            switch (busyStat)
            {
                case 0:
                    ai.BusyStatus = Outlook.OlBusyStatus.olFree;
                    break;
                case 1:
                    ai.BusyStatus = Outlook.OlBusyStatus.olTentative;
                    break;
                case 2:
                    ai.BusyStatus = Outlook.OlBusyStatus.olBusy;
                    break;
                case 3:
                    ai.BusyStatus = Outlook.OlBusyStatus.olOutOfOffice;
                    break;


            }

            ai.Body = body;
            ai.Save();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DateTime leadWay = DateTime.Now.AddMinutes(Properties.Settings.Default.button1TimePadding);
            DateTime currentTime = DateTime.Now.AddHours(1).AddMinutes(5);
            string startTimeString = leadWay.ToString("HH:mm tt");
            string endTimeString = currentTime.ToString("HH:mm tt");
            int busy = 3;

            createAppointment(startTimeString, endTimeString, "Lunch", "Lunch, Eatting Lunch. Call me on my cell if it's an emergency", busy);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DateTime leadWay = DateTime.Now.AddMinutes(Properties.Settings.Default.button2TimePadding);
            DateTime currentTime = DateTime.Now.AddMinutes(20);
            string startTimeString = leadWay.ToString("HH:mm tt");
            string endTimeString = currentTime.ToString("HH:mm tt");
            int busy = 1;

            createAppointment(startTimeString, endTimeString, "Walk", "Walking, call me on my cell if you need me.  If I'm not back in 15 minutes, something must be wrong. For quick questions I have slack mobile", busy);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            DateTime leadWay = DateTime.Now.AddMinutes(Properties.Settings.Default.button3TimePadding);
            DateTime currentTime = DateTime.Now.AddMinutes(65);
            string startTimeString = leadWay.ToString("HH:mm tt");
            string endTimeString = currentTime.ToString("HH:mm tt");
            string subject = Properties.Settings.Default.button3Subject;
            string body = Properties.Settings.Default.button3Wording;
            int busy = Properties.Settings.Default.button3ShowAs;

            createAppointment(startTimeString, endTimeString, subject, body, busy);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Opacity = .90;

            btn1.Text = Properties.Settings.Default.button1Title;
            btn2.Text = Properties.Settings.Default.button2Title;
            btn3.Text = Properties.Settings.Default.button3Title;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if(toolStripMenuItem3.Text.Contains("Move")){
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                toolStripMenuItem3.Text = "Anchor";
                toolStripMenuItem4.Text = "Anchor";
            }
            else{
                this.FormBorderStyle = FormBorderStyle.None;
                toolStripMenuItem3.Text = "Move";
                toolStripMenuItem4.Text = "Move";
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.Show();
        }
    }
}
