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
    partial class Menu
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
            this.B_single = new System.Windows.Forms.Button();
            this.B_multi = new System.Windows.Forms.Button();
            this.B_about = new System.Windows.Forms.Button();
            this.B_quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_single
            // 
            this.B_single.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.B_single.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_single.Location = new System.Drawing.Point(65, 30);
            this.B_single.Name = "B_single";
            this.B_single.Size = new System.Drawing.Size(152, 23);
            this.B_single.TabIndex = 0;
            this.B_single.Text = "Start Single Player";
            this.B_single.UseVisualStyleBackColor = false;
            this.B_single.Click += new System.EventHandler(this.B_single_Click);
            // 
            // B_multi
            // 
            this.B_multi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.B_multi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_multi.Location = new System.Drawing.Point(65, 82);
            this.B_multi.Name = "B_multi";
            this.B_multi.Size = new System.Drawing.Size(152, 23);
            this.B_multi.TabIndex = 1;
            this.B_multi.Text = "Start Multi Player";
            this.B_multi.UseVisualStyleBackColor = false;
            // 
            // B_about
            // 
            this.B_about.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.B_about.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_about.Location = new System.Drawing.Point(106, 130);
            this.B_about.Name = "B_about";
            this.B_about.Size = new System.Drawing.Size(71, 23);
            this.B_about.TabIndex = 2;
            this.B_about.Text = "About";
            this.B_about.UseVisualStyleBackColor = false;
            // 
            // B_quit
            // 
            this.B_quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.B_quit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_quit.Location = new System.Drawing.Point(106, 175);
            this.B_quit.Name = "B_quit";
            this.B_quit.Size = new System.Drawing.Size(71, 23);
            this.B_quit.TabIndex = 3;
            this.B_quit.Text = "Quit";
            this.B_quit.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 232);
            this.Controls.Add(this.B_quit);
            this.Controls.Add(this.B_about);
            this.Controls.Add(this.B_multi);
            this.Controls.Add(this.B_single);
            this.Name = "Menu";
            this.ShowIcon = false;
            this.Text = "Menu (Puzzle Battle)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_single;
        private System.Windows.Forms.Button B_multi;
        private System.Windows.Forms.Button B_about;
        private System.Windows.Forms.Button B_quit;
    }
}
