namespace ChiHoHo_Lab2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.manageSubscription  = new System.Windows.Forms.Button();
            this.publishNotification = new System.Windows.Forms.Button();
            this.exitBtn             = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageSubscription
            // 
            this.manageSubscription.Location = new System.Drawing.Point(
                                                                        13,
                                                                        86);
            this.manageSubscription.Margin = new System.Windows.Forms.Padding(4);
            this.manageSubscription.Name   = "manageSubscription";
            this.manageSubscription.Size = new System.Drawing.Size(
                                                                   150,
                                                                   66);
            this.manageSubscription.TabIndex                =  0;
            this.manageSubscription.Text                    =  "Manage Subscription";
            this.manageSubscription.UseVisualStyleBackColor =  true;
            this.manageSubscription.Click                   += new System.EventHandler(this.ManageSubscription_Clicked);
            // 
            // publishNotification
            // 
            this.publishNotification.Enabled = false;
            this.publishNotification.Location = new System.Drawing.Point(
                                                                         172,
                                                                         86);
            this.publishNotification.Margin = new System.Windows.Forms.Padding(4);
            this.publishNotification.Name   = "publishNotification";
            this.publishNotification.Size = new System.Drawing.Size(
                                                                    150,
                                                                    66);
            this.publishNotification.TabIndex                = 1;
            this.publishNotification.Text                    = "Publish Notification";
            this.publishNotification.UseVisualStyleBackColor = true;
            this.publishNotification.Click += new System.EventHandler(this.PublishNotification_Clicked);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(
                                                             330,
                                                             86);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(
                                                        150,
                                                        66);
            this.exitBtn.TabIndex                =  2;
            this.exitBtn.Text                    =  "Exit";
            this.exitBtn.UseVisualStyleBackColor =  true;
            this.exitBtn.Click                   += new System.EventHandler(this.ExitBtn_Clicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(
                                                                8F,
                                                                16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(
                                                      492,
                                                      228);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.publishNotification);
            this.Controls.Add(this.manageSubscription);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name   = "MainWindow";
            this.Text   = "Notification Manager";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button exitBtn;

        private System.Windows.Forms.Button manageSubscription;
        private System.Windows.Forms.Button publishNotification;
        

        #endregion
    }
}