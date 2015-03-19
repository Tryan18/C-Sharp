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
namespace exclusive_story
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
            this.T_log = new System.Windows.Forms.TextBox();
            this.B_start = new System.Windows.Forms.Button();
            this.P_story = new System.Windows.Forms.Panel();
            this.B_stop = new System.Windows.Forms.Button();
            this.B_about = new System.Windows.Forms.Button();
            this.L_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // T_log
            // 
            this.T_log.Location = new System.Drawing.Point(12, 360);
            this.T_log.Multiline = true;
            this.T_log.Name = "T_log";
            this.T_log.Size = new System.Drawing.Size(422, 135);
            this.T_log.TabIndex = 0;
            // 
            // B_start
            // 
            this.B_start.Location = new System.Drawing.Point(451, 467);
            this.B_start.Name = "B_start";
            this.B_start.Size = new System.Drawing.Size(75, 23);
            this.B_start.TabIndex = 1;
            this.B_start.Text = "Start";
            this.B_start.UseVisualStyleBackColor = true;
            this.B_start.Click += new System.EventHandler(this.B_start_Click);
            // 
            // P_story
            // 
            this.P_story.BackColor = System.Drawing.Color.White;
            this.P_story.Location = new System.Drawing.Point(-8, 53);
            this.P_story.Name = "P_story";
            this.P_story.Size = new System.Drawing.Size(777, 291);
            this.P_story.TabIndex = 2;
            // 
            // B_stop
            // 
            this.B_stop.Location = new System.Drawing.Point(451, 360);
            this.B_stop.Name = "B_stop";
            this.B_stop.Size = new System.Drawing.Size(75, 23);
            this.B_stop.TabIndex = 3;
            this.B_stop.Text = "Stop";
            this.B_stop.UseVisualStyleBackColor = true;
            this.B_stop.Visible = false;
            this.B_stop.Click += new System.EventHandler(this.B_stop_Click);
            // 
            // B_about
            // 
            this.B_about.Location = new System.Drawing.Point(674, 467);
            this.B_about.Name = "B_about";
            this.B_about.Size = new System.Drawing.Size(75, 23);
            this.B_about.TabIndex = 4;
            this.B_about.Text = "About";
            this.B_about.UseVisualStyleBackColor = true;
            this.B_about.Click += new System.EventHandler(this.B_about_Click);
            // 
            // L_title
            // 
            this.L_title.AutoSize = true;
            this.L_title.Font = new System.Drawing.Font("Chiller", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_title.Location = new System.Drawing.Point(12, 9);
            this.L_title.Name = "L_title";
            this.L_title.Size = new System.Drawing.Size(100, 31);
            this.L_title.TabIndex = 5;
            this.L_title.Text = "Story Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "This Program contains music your better shut down yours off :P";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L_title);
            this.Controls.Add(this.B_about);
            this.Controls.Add(this.B_stop);
            this.Controls.Add(this.P_story);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.T_log);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Exclusive Story";            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.Button B_stop;
        private System.Windows.Forms.Button B_about;
        public System.Windows.Forms.TextBox T_log;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel P_story;
        public System.Windows.Forms.Label L_title;
    }
}

