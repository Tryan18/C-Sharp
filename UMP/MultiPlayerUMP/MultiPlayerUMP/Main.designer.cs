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
namespace MultiPlayerUMP
{
    partial class Main
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
            DisconnectFromPluginServer();
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
            this.label1 = new System.Windows.Forms.Label();
            this.B_host = new System.Windows.Forms.Button();
            this.B_connect = new System.Windows.Forms.Button();
            this.num_maxplayers = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.list_users = new System.Windows.Forms.ListView();
            this.T_output = new System.Windows.Forms.TextBox();
            this.T_input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_maxplayers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users Online";
            // 
            // B_host
            // 
            this.B_host.Location = new System.Drawing.Point(323, 25);
            this.B_host.Name = "B_host";
            this.B_host.Size = new System.Drawing.Size(98, 23);
            this.B_host.TabIndex = 2;
            this.B_host.Text = "Host Game";
            this.B_host.UseVisualStyleBackColor = true;
            this.B_host.Click += new System.EventHandler(this.B_host_Click);
            // 
            // B_connect
            // 
            this.B_connect.Location = new System.Drawing.Point(321, 90);
            this.B_connect.Name = "B_connect";
            this.B_connect.Size = new System.Drawing.Size(98, 23);
            this.B_connect.TabIndex = 3;
            this.B_connect.Text = "Connect to Game";
            this.B_connect.UseVisualStyleBackColor = true;
            this.B_connect.Click += new System.EventHandler(this.B_connect_Click);
            // 
            // num_maxplayers
            // 
            this.num_maxplayers.Location = new System.Drawing.Point(388, 59);
            this.num_maxplayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_maxplayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_maxplayers.Name = "num_maxplayers";
            this.num_maxplayers.Size = new System.Drawing.Size(33, 20);
            this.num_maxplayers.TabIndex = 4;
            this.num_maxplayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_maxplayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Players";
            // 
            // list_users
            // 
            this.list_users.FullRowSelect = true;
            this.list_users.Location = new System.Drawing.Point(12, 25);
            this.list_users.MultiSelect = false;
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(284, 106);
            this.list_users.TabIndex = 6;
            this.list_users.UseCompatibleStateImageBehavior = false;
            this.list_users.View = System.Windows.Forms.View.List;
            // 
            // T_output
            // 
            this.T_output.BackColor = System.Drawing.Color.White;
            this.T_output.Location = new System.Drawing.Point(12, 137);
            this.T_output.Multiline = true;
            this.T_output.Name = "T_output";
            this.T_output.ReadOnly = true;
            this.T_output.Size = new System.Drawing.Size(284, 114);
            this.T_output.TabIndex = 7;
            this.T_output.TextChanged += new System.EventHandler(this.T_output_TextChanged);
            // 
            // T_input
            // 
            this.T_input.Location = new System.Drawing.Point(53, 284);
            this.T_input.Name = "T_input";
            this.T_input.Size = new System.Drawing.Size(243, 20);
            this.T_input.TabIndex = 8;
            this.T_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.T_input_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chat :";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.T_input);
            this.Controls.Add(this.T_output);
            this.Controls.Add(this.list_users);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_maxplayers);
            this.Controls.Add(this.B_connect);
            this.Controls.Add(this.B_host);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.num_maxplayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_host;
        private System.Windows.Forms.Button B_connect;
        private System.Windows.Forms.NumericUpDown num_maxplayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView list_users;
        private System.Windows.Forms.TextBox T_output;
        private System.Windows.Forms.TextBox T_input;
        private System.Windows.Forms.Label label3;
    }
}
