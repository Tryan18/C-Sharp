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

namespace UMP_Server
{
    partial class MainServer
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
            sb.StopServer();
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.list_clients = new System.Windows.Forms.ListView();
            this.c_clients = new System.Windows.Forms.ColumnHeader();
            this.T_input = new System.Windows.Forms.TextBox();
            this.group_UMP = new System.Windows.Forms.GroupBox();
            this.cb_scrollback = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.T_output = new System.Windows.Forms.TextBox();
            this.B_host_start = new System.Windows.Forms.Button();
            this.group_configure = new System.Windows.Forms.GroupBox();
            this.combo_ip = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.T_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.B_host_stop = new System.Windows.Forms.Button();
            this.group_UMP.SuspendLayout();
            this.group_configure.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_clients
            // 
            this.list_clients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c_clients});
            this.list_clients.Location = new System.Drawing.Point(663, 19);
            this.list_clients.Name = "list_clients";
            this.list_clients.Size = new System.Drawing.Size(180, 392);
            this.list_clients.TabIndex = 0;
            this.list_clients.UseCompatibleStateImageBehavior = false;
            this.list_clients.View = System.Windows.Forms.View.Details;
            // 
            // c_clients
            // 
            this.c_clients.Text = "Clients";
            this.c_clients.Width = 175;
            // 
            // T_input
            // 
            this.T_input.Location = new System.Drawing.Point(30, 437);
            this.T_input.Name = "T_input";
            this.T_input.Size = new System.Drawing.Size(813, 20);
            this.T_input.TabIndex = 1;
            this.T_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.T_input_KeyDown);
            // 
            // group_UMP
            // 
            this.group_UMP.Controls.Add(this.cb_scrollback);
            this.group_UMP.Controls.Add(this.label2);
            this.group_UMP.Controls.Add(this.label1);
            this.group_UMP.Controls.Add(this.T_output);
            this.group_UMP.Controls.Add(this.list_clients);
            this.group_UMP.Controls.Add(this.T_input);
            this.group_UMP.Location = new System.Drawing.Point(12, 12);
            this.group_UMP.Name = "group_UMP";
            this.group_UMP.Size = new System.Drawing.Size(849, 470);
            this.group_UMP.TabIndex = 2;
            this.group_UMP.TabStop = false;
            this.group_UMP.Text = "UMP Server";
            // 
            // cb_scrollback
            // 
            this.cb_scrollback.AutoSize = true;
            this.cb_scrollback.Location = new System.Drawing.Point(577, 414);
            this.cb_scrollback.Name = "cb_scrollback";
            this.cb_scrollback.Size = new System.Drawing.Size(80, 17);
            this.cb_scrollback.TabIndex = 5;
            this.cb_scrollback.Text = "Scroll Back";
            this.cb_scrollback.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Messages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command Input";
            // 
            // T_output
            // 
            this.T_output.Location = new System.Drawing.Point(30, 35);
            this.T_output.Multiline = true;
            this.T_output.Name = "T_output";
            this.T_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.T_output.Size = new System.Drawing.Size(627, 376);
            this.T_output.TabIndex = 2;
            this.T_output.TextChanged += new System.EventHandler(this.T_output_TextChanged);
            // 
            // B_host_start
            // 
            this.B_host_start.Location = new System.Drawing.Point(475, 17);
            this.B_host_start.Name = "B_host_start";
            this.B_host_start.Size = new System.Drawing.Size(75, 23);
            this.B_host_start.TabIndex = 3;
            this.B_host_start.Text = "Start";
            this.B_host_start.UseVisualStyleBackColor = true;
            this.B_host_start.Click += new System.EventHandler(this.B_host_start_Click);
            // 
            // group_configure
            // 
            this.group_configure.Controls.Add(this.combo_ip);
            this.group_configure.Controls.Add(this.label5);
            this.group_configure.Controls.Add(this.label4);
            this.group_configure.Controls.Add(this.T_port);
            this.group_configure.Controls.Add(this.label3);
            this.group_configure.Controls.Add(this.B_host_stop);
            this.group_configure.Controls.Add(this.B_host_start);
            this.group_configure.Location = new System.Drawing.Point(12, 491);
            this.group_configure.Name = "group_configure";
            this.group_configure.Size = new System.Drawing.Size(696, 49);
            this.group_configure.TabIndex = 4;
            this.group_configure.TabStop = false;
            this.group_configure.Text = "Configure";
            // 
            // combo_ip
            // 
            this.combo_ip.FormattingEnabled = true;
            this.combo_ip.Items.AddRange(new object[] {
            "127.0.0.1"});
            this.combo_ip.Location = new System.Drawing.Point(228, 19);
            this.combo_ip.Name = "combo_ip";
            this.combo_ip.Size = new System.Drawing.Size(121, 21);
            this.combo_ip.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Adress = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port = ";
            // 
            // T_port
            // 
            this.T_port.Location = new System.Drawing.Point(58, 19);
            this.T_port.Name = "T_port";
            this.T_port.Size = new System.Drawing.Size(100, 20);
            this.T_port.TabIndex = 6;
            this.T_port.Text = "7331";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WebService = ";
            // 
            // B_host_stop
            // 
            this.B_host_stop.Location = new System.Drawing.Point(582, 17);
            this.B_host_stop.Name = "B_host_stop";
            this.B_host_stop.Size = new System.Drawing.Size(75, 23);
            this.B_host_stop.TabIndex = 4;
            this.B_host_stop.Text = "Stop";
            this.B_host_stop.UseVisualStyleBackColor = true;
            this.B_host_stop.Click += new System.EventHandler(this.B_host_stop_Click);
            // 
            // MainServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 549);
            this.Controls.Add(this.group_configure);
            this.Controls.Add(this.group_UMP);
            this.Name = "MainServer";
            this.ShowIcon = false;
            this.Text = "UMP HQ Center";
            this.group_UMP.ResumeLayout(false);
            this.group_UMP.PerformLayout();
            this.group_configure.ResumeLayout(false);
            this.group_configure.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView list_clients;
        private System.Windows.Forms.ColumnHeader c_clients;
        private System.Windows.Forms.TextBox T_input;
        private System.Windows.Forms.GroupBox group_UMP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_host_start;
        private System.Windows.Forms.GroupBox group_configure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox T_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_host_stop;
        private System.Windows.Forms.ComboBox combo_ip;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox T_output;
        private System.Windows.Forms.CheckBox cb_scrollback;
    }
}

