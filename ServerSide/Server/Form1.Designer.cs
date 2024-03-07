namespace Server
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
            this.button_listen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text_port = new System.Windows.Forms.TextBox();
            this.logs_server_user = new System.Windows.Forms.RichTextBox();
            this.logs_server_activity = new System.Windows.Forms.RichTextBox();
            this.logs_if100_user = new System.Windows.Forms.RichTextBox();
            this.logs_if100_activity = new System.Windows.Forms.RichTextBox();
            this.logs_sps101_user = new System.Windows.Forms.RichTextBox();
            this.logs_sps101_activity = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(348, 19);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(56, 22);
            this.button_listen.TabIndex = 5;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(202, 22);
            this.text_port.Margin = new System.Windows.Forms.Padding(2);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(138, 20);
            this.text_port.TabIndex = 3;
            // 
            // logs_server_user
            // 
            this.logs_server_user.Location = new System.Drawing.Point(40, 75);
            this.logs_server_user.Name = "logs_server_user";
            this.logs_server_user.ReadOnly = true;
            this.logs_server_user.Size = new System.Drawing.Size(131, 96);
            this.logs_server_user.TabIndex = 6;
            this.logs_server_user.Text = "";
            // 
            // logs_server_activity
            // 
            this.logs_server_activity.Location = new System.Drawing.Point(202, 75);
            this.logs_server_activity.Name = "logs_server_activity";
            this.logs_server_activity.ReadOnly = true;
            this.logs_server_activity.Size = new System.Drawing.Size(375, 96);
            this.logs_server_activity.TabIndex = 7;
            this.logs_server_activity.Text = "";
            // 
            // logs_if100_user
            // 
            this.logs_if100_user.Location = new System.Drawing.Point(40, 204);
            this.logs_if100_user.Name = "logs_if100_user";
            this.logs_if100_user.ReadOnly = true;
            this.logs_if100_user.Size = new System.Drawing.Size(131, 96);
            this.logs_if100_user.TabIndex = 8;
            this.logs_if100_user.Text = "";
            // 
            // logs_if100_activity
            // 
            this.logs_if100_activity.Location = new System.Drawing.Point(202, 204);
            this.logs_if100_activity.Name = "logs_if100_activity";
            this.logs_if100_activity.ReadOnly = true;
            this.logs_if100_activity.Size = new System.Drawing.Size(375, 96);
            this.logs_if100_activity.TabIndex = 9;
            this.logs_if100_activity.Text = "";
            // 
            // logs_sps101_user
            // 
            this.logs_sps101_user.Location = new System.Drawing.Point(40, 341);
            this.logs_sps101_user.Name = "logs_sps101_user";
            this.logs_sps101_user.ReadOnly = true;
            this.logs_sps101_user.Size = new System.Drawing.Size(131, 96);
            this.logs_sps101_user.TabIndex = 10;
            this.logs_sps101_user.Text = "";
            // 
            // logs_sps101_activity
            // 
            this.logs_sps101_activity.Location = new System.Drawing.Point(202, 341);
            this.logs_sps101_activity.Name = "logs_sps101_activity";
            this.logs_sps101_activity.ReadOnly = true;
            this.logs_sps101_activity.Size = new System.Drawing.Size(375, 96);
            this.logs_sps101_activity.TabIndex = 11;
            this.logs_sps101_activity.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Server Active User List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "IF100 Active User List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "SPS101 Active User List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Server Activities";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Channel \"IF100\" Activities";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Channel \"SPS101\" Activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 477);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs_sps101_activity);
            this.Controls.Add(this.logs_sps101_user);
            this.Controls.Add(this.logs_if100_activity);
            this.Controls.Add(this.logs_if100_user);
            this.Controls.Add(this.logs_server_activity);
            this.Controls.Add(this.logs_server_user);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_port);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.RichTextBox logs_server_user;
        private System.Windows.Forms.RichTextBox logs_server_activity;
        private System.Windows.Forms.RichTextBox logs_if100_user;
        private System.Windows.Forms.RichTextBox logs_if100_activity;
        private System.Windows.Forms.RichTextBox logs_sps101_user;
        private System.Windows.Forms.RichTextBox logs_sps101_activity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

