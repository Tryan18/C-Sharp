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
namespace MultiPaint
{
    partial class SessionGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.B_start = new System.Windows.Forms.Button();
            this.list_users = new System.Windows.Forms.ListView();
            this.L_total = new System.Windows.Forms.Label();
            this.L_remaining_players = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connected Users";
            // 
            // B_start
            // 
            this.B_start.Enabled = false;
            this.B_start.Location = new System.Drawing.Point(346, 25);
            this.B_start.Name = "B_start";
            this.B_start.Size = new System.Drawing.Size(75, 23);
            this.B_start.TabIndex = 2;
            this.B_start.Text = "Start Game";
            this.B_start.UseVisualStyleBackColor = true;
            this.B_start.Click += new System.EventHandler(this.B_start_Click);
            // 
            // list_users
            // 
            this.list_users.FullRowSelect = true;
            this.list_users.Location = new System.Drawing.Point(12, 25);
            this.list_users.MultiSelect = false;
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(285, 251);
            this.list_users.TabIndex = 3;
            this.list_users.UseCompatibleStateImageBehavior = false;
            this.list_users.View = System.Windows.Forms.View.List;
            // 
            // L_total
            // 
            this.L_total.AutoSize = true;
            this.L_total.Location = new System.Drawing.Point(303, 69);
            this.L_total.Name = "L_total";
            this.L_total.Size = new System.Drawing.Size(125, 13);
            this.L_total.TabIndex = 4;
            this.L_total.Text = "Total Players to Continue\r\n";
            // 
            // L_remaining_players
            // 
            this.L_remaining_players.AutoSize = true;
            this.L_remaining_players.Location = new System.Drawing.Point(356, 96);
            this.L_remaining_players.Name = "L_remaining_players";
            this.L_remaining_players.Size = new System.Drawing.Size(10, 13);
            this.L_remaining_players.TabIndex = 5;
            this.L_remaining_players.Text = "-";
            this.L_remaining_players.TextChanged += new System.EventHandler(this.L_remaining_players_TextChanged);
            // 
            // SessionGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 288);
            this.Controls.Add(this.L_remaining_players);
            this.Controls.Add(this.L_total);
            this.Controls.Add(this.list_users);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.label1);
            this.Name = "SessionGame";
            this.ShowIcon = false;
            this.Text = "Title Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.ListView list_users;
        private System.Windows.Forms.Label L_total;
        private System.Windows.Forms.Label L_remaining_players;
    }
}
