using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace QuickCalendar
{
    public class OutlookFunctions
    {


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
    }
}
