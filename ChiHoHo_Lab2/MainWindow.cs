using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChiHoHo_Lab2
{
    public partial class MainWindow : Form
    {
        public static List<String> SendViaEmail = new List<String>();
        public static List<String> SendViaMobile = new List<String>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageSubscription_Clicked(object    sender,
                                                EventArgs e)
        {
            Form manageSubscriptionForm = new ManageSubscription();
            manageSubscriptionForm.ShowDialog(this);
            if (SendViaEmail.Count > 0 || SendViaMobile.Count > 0)
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