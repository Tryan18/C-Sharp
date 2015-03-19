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
namespace UMP_Client
{
    partial class Login
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
            this.label3 = new System.Windows.Forms.Label();
            this.combo_regtype = new System.Windows.Forms.ComboBox();
            this.CancelButt = new System.Windows.Forms.Button();
            this.OkButt = new System.Windows.Forms.Button();
            this.T_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.T_username = new System.Windows.Forms.TextBox();
            this.cb_autologin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Type of Service";
            // 
            // combo_regtype
            // 
            this.combo_regtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_regtype.DropDownWidth = 104;
            this.combo_regtype.Items.AddRange(new object[] {
            "Server"});
            this.combo_regtype.Location = new System.Drawing.Point(101, 12);
            this.combo_regtype.Name = "combo_regtype";
            this.combo_regtype.Size = new System.Drawing.Size(120, 21);
            this.combo_regtype.TabIndex = 14;
            // 
            // CancelButt
            // 
            this.CancelButt.Location = new System.Drawing.Point(159, 172);
            this.CancelButt.Name = "CancelButt";
            this.CancelButt.Size = new System.Drawing.Size(72, 24);
            this.CancelButt.TabIndex = 20;
            this.CancelButt.Text = "Cancel";
            this.CancelButt.Click += new System.EventHandler(this.CancelButt_Click);
            // 
            // OkButt
            // 
            this.OkButt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButt.Location = new System.Drawing.Point(55, 172);
            this.OkButt.Name = "OkButt";
            this.OkButt.Size = new System.Drawing.Size(80, 24);
            this.OkButt.TabIndex = 19;
            this.OkButt.Text = "Ok";
            this.OkButt.Click += new System.EventHandler(this.OkButt_Click);
            // 
            // T_pass
            // 
            this.T_pass.Location = new System.Drawing.Point(101, 84);
            this.T_pass.Name = "T_pass";
            this.T_pass.PasswordChar = '*';
            this.T_pass.Size = new System.Drawing.Size(120, 20);
            this.T_pass.TabIndex = 18;
            this.T_pass.Text = "1337";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "User Name";
            // 
            // T_username
            // 
            this.T_username.Location = new System.Drawing.Point(101, 48);
            this.T_username.Name = "T_username";
            this.T_username.Size = new System.Drawing.Size(120, 20);
            this.T_username.TabIndex = 21;
            this.T_username.Text = "Terence";
            // 
            // cb_autologin
            // 
            this.cb_autologin.AutoSize = true;
            this.cb_autologin.Location = new System.Drawing.Point(114, 124);
            this.cb_autologin.Name = "cb_autologin";
            this.cb_autologin.Size = new System.Drawing.Size(107, 17);
            this.cb_autologin.TabIndex = 22;
            this.cb_autologin.Text = "Save Login Info?";
            this.cb_autologin.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 228);
            this.Controls.Add(this.cb_autologin);
            this.Controls.Add(this.T_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_regtype);
            this.Controls.Add(this.CancelButt);
            this.Controls.Add(this.OkButt);
            this.Controls.Add(this.T_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.ShowIcon = false;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelButt;
        private System.Windows.Forms.Button OkButt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_autologin;
        private System.Windows.Forms.TextBox T_pass;
        internal System.Windows.Forms.TextBox T_username;
        internal System.Windows.Forms.ComboBox combo_regtype;
    }
}
