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
namespace GUI.UI_Kleuren_Beheer
{
    partial class UI_kleur_toevoegen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_kleur_toevoegen));
            this.kleurkiezer = new Nevron.UI.WinForm.Controls.NColorPicker();
            this.B_ok = new Nevron.UI.WinForm.Controls.NButton();
            this.B_annuleren = new Nevron.UI.WinForm.Controls.NButton();
            this.T_naam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kleurkiezer
            // 
            // 
            // 
            // 
            this.kleurkiezer.ColorPane.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
            this.kleurkiezer.ColorPane.CommandLayout = Nevron.UI.WinForm.Controls.CommandLayout.HorizontalWrapping;
            this.kleurkiezer.ColorPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kleurkiezer.ColorPane.Location = new System.Drawing.Point(0, 0);
            this.kleurkiezer.ColorPane.Name = "nColorPane1";
            this.kleurkiezer.ColorPane.Selectable = true;
            this.kleurkiezer.ColorPane.SelectedIndex = 63;
            this.kleurkiezer.ColorPane.Size = new System.Drawing.Size(270, 269);
            this.kleurkiezer.ColorPane.TabIndex = 0;
            this.kleurkiezer.ColorPane.TabStop = false;
            this.kleurkiezer.ColorPane.Text = "nColorPane1";
            this.kleurkiezer.Location = new System.Drawing.Point(12, 12);
            this.kleurkiezer.Name = "kleurkiezer";
            this.kleurkiezer.Size = new System.Drawing.Size(280, 352);
            this.kleurkiezer.TabIndex = 0;
            // 
            // B_ok
            // 
            this.B_ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_ok.Location = new System.Drawing.Point(107, 450);
            this.B_ok.Name = "B_ok";
            this.B_ok.Size = new System.Drawing.Size(75, 23);
            this.B_ok.TabIndex = 1;
            this.B_ok.Text = "OK";
            this.B_ok.UseVisualStyleBackColor = false;
            this.B_ok.Click += new System.EventHandler(this.B_ok_Click);
            // 
            // B_annuleren
            // 
            this.B_annuleren.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_annuleren.Location = new System.Drawing.Point(219, 450);
            this.B_annuleren.Name = "B_annuleren";
            this.B_annuleren.Size = new System.Drawing.Size(75, 23);
            this.B_annuleren.TabIndex = 2;
            this.B_annuleren.Text = "Annuleren";
            this.B_annuleren.UseVisualStyleBackColor = false;
            this.B_annuleren.Click += new System.EventHandler(this.B_annuleren_Click);
            // 
            // T_naam
            // 
            this.T_naam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_naam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_naam.Location = new System.Drawing.Point(107, 398);
            this.T_naam.Name = "T_naam";
            this.T_naam.Size = new System.Drawing.Size(100, 20);
            this.T_naam.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kleur Naam:";
            // 
            // UI_kleur_toevoegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T_naam);
            this.Controls.Add(this.B_annuleren);
            this.Controls.Add(this.B_ok);
            this.Controls.Add(this.kleurkiezer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_kleur_toevoegen";
            this.Text = "Kleur Toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NColorPicker kleurkiezer;
        private Nevron.UI.WinForm.Controls.NButton B_ok;
        private Nevron.UI.WinForm.Controls.NButton B_annuleren;
        private System.Windows.Forms.TextBox T_naam;
        private System.Windows.Forms.Label label1;
    }
}
