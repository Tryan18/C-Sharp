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
namespace PuzzleBattle
{
    partial class BattleField
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
            this.group_battlefield = new System.Windows.Forms.GroupBox();
            this.T_controls = new System.Windows.Forms.TextBox();
            this.L_5 = new System.Windows.Forms.Label();
            this.L_3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.L_4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // group_battlefield
            // 
            this.group_battlefield.BackColor = System.Drawing.Color.Black;
            this.group_battlefield.Location = new System.Drawing.Point(153, 24);
            this.group_battlefield.Name = "group_battlefield";
            this.group_battlefield.Size = new System.Drawing.Size(410, 414);
            this.group_battlefield.TabIndex = 0;
            this.group_battlefield.TabStop = false;
            // 
            // T_controls
            // 
            this.T_controls.Location = new System.Drawing.Point(553, 452);
            this.T_controls.Name = "T_controls";
            this.T_controls.Size = new System.Drawing.Size(10, 20);
            this.T_controls.TabIndex = 1;
            this.T_controls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.T_controls_KeyDown);
            // 
            // L_5
            // 
            this.L_5.AutoSize = true;
            this.L_5.Location = new System.Drawing.Point(569, 207);
            this.L_5.Name = "L_5";
            this.L_5.Size = new System.Drawing.Size(76, 13);
            this.L_5.TabIndex = 2;
            this.L_5.Text = "5# of a kind = ";
            // 
            // L_3
            // 
            this.L_3.AutoSize = true;
            this.L_3.Location = new System.Drawing.Point(569, 99);
            this.L_3.Name = "L_3";
            this.L_3.Size = new System.Drawing.Size(76, 13);
            this.L_3.TabIndex = 3;
            this.L_3.Text = "3# of a kind = ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(553, 452);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.T_controls_KeyDown);
            // 
            // L_4
            // 
            this.L_4.AutoSize = true;
            this.L_4.Location = new System.Drawing.Point(569, 155);
            this.L_4.Name = "L_4";
            this.L_4.Size = new System.Drawing.Size(76, 13);
            this.L_4.TabIndex = 2;
            this.L_4.Text = "4# of a kind = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // BattleField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L_3);
            this.Controls.Add(this.L_4);
            this.Controls.Add(this.L_5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.T_controls);
            this.Controls.Add(this.group_battlefield);
            this.Name = "BattleField";
            this.ShowIcon = false;
            this.Text = "PuzzleBattle: The Battle Field";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox group_battlefield;
        private System.Windows.Forms.TextBox T_controls;
        private System.Windows.Forms.Label L_5;
        private System.Windows.Forms.Label L_3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label L_4;
        private System.Windows.Forms.Label label1;

    }
}
