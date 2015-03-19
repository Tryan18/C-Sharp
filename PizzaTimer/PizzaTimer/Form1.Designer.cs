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
namespace PizzaTimer
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
            this.B_ok = new System.Windows.Forms.Button();
            this.num_minuten = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.L_tijd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_minuten)).BeginInit();
            this.SuspendLayout();
            // 
            // B_ok
            // 
            this.B_ok.Location = new System.Drawing.Point(12, 154);
            this.B_ok.Name = "B_ok";
            this.B_ok.Size = new System.Drawing.Size(75, 23);
            this.B_ok.TabIndex = 0;
            this.B_ok.Text = "Set";
            this.B_ok.UseVisualStyleBackColor = true;
            this.B_ok.Click += new System.EventHandler(this.B_ok_Click);
            // 
            // num_minuten
            // 
            this.num_minuten.Location = new System.Drawing.Point(114, 114);
            this.num_minuten.Name = "num_minuten";
            this.num_minuten.Size = new System.Drawing.Size(51, 20);
            this.num_minuten.TabIndex = 1;
            this.num_minuten.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minutes :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Jokerman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 51);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time Left :";
            // 
            // L_tijd
            // 
            this.L_tijd.AutoSize = true;
            this.L_tijd.Font = new System.Drawing.Font("Jokerman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_tijd.Location = new System.Drawing.Point(224, 31);
            this.L_tijd.Name = "L_tijd";
            this.L_tijd.Size = new System.Drawing.Size(39, 51);
            this.L_tijd.TabIndex = 4;
            this.L_tijd.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 189);
            this.Controls.Add(this.L_tijd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_minuten);
            this.Controls.Add(this.B_ok);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PizzaTimer";
            ((System.ComponentModel.ISupportInitialize)(this.num_minuten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_ok;
        private System.Windows.Forms.NumericUpDown num_minuten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_tijd;
    }
}

