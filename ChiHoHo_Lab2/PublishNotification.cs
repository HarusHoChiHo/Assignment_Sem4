using System;
using System.Windows.Forms;

namespace ChiHoHo_Lab2
{
    public partial class PublishNotification : Form
    {
        public PublishNotification()
        {
            InitializeComponent();
        }

        private void PublishBtn_Click(object    sender,
                                      EventArgs e)
        {
            string emailList    = $"\n\nEmail:\n{String.Join(",", MainWindow.SendViaEmailList)}";
            string phoneNumList = $"\n\nPhone number:\n{String.Join(",", MainWindow.SendViaMobileList)}";
            string fullMessage = $"Message \"{notificationContent.Text}\" is published successfully";
            if (MainWindow.SendViaEmailList.Count > 0)
            {
                fullMessage += emailList;
            }

            if (MainWindow.SendViaMobileList.Count > 0)
            {
                fullMessage += phoneNumList;
            }
            MessageBox.Show(fullMessage);
        }
        
        private void CancelBtn_Click(object    sender,
                                        EventArgs e)
        {
            Close();
        }
    }
}