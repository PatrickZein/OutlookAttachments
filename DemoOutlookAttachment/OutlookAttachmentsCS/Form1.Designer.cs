namespace OutlookAttachmentsCS
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.maildrop = new System.Windows.Forms.Label();
            this.kalender = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.appointheader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bodytext = new System.Windows.Forms.TextBox();
            this.sendmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(34, 46);
            this.lstResults.Margin = new System.Windows.Forms.Padding(2);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(524, 225);
            this.lstResults.TabIndex = 3;
            // 
            // maildrop
            // 
            this.maildrop.AllowDrop = true;
            this.maildrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maildrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maildrop.Location = new System.Drawing.Point(34, 10);
            this.maildrop.Name = "maildrop";
            this.maildrop.Size = new System.Drawing.Size(524, 23);
            this.maildrop.TabIndex = 2;
            this.maildrop.Text = "Drop here";
            this.maildrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kalender
            // 
            this.kalender.Location = new System.Drawing.Point(470, 535);
            this.kalender.Name = "kalender";
            this.kalender.Size = new System.Drawing.Size(88, 23);
            this.kalender.TabIndex = 30;
            this.kalender.Text = "Kalenderför";
            this.kalender.UseVisualStyleBackColor = true;
            this.kalender.Click += new System.EventHandler(this.kalender_click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM dd, yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(105, 315);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MMMM dd, yyyy HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(105, 341);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 20;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Startdatum";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Slutdatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Rubrik";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // appointheader
            // 
            this.appointheader.Location = new System.Drawing.Point(105, 289);
            this.appointheader.Name = "appointheader";
            this.appointheader.Size = new System.Drawing.Size(200, 20);
            this.appointheader.TabIndex = 10;
            this.appointheader.Text = "(Rubrik)";
            this.appointheader.TextChanged += new System.EventHandler(this.header_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Notering";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // bodytext
            // 
            this.bodytext.Location = new System.Drawing.Point(105, 370);
            this.bodytext.Multiline = true;
            this.bodytext.Name = "bodytext";
            this.bodytext.Size = new System.Drawing.Size(453, 159);
            this.bodytext.TabIndex = 25;
            // 
            // sendmail
            // 
            this.sendmail.Location = new System.Drawing.Point(470, 564);
            this.sendmail.Name = "sendmail";
            this.sendmail.Size = new System.Drawing.Size(88, 23);
            this.sendmail.TabIndex = 31;
            this.sendmail.Text = "Skicka e-post";
            this.sendmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sendmail.UseVisualStyleBackColor = true;
            this.sendmail.Click += new System.EventHandler(this.sendmail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 629);
            this.Controls.Add(this.sendmail);
            this.Controls.Add(this.bodytext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.appointheader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.kalender);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.maildrop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Outlook Drag & Drop demo (C#)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox lstResults;
        internal System.Windows.Forms.Label maildrop;
        private System.Windows.Forms.Button kalender;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox appointheader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bodytext;
        private System.Windows.Forms.Button sendmail;
    }
}

