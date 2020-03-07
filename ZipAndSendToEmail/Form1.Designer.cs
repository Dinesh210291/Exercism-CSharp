namespace ZipAndSendToEmail
{
    partial class Form1
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
            this.btnSendClientLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendClientLog
            // 
            this.btnSendClientLog.Location = new System.Drawing.Point(149, 61);
            this.btnSendClientLog.Name = "btnSendClientLog";
            this.btnSendClientLog.Size = new System.Drawing.Size(158, 27);
            this.btnSendClientLog.TabIndex = 0;
            this.btnSendClientLog.Text = "Send Client Log To Email";
            this.btnSendClientLog.UseVisualStyleBackColor = true;
            this.btnSendClientLog.Click += new System.EventHandler(this.btnSendClientLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 187);
            this.Controls.Add(this.btnSendClientLog);
            this.Name = "Form1";
            this.Text = "Send client log to email";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendClientLog;
    }
}

