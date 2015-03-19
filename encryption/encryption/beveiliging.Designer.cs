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
namespace encryption
{
    partial class beveiliging
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
            this.T_source = new System.Windows.Forms.TextBox();
            this.T_destination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_zoeken = new System.Windows.Forms.Button();
            this.B_doel = new System.Windows.Forms.Button();
            this.B_maak = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.B_sluiten = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.T_pass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // T_source
            // 
            this.T_source.Enabled = false;
            this.T_source.Location = new System.Drawing.Point(12, 27);
            this.T_source.Name = "T_source";
            this.T_source.Size = new System.Drawing.Size(366, 20);
            this.T_source.TabIndex = 0;
            // 
            // T_destination
            // 
            this.T_destination.Enabled = false;
            this.T_destination.Location = new System.Drawing.Point(12, 77);
            this.T_destination.Name = "T_destination";
            this.T_destination.Size = new System.Drawing.Size(366, 20);
            this.T_destination.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination File:";
            // 
            // B_zoeken
            // 
            this.B_zoeken.Location = new System.Drawing.Point(384, 25);
            this.B_zoeken.Name = "B_zoeken";
            this.B_zoeken.Size = new System.Drawing.Size(75, 23);
            this.B_zoeken.TabIndex = 4;
            this.B_zoeken.Text = "Browse";
            this.B_zoeken.UseVisualStyleBackColor = true;
            this.B_zoeken.Click += new System.EventHandler(this.B_zoeken_Click);
            // 
            // B_doel
            // 
            this.B_doel.Location = new System.Drawing.Point(384, 75);
            this.B_doel.Name = "B_doel";
            this.B_doel.Size = new System.Drawing.Size(75, 23);
            this.B_doel.TabIndex = 5;
            this.B_doel.Text = "Save";
            this.B_doel.UseVisualStyleBackColor = true;
            this.B_doel.Click += new System.EventHandler(this.b_save_Click);
            // 
            // B_maak
            // 
            this.B_maak.Location = new System.Drawing.Point(12, 129);
            this.B_maak.Name = "B_maak";
            this.B_maak.Size = new System.Drawing.Size(122, 23);
            this.B_maak.TabIndex = 6;
            this.B_maak.Text = "Encrypt / Decrypt";
            this.B_maak.UseVisualStyleBackColor = true;
            this.B_maak.Click += new System.EventHandler(this.Encrypt_Decrypt_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Open Text File *.txt| *.txt|Decrypt File (*.Ter)|*.Ter|Alle andere bestanden | *." +
                "*";
            this.openFile.Title = "Open een bestand";
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Encrypt File (*.Ter) | *.Ter |Decrypt File (*.?)|*.*| All Files (*.*) | *.*";
            this.saveFile.Title = "Opslaan als";
            this.saveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFile_FileOk);
            // 
            // B_sluiten
            // 
            this.B_sluiten.Location = new System.Drawing.Point(384, 129);
            this.B_sluiten.Name = "B_sluiten";
            this.B_sluiten.Size = new System.Drawing.Size(75, 23);
            this.B_sluiten.TabIndex = 7;
            this.B_sluiten.Text = "Exit";
            this.B_sluiten.UseVisualStyleBackColor = true;
            this.B_sluiten.Click += new System.EventHandler(this.B_sluiten_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password for File:";
            // 
            // T_pass
            // 
            this.T_pass.Location = new System.Drawing.Point(153, 133);
            this.T_pass.Name = "T_pass";
            this.T_pass.Size = new System.Drawing.Size(142, 20);
            this.T_pass.TabIndex = 8;
            // 
            // beveiliging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 164);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.T_pass);
            this.Controls.Add(this.B_sluiten);
            this.Controls.Add(this.B_maak);
            this.Controls.Add(this.B_doel);
            this.Controls.Add(this.B_zoeken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T_destination);
            this.Controls.Add(this.T_source);
            this.Name = "beveiliging";
            this.ShowIcon = false;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_source;
        private System.Windows.Forms.TextBox T_destination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_zoeken;
        private System.Windows.Forms.Button B_doel;
        private System.Windows.Forms.Button B_maak;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button B_sluiten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox T_pass;
    }
}
