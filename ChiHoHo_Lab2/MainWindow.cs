using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChiHoHo_Lab2
{
    public partial class MainWindow : Form
    {
        public static List<SendViaEmail>  SendViaEmailList  = new List<SendViaEmail>();
        public static List<SendViaMobile> SendViaMobileList = new List<SendViaMobile>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageSubscription_Clicked(object    sender,
                                                EventArgs e)
        {
            Form manageSubscriptionForm = new ManageSubscription();
            manageSubscriptionForm.ShowDialog(this);
            if (SendViaEmailList.Count > 0 || SendViaMobileList.Count > 0)
            {
                publishNotification.Enabled = true;
            }
            else
            {
                publishNotification.Enabled = false;
            }
        }

        private void PublishNotification_Clicked(object    sender,
                                                 EventArgs e)
        {
            Form publishNotificationForm = new PublishNotification();
            publishNotificationForm.ShowDialog(this);
        }

        private void ExitBtn_Clicked(Object    sender,
                                     EventArgs e)
        {
            Application.Exit();
        }
    }
}