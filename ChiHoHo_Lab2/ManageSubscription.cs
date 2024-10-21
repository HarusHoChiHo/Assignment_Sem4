using System;
using System.Linq;
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
                    MainWindow.SendViaEmailList.Add(
                                                    new SendViaEmail()
                                                    {
                                                        Email = emailAddress.Text
                                                    });
                    invalidEmail.Hide();
                }
                else if (byMobile.Checked)
                {
                    MainWindow.SendViaMobileList.Add(
                                                     new SendViaMobile()
                                                     {
                                                         MobileNumber = phoneNumber.Text
                                                     });
                    invalidPhone.Hide();
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
                    MainWindow.SendViaEmailList.RemoveAll(email => email.Email.Equals(emailAddress.Text));
                    invalidEmail.Hide();
                }
                else if (byMobile.Checked)
                {
                    MainWindow.SendViaMobileList.RemoveAll(mobile => mobile.MobileNumber.Equals(phoneNumber.Text));
                    invalidPhone.Hide();
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
                byMobile.Checked    = false;

                emailAddress.Enabled = true;
            }
            else if (!byMobile.Checked && !byEmail.Checked)
            {
                byMobile.Checked = true;
            }
        }

        private void ByMobile_Checked(object    sender,
                                      EventArgs e)
        {
            if (byMobile.Checked)
            {
                invalidEmail.Hide();
                emailAddress.Enabled = false;
                byEmail.Checked      = false;

                phoneNumber.Enabled = true;
            } else if (!byMobile.Checked && !byEmail.Checked)
            {
                byEmail.Checked = true;
            }
        }

        private bool InputValidation(bool subscribeChecking = true)
        {
            Regex regexEmail  = new Regex("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+[.][a-zA-Z0-9_.-]+$");
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
                if (byEmail.Checked && (!regexEmail.IsMatch(emailAddress.Text)
                                     || MainWindow.SendViaEmailList.Exists(
                                                                           email =>
                                                                               email.Email.Equals(emailAddress.Text))))
                {
                    invalidEmail.Show();
                    return false;
                }
                else if (byMobile.Checked && (!regexMobile.IsMatch(phoneNumber.Text)
                                           || MainWindow.SendViaMobileList.Exists(
                                                                                  mobile =>
                                                                                      mobile.MobileNumber.Equals(
                                                                                                                 phoneNumber
                                                                                                                     .Text))))
                {
                    invalidPhone.Show();
                    return false;
                }
            }

            return true;
        }
    }
}