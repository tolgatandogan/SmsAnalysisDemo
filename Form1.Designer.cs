namespace SmsAnalysisDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMessage = new TextBox();
            btnSend = new Button();
            chkZip = new CheckBox();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(106, 22);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(337, 115);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(223, 170);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gönder";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // chkZip
            // 
            chkZip.AutoSize = true;
            chkZip.Location = new Point(12, 173);
            chkZip.Name = "chkZip";
            chkZip.Size = new Size(106, 24);
            chkZip.TabIndex = 2;
            chkZip.Text = "Zip Kontrol";
            chkZip.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 281);
            Controls.Add(chkZip);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMessage;
        private Button btnSend;
        private CheckBox chkZip;
    }
}
