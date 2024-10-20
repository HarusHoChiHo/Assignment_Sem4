using System.ComponentModel;

namespace ChiHoHo_Lab2
{
    partial class ManageSubscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.byEmail      = new System.Windows.Forms.CheckBox();
            this.byMobile     = new System.Windows.Forms.CheckBox();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.phoneNumber  = new System.Windows.Forms.TextBox();
            this.invalidPhone = new System.Windows.Forms.Label();
            this.invalidEmail = new System.Windows.Forms.Label();
            this.subscribe    = new System.Windows.Forms.Button();
            this.unscribe     = new System.Windows.Forms.Button();
            this.cancel       = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // byEmail
            // 
            this.byEmail.Checked    = true;
            this.byEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.byEmail.Location = new System.Drawing.Point(
                                                             47,
                                                             69);
            this.byEmail.Name = "byEmail";
            this.byEmail.Size = new System.Drawing.Size(
                                                        182,
                                                        24);
            this.byEmail.TabIndex                =  0;
            this.byEmail.Text                    =  "Notification Sent By Email";
            this.byEmail.UseVisualStyleBackColor =  true;
            this.byEmail.CheckedChanged          += new System.EventHandler(this.ByEmail_Checked);
            // 
            // byMobile
            // 
            this.byMobile.Location = new System.Drawing.Point(
                                                              47,
                                                              137);
            this.byMobile.Name = "byMobile";
            this.byMobile.Size = new System.Drawing.Size(
                                                         182,
                                                         24);
            this.byMobile.TabIndex                =  1;
            this.byMobile.Text                    =  "Notification Sent By SMS";
            this.byMobile.UseVisualStyleBackColor =  true;
            this.byMobile.CheckedChanged          += new System.EventHandler(this.ByMobile_Checked);
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(
                                                                  251,
                                                                  69);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(
                                                             229,
                                                             22);
            this.emailAddress.TabIndex = 2;
            // 
            // phoneNumber
            // 
            this.phoneNumber.Enabled = false;
            this.phoneNumber.Location = new System.Drawing.Point(
                                                                 251,
                                                                 139);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(
                                                            229,
                                                            22);
            this.phoneNumber.TabIndex = 3;
            this.phoneNumber.Text     = "xxx-xxx-xxxx";
            // 
            // invalidPhone
            // 
            this.invalidPhone.Location = new System.Drawing.Point(
                                                                  251,
                                                                  164);
            this.invalidPhone.Name = "invalidPhone";
            this.invalidPhone.Size = new System.Drawing.Size(
                                                             229,
                                                             23);
            this.invalidPhone.TabIndex = 5;
            this.invalidPhone.Text     = "Invalid mobile number";
            this.invalidPhone.Visible  = false;
            // 
            // invalidEmail
            // 
            this.invalidEmail.Location = new System.Drawing.Point(
                                                                  251,
                                                                  94);
            this.invalidEmail.Name = "invalidEmail";
            this.invalidEmail.Size = new System.Drawing.Size(
                                                             229,
                                                             23);
            this.invalidEmail.TabIndex = 6;
            this.invalidEmail.Text     = "Invalid email address";
            this.invalidEmail.Visible  = false;
            // 
            // subscribe
            // 
            this.subscribe.Location = new System.Drawing.Point(
                                                               47,
                                                               207);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(
                                                          106,
                                                          45);
            this.subscribe.TabIndex                =  7;
            this.subscribe.Text                    =  "Subscribe";
            this.subscribe.UseVisualStyleBackColor =  true;
            this.subscribe.Click                   += new System.EventHandler(this.SubscribeBtn_Click);
            // 
            // unscribe
            // 
            this.unscribe.Location = new System.Drawing.Point(
                                                              194,
                                                              207);
            this.unscribe.Name = "unscribe";
            this.unscribe.Size = new System.Drawing.Size(
                                                         93,
                                                         45);
            this.unscribe.TabIndex                =  8;
            this.unscribe.Text                    =  "Unscribe";
            this.unscribe.UseVisualStyleBackColor =  true;
            this.unscribe.Click                   += new System.EventHandler(this.UnsubscribeBtn_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(
                                                            342,
                                                            207);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(
                                                       103,
                                                       45);
            this.cancel.TabIndex                =  9;
            this.cancel.Text                    =  "Cancel";
            this.cancel.UseVisualStyleBackColor =  true;
            this.cancel.Click                   += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ManageSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(
                                                                8F,
                                                                16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(
                                                      681,
                                                      264);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.unscribe);
            this.Controls.Add(this.subscribe);
            this.Controls.Add(this.invalidEmail);
            this.Controls.Add(this.invalidPhone);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.byMobile);
            this.Controls.Add(this.byEmail);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(
                                                     15,
                                                     15);
            this.Name = "ManageSubscription";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button subscribe;
        private System.Windows.Forms.Button unscribe;
        private System.Windows.Forms.Button cancel;

        private System.Windows.Forms.Label invalidEmail;

        private System.Windows.Forms.Label invalidPhone;

        private System.Windows.Forms.CheckBox byEmail;
        private System.Windows.Forms.CheckBox byMobile;
        private System.Windows.Forms.TextBox  emailAddress;
        private System.Windows.Forms.TextBox  phoneNumber;

        #endregion
    }
}