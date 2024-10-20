using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChiHoHo_Lab2
{
    public partial class ManageSubscription : Form
    {
        public ManageSubscription()
        {
            InitializeComponent();
        }

        private void SubscribeBtn_Click(object    sender,
                                        EventArgs e)
        {
            if (InputValidation())
            {
                if (byEmail.Checked)
                {
                    MainWindow.SendViaEmail.Add(emailAddress.Text);
                }
                else if (byMobile.Checked)
                {
                    MainWindow.SendViaMobile.Add(phoneNumber.Text);
                }
                MessageBox.Show("Subscribed successfully");
            }
            else
            {
                MessageBox.Show("Please check your email or phone number.");
            }
        }

        private void UnsubscribeBtn_Click(object    sender,
                                          EventArgs e)
        {
            if (InputValidation(false))
            {
                if (byEmail.Checked)
                {
                    MainWindow.SendViaEmail.Remove(emailAddress.Text);
                }
                else if (byMobile.Checked)
                {
                    MainWindow.SendViaMobile.Remove(phoneNumber.Text);
                }
                MessageBox.Show("Unsubscribed successfully");
            }
            else
            {
                MessageBox.Show("Please check your email or phone number.");
            }
        }

        private void CancelBtn_Click(object    sender,
                                     EventArgs e)
        {
            Close();
        }

        private void ByEmail_Checked(object    sender,
                                     EventArgs e)
        {
            if (byEmail.Checked)
            {
                invalidPhone.Hide();
                phoneNumber.Enabled = false;
                byMobile.Checked = false;

                emailAddress.Enabled = true;
            }
        }
        
        private void ByMobile_Checked(object    sender,
                                               EventArgs e)
        {
            if (byMobile.Checked)
            {
                invalidEmail.Hide();
                emailAddress.Enabled = false;
                byEmail.Checked = false;
                
                phoneNumber.Enabled = true;
            }
        }
        
        private bool InputValidation(bool subscribeChecking = true)
        {
            Regex regexEmail  = new Regex("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+.[a-zA-Z0-9_.-]+$");
            Regex regexMobile = new Regex("^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
            
            if (!subscribeChecking)
            {
                if (byEmail.Checked && !regexEmail.IsMatch(emailAddress.Text))
                {
                    invalidEmail.Show();
                    return false;
                }
                else if (byMobile.Checked && !regexMobile.IsMatch(phoneNumber.Text))
                {
                    invalidPhone.Show();
                    return false;
                }
            }
            else
            {
                if (byEmail.Checked && (!regexEmail.IsMatch(emailAddress.Text) || MainWindow.SendViaEmail.Contains(emailAddress.Text)))
                {
                    invalidEmail.Show();
                    return false;
                }
                else if (byMobile.Checked && (!regexMobile.IsMatch(phoneNumber.Text) || MainWindow.SendViaMobile.Contains(phoneNumber.Text)))
                {
                    invalidPhone.Show();
                    return false;
                }
            }
            
            return true;
        }
    }
}