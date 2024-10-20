using System.ComponentModel;

namespace ChiHoHo_Lab2
{
    partial class PublishNotification
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
            this.notiContent         = new System.Windows.Forms.Label();
            this.notificationContent = new System.Windows.Forms.TextBox();
            this.publish             = new System.Windows.Forms.Button();
            this.Exit                = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notiContent
            // 
            this.notiContent.Location = new System.Drawing.Point(
                                                                 75,
                                                                 76);
            this.notiContent.Name = "notiContent";
            this.notiContent.Size = new System.Drawing.Size(
                                                            122,
                                                            23);
            this.notiContent.TabIndex = 0;
            this.notiContent.Text     = "Notification Content";
            // 
            // notificationContent
            // 
            this.notificationContent.Location = new System.Drawing.Point(
                                                                         203,
                                                                         73);
            this.notificationContent.Name = "notificationContent";
            this.notificationContent.Size = new System.Drawing.Size(
                                                                    266,
                                                                    22);
            this.notificationContent.TabIndex    =  1;
            // 
            // publish
            // 
            this.publish.Location = new System.Drawing.Point(
                                                             78,
                                                             123);
            this.publish.Name = "publish";
            this.publish.Size = new System.Drawing.Size(
                                                        119,
                                                        56);
            this.publish.TabIndex                =  2;
            this.publish.Text                    =  "Publish";
            this.publish.UseVisualStyleBackColor =  true;
            this.publish.Click                   += new System.EventHandler(this.PublishBtn_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(
                                                          318,
                                                          123);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(
                                                     129,
                                                     56);
            this.Exit.TabIndex                =  3;
            this.Exit.Text                    =  "Exit";
            this.Exit.UseVisualStyleBackColor =  true;
            this.Exit.Click                   += new System.EventHandler(this.CancelBtn_Click);
            // 
            // PublishNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(
                                                                8F,
                                                                16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(
                                                      527,
                                                      201);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.publish);
            this.Controls.Add(this.notificationContent);
            this.Controls.Add(this.notiContent);
            this.Name = "PublishNotification";
            this.Text = "Publish Notification";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button publish;
        private System.Windows.Forms.Button Exit;

        private System.Windows.Forms.Label   notiContent;
        private System.Windows.Forms.TextBox notificationContent;

        #endregion
    }
}