namespace Client
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
            this.text_ip = new System.Windows.Forms.TextBox();
            this.text_port = new System.Windows.Forms.TextBox();
            this.text_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logs_if100 = new System.Windows.Forms.RichTextBox();
            this.logs_sps101 = new System.Windows.Forms.RichTextBox();
            this.logs_server = new System.Windows.Forms.RichTextBox();
            this.button_srv_connect = new System.Windows.Forms.Button();
            this.button_subs_if100 = new System.Windows.Forms.Button();
            this.button_subs_sps101 = new System.Windows.Forms.Button();
            this.button_send_if100 = new System.Windows.Forms.Button();
            this.button_send_sps101 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_if100 = new System.Windows.Forms.TextBox();
            this.text_sps101 = new System.Windows.Forms.TextBox();
            this.button_unsubs_if100 = new System.Windows.Forms.Button();
            this.button_unsubs_sps101 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_ip
            // 
            this.text_ip.Location = new System.Drawing.Point(76, 61);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(139, 20);
            this.text_ip.TabIndex = 0;
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(76, 109);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(139, 20);
            this.text_port.TabIndex = 1;
            // 
            // text_username
            // 
            this.text_username.Location = new System.Drawing.Point(76, 163);
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(139, 20);
            this.text_username.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IF 100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SPS 101";
            // 
            // logs_if100
            // 
            this.logs_if100.Location = new System.Drawing.Point(264, 68);
            this.logs_if100.Name = "logs_if100";
            this.logs_if100.ReadOnly = true;
            this.logs_if100.Size = new System.Drawing.Size(212, 358);
            this.logs_if100.TabIndex = 5;
            this.logs_if100.Text = "";
            // 
            // logs_sps101
            // 
            this.logs_sps101.Location = new System.Drawing.Point(518, 68);
            this.logs_sps101.Name = "logs_sps101";
            this.logs_sps101.ReadOnly = true;
            this.logs_sps101.Size = new System.Drawing.Size(221, 358);
            this.logs_sps101.TabIndex = 6;
            this.logs_sps101.Text = "";
            // 
            // logs_server
            // 
            this.logs_server.Location = new System.Drawing.Point(44, 265);
            this.logs_server.Name = "logs_server";
            this.logs_server.ReadOnly = true;
            this.logs_server.Size = new System.Drawing.Size(171, 305);
            this.logs_server.TabIndex = 9;
            this.logs_server.Text = "";
            // 
            // button_srv_connect
            // 
            this.button_srv_connect.Location = new System.Drawing.Point(109, 202);
            this.button_srv_connect.Name = "button_srv_connect";
            this.button_srv_connect.Size = new System.Drawing.Size(75, 23);
            this.button_srv_connect.TabIndex = 10;
            this.button_srv_connect.Text = "Connect";
            this.button_srv_connect.UseVisualStyleBackColor = true;
            this.button_srv_connect.Click += new System.EventHandler(this.button_srv_connect_Click);
            // 
            // button_subs_if100
            // 
            this.button_subs_if100.Enabled = false;
            this.button_subs_if100.Location = new System.Drawing.Point(281, 432);
            this.button_subs_if100.Name = "button_subs_if100";
            this.button_subs_if100.Size = new System.Drawing.Size(75, 23);
            this.button_subs_if100.TabIndex = 11;
            this.button_subs_if100.Text = "Subscribe";
            this.button_subs_if100.UseVisualStyleBackColor = true;
            this.button_subs_if100.Click += new System.EventHandler(this.button_subs_if100_Click);
            // 
            // button_subs_sps101
            // 
            this.button_subs_sps101.Enabled = false;
            this.button_subs_sps101.Location = new System.Drawing.Point(536, 432);
            this.button_subs_sps101.Name = "button_subs_sps101";
            this.button_subs_sps101.Size = new System.Drawing.Size(75, 23);
            this.button_subs_sps101.TabIndex = 12;
            this.button_subs_sps101.Text = "Subscribe";
            this.button_subs_sps101.UseVisualStyleBackColor = true;
            this.button_subs_sps101.Click += new System.EventHandler(this.button_subs_sps101_Click);
            // 
            // button_send_if100
            // 
            this.button_send_if100.Enabled = false;
            this.button_send_if100.Location = new System.Drawing.Point(334, 577);
            this.button_send_if100.Name = "button_send_if100";
            this.button_send_if100.Size = new System.Drawing.Size(75, 23);
            this.button_send_if100.TabIndex = 13;
            this.button_send_if100.Text = "Send";
            this.button_send_if100.UseVisualStyleBackColor = true;
            this.button_send_if100.Click += new System.EventHandler(this.button_send_if100_Click);
            // 
            // button_send_sps101
            // 
            this.button_send_sps101.Enabled = false;
            this.button_send_sps101.Location = new System.Drawing.Point(598, 576);
            this.button_send_sps101.Name = "button_send_sps101";
            this.button_send_sps101.Size = new System.Drawing.Size(75, 23);
            this.button_send_sps101.TabIndex = 14;
            this.button_send_sps101.Text = "Send";
            this.button_send_sps101.UseVisualStyleBackColor = true;
            this.button_send_sps101.Click += new System.EventHandler(this.button_send_sps101_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Username:";
            // 
            // text_if100
            // 
            this.text_if100.Enabled = false;
            this.text_if100.Location = new System.Drawing.Point(264, 496);
            this.text_if100.Multiline = true;
            this.text_if100.Name = "text_if100";
            this.text_if100.Size = new System.Drawing.Size(212, 75);
            this.text_if100.TabIndex = 20;
            // 
            // text_sps101
            // 
            this.text_sps101.Enabled = false;
            this.text_sps101.Location = new System.Drawing.Point(518, 496);
            this.text_sps101.Multiline = true;
            this.text_sps101.Name = "text_sps101";
            this.text_sps101.Size = new System.Drawing.Size(221, 74);
            this.text_sps101.TabIndex = 21;
            // 
            // button_unsubs_if100
            // 
            this.button_unsubs_if100.Enabled = false;
            this.button_unsubs_if100.Location = new System.Drawing.Point(392, 432);
            this.button_unsubs_if100.Name = "button_unsubs_if100";
            this.button_unsubs_if100.Size = new System.Drawing.Size(75, 23);
            this.button_unsubs_if100.TabIndex = 22;
            this.button_unsubs_if100.Text = "Unsubscribe";
            this.button_unsubs_if100.UseVisualStyleBackColor = true;
            this.button_unsubs_if100.Click += new System.EventHandler(this.button_unsubs_if100_Click);
            // 
            // button_unsubs_sps101
            // 
            this.button_unsubs_sps101.Enabled = false;
            this.button_unsubs_sps101.Location = new System.Drawing.Point(652, 432);
            this.button_unsubs_sps101.Name = "button_unsubs_sps101";
            this.button_unsubs_sps101.Size = new System.Drawing.Size(75, 23);
            this.button_unsubs_sps101.TabIndex = 23;
            this.button_unsubs_sps101.Text = "Unsubscribe";
            this.button_unsubs_sps101.UseVisualStyleBackColor = true;
            this.button_unsubs_sps101.Click += new System.EventHandler(this.button_unsubs_sps101_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 634);
            this.Controls.Add(this.button_unsubs_sps101);
            this.Controls.Add(this.button_unsubs_if100);
            this.Controls.Add(this.text_sps101);
            this.Controls.Add(this.text_if100);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_send_sps101);
            this.Controls.Add(this.button_send_if100);
            this.Controls.Add(this.button_subs_sps101);
            this.Controls.Add(this.button_subs_if100);
            this.Controls.Add(this.button_srv_connect);
            this.Controls.Add(this.logs_server);
            this.Controls.Add(this.logs_sps101);
            this.Controls.Add(this.logs_if100);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_username);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.text_ip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_ip;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.TextBox text_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox logs_if100;
        private System.Windows.Forms.RichTextBox logs_sps101;
        private System.Windows.Forms.RichTextBox logs_server;
        private System.Windows.Forms.Button button_srv_connect;
        private System.Windows.Forms.Button button_subs_if100;
        private System.Windows.Forms.Button button_subs_sps101;
        private System.Windows.Forms.Button button_send_if100;
        private System.Windows.Forms.Button button_send_sps101;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_if100;
        private System.Windows.Forms.TextBox text_sps101;
        private System.Windows.Forms.Button button_unsubs_if100;
        private System.Windows.Forms.Button button_unsubs_sps101;
    }
}

