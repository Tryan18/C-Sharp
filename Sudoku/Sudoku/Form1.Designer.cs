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
namespace Sudoku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.controleer = new System.Windows.Forms.Button();
            this.Load_B = new System.Windows.Forms.Button();
            this.Save_B = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.musicbox = new System.Windows.Forms.ComboBox();
            this.musicb = new System.Windows.Forms.Button();
            this.AGG = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AGG)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // controleer
            // 
            resources.ApplyResources(this.controleer, "controleer");
            this.controleer.Name = "controleer";
            this.controleer.UseVisualStyleBackColor = true;
            this.controleer.Click += new System.EventHandler(this.controleer_Click);
            // 
            // Load_B
            // 
            resources.ApplyResources(this.Load_B, "Load_B");
            this.Load_B.Name = "Load_B";
            this.Load_B.UseVisualStyleBackColor = true;
            this.Load_B.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // Save_B
            // 
            resources.ApplyResources(this.Save_B, "Save_B");
            this.Save_B.Name = "Save_B";
            this.Save_B.UseVisualStyleBackColor = true;
            this.Save_B.Click += new System.EventHandler(this.Save_B_Click);
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.DarkGray;
            this.pb1.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pb1, "pb1");
            this.pb1.Maximum = 10;
            this.pb1.Name = "pb1";
            this.pb1.Step = 1;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.musicbox);
            this.groupBox1.Controls.Add(this.musicb);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // musicbox
            // 
            this.musicbox.FormattingEnabled = true;
            this.musicbox.Items.AddRange(new object[] {
            resources.GetString("musicbox.Items"),
            resources.GetString("musicbox.Items1")});
            resources.ApplyResources(this.musicbox, "musicbox");
            this.musicbox.Name = "musicbox";
            this.musicbox.SelectedIndexChanged += new System.EventHandler(this.musicbox_SelectedIndexChanged);
            // 
            // musicb
            // 
            resources.ApplyResources(this.musicb, "musicb");
            this.musicb.Name = "musicb";
            this.musicb.UseVisualStyleBackColor = true;
            this.musicb.Click += new System.EventHandler(this.musicb_Click);
            // 
            // AGG
            // 
            resources.ApplyResources(this.AGG, "AGG");
            this.AGG.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.AGG.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.AGG.Name = "AGG";
            this.AGG.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.AGG.ValueChanged += new System.EventHandler(this.AGG_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AGG);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.Save_B);
            this.Controls.Add(this.Load_B);
            this.Controls.Add(this.controleer);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AGG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Load_B;
        private System.Windows.Forms.Button Save_B;
        public System.Windows.Forms.ProgressBar pb1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox musicbox;
        private System.Windows.Forms.Button musicb;
        public System.Windows.Forms.Button controleer;
        public System.Windows.Forms.NumericUpDown AGG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

