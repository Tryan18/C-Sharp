/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using UMP;
namespace UMP_Client
{
    partial class MainClient
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
            cb.cm.DisconnectServer();
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
            this.B_login = new System.Windows.Forms.Button();
            this.group_client = new System.Windows.Forms.GroupBox();
            this.B_update = new System.Windows.Forms.Button();
            this.T_input = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.B_disconnect = new System.Windows.Forms.Button();
            this.cb_scrollback = new System.Windows.Forms.CheckBox();
            this.combo_ip = new System.Windows.Forms.ComboBox();
            this.B_connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.T_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.T_output = new System.Windows.Forms.TextBox();
            this.group_client.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_login
            // 
            this.B_login.Location = new System.Drawing.Point(32, 29);
            this.B_login.Name = "B_login";
            this.B_login.Size = new System.Drawing.Size(98, 23);
            this.B_login.TabIndex = 0;
            this.B_login.Text = "Login";
            this.B_login.UseVisualStyleBackColor = true;
            this.B_login.Click += new System.EventHandler(this.B_login_Click);
            // 
            // group_client
            // 
            this.group_client.Controls.Add(this.B_update);
            this.group_client.Controls.Add(this.T_input);
            this.group_client.Controls.Add(this.label4);
            this.group_client.Controls.Add(this.B_disconnect);
            this.group_client.Controls.Add(this.cb_scrollback);
            this.group_client.Controls.Add(this.combo_ip);
            this.group_client.Controls.Add(this.B_connect);
            this.group_client.Controls.Add(this.label3);
            this.group_client.Controls.Add(this.T_port);
            this.group_client.Controls.Add(this.label2);
            this.group_client.Controls.Add(this.label1);
            this.group_client.Controls.Add(this.T_output);
            this.group_client.Controls.Add(this.B_login);
            this.group_client.Location = new System.Drawing.Point(12, 12);
            this.group_client.Name = "group_client";
            this.group_client.Size = new System.Drawing.Size(522, 311);
            this.group_client.TabIndex = 1;
            this.group_client.TabStop = false;
            this.group_client.Text = "Main Menu";
            // 
            // B_update
            // 
            this.B_update.Location = new System.Drawing.Point(32, 80);
            this.B_update.Name = "B_update";
            this.B_update.Size = new System.Drawing.Size(98, 23);
            this.B_update.TabIndex = 15;
            this.B_update.Text = "Services";
            this.B_update.UseVisualStyleBackColor = true;
            this.B_update.Click += new System.EventHandler(this.B_update_Click);
            // 
            // T_input
            // 
            this.T_input.Location = new System.Drawing.Point(98, 155);
            this.T_input.Name = "T_input";
            this.T_input.Size = new System.Drawing.Size(251, 20);
            this.T_input.TabIndex = 14;
            this.T_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.T_input_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Msg Server : ";
            // 
            // B_disconnect
            // 
            this.B_disconnect.Location = new System.Drawing.Point(432, 67);
            this.B_disconnect.Name = "B_disconnect";
            this.B_disconnect.Size = new System.Drawing.Size(75, 36);
            this.B_disconnect.TabIndex = 12;
            this.B_disconnect.Text = "Disconnect From Server";
            this.B_disconnect.UseVisualStyleBackColor = true;
            this.B_disconnect.Click += new System.EventHandler(this.B_disconnect_Click);
            // 
            // cb_scrollback
            // 
            this.cb_scrollback.AutoSize = true;
            this.cb_scrollback.Location = new System.Drawing.Point(12, 288);
            this.cb_scrollback.Name = "cb_scrollback";
            this.cb_scrollback.Size = new System.Drawing.Size(80, 17);
            this.cb_scrollback.TabIndex = 11;
            this.cb_scrollback.Text = "Scroll Back";
            this.cb_scrollback.UseVisualStyleBackColor = true;
            // 
            // combo_ip
            // 
            this.combo_ip.FormattingEnabled = true;
            this.combo_ip.Items.AddRange(new object[] {
            "127.0.0.1"});
            this.combo_ip.Location = new System.Drawing.Point(275, 21);
            this.combo_ip.Name = "combo_ip";
            this.combo_ip.Size = new System.Drawing.Size(133, 21);
            this.combo_ip.TabIndex = 10;
            // 
            // B_connect
            // 
            this.B_connect.Location = new System.Drawing.Point(432, 25);
            this.B_connect.Name = "B_connect";
            this.B_connect.Size = new System.Drawing.Size(75, 36);
            this.B_connect.TabIndex = 7;
            this.B_connect.Text = "Connect To Server";
            this.B_connect.UseVisualStyleBackColor = true;
            this.B_connect.Click += new System.EventHandler(this.B_connect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port : ";
            // 
            // T_port
            // 
            this.T_port.Location = new System.Drawing.Point(308, 48);
            this.T_port.Name = "T_port";
            this.T_port.Size = new System.Drawing.Size(100, 20);
            this.T_port.TabIndex = 5;
            this.T_port.Text = "7331";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adres : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Messages : ";
            // 
            // T_output
            // 
            this.T_output.Location = new System.Drawing.Point(98, 181);
            this.T_output.Multiline = true;
            this.T_output.Name = "T_output";
            this.T_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.T_output.Size = new System.Drawing.Size(418, 124);
            this.T_output.TabIndex = 1;
            this.T_output.TextChanged += new System.EventHandler(this.T_output_TextChanged);
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 335);
            this.Controls.Add(this.group_client);
            this.Icon = global::UMP_Client.Properties.Resources.ump;
            this.Name = "MainClient";
            this.ShowInTaskbar = false;
            this.Text = "UMP Client Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group_client.ResumeLayout(false);
            this.group_client.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_login;
        private System.Windows.Forms.GroupBox group_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox T_port;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox T_output;
        private System.Windows.Forms.ComboBox combo_ip;
        private System.Windows.Forms.CheckBox cb_scrollback;
        private System.Windows.Forms.Button B_disconnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox T_input;
        private System.Windows.Forms.Button B_update;
    }
}

