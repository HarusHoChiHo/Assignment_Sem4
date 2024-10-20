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
            MessageBox.Show("Message is published successfully");
        }
        
        private void CancelBtn_Click(object    sender,
                                        EventArgs e)
        {
            Close();
        }
    }
}