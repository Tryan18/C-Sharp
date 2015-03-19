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
namespace Spazer
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
            this.panel_speelveld = new System.Windows.Forms.Panel();
            this.B_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.T_score = new System.Windows.Forms.TextBox();
            this.T_level = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.T_besturing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel_speelveld
            // 
            this.panel_speelveld.BackColor = System.Drawing.Color.White;
            this.panel_speelveld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_speelveld.Location = new System.Drawing.Point(12, 12);
            this.panel_speelveld.Name = "panel_speelveld";
            this.panel_speelveld.Size = new System.Drawing.Size(500, 425);
            this.panel_speelveld.TabIndex = 0;
            // 
            // B_start
            // 
            this.B_start.BackColor = System.Drawing.Color.DodgerBlue;
            this.B_start.Location = new System.Drawing.Point(685, 12);
            this.B_start.Name = "B_start";
            this.B_start.Size = new System.Drawing.Size(60, 41);
            this.B_start.TabIndex = 1;
            this.B_start.Text = "Start";
            this.B_start.UseVisualStyleBackColor = false;
            this.B_start.Click += new System.EventHandler(this.B_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(595, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score : ";
            // 
            // T_score
            // 
            this.T_score.Location = new System.Drawing.Point(645, 82);
            this.T_score.Name = "T_score";
            this.T_score.Size = new System.Drawing.Size(100, 20);
            this.T_score.TabIndex = 3;
            // 
            // T_level
            // 
            this.T_level.Location = new System.Drawing.Point(645, 108);
            this.T_level.Name = "T_level";
            this.T_level.Size = new System.Drawing.Size(100, 20);
            this.T_level.TabIndex = 5;
            this.T_level.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Level : ";
            this.label2.Visible = false;
            // 
            // T_besturing
            // 
            this.T_besturing.Location = new System.Drawing.Point(645, 404);
            this.T_besturing.Name = "T_besturing";
            this.T_besturing.Size = new System.Drawing.Size(10, 20);
            this.T_besturing.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(757, 480);
            this.Controls.Add(this.T_besturing);
            this.Controls.Add(this.T_level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.T_score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.panel_speelveld);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Spazer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.TextBox T_level;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel_speelveld;
        public System.Windows.Forms.TextBox T_besturing;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox T_score;
    }
}

