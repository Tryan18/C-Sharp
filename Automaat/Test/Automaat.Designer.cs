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
namespace Test
{
    partial class Automaat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Automaat));
            this.koopKnop = new System.Windows.Forms.Button();
            this.textBlik = new System.Windows.Forms.TextBox();
            this.Features = new System.Windows.Forms.Label();
            this.geldIn = new System.Windows.Forms.Button();
            this.maakBlikje = new System.Windows.Forms.Button();
            this.verwijderBlikje = new System.Windows.Forms.Button();
            this.boem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.koopList = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.geldBox = new System.Windows.Forms.TextBox();
            this.maakPrijs = new System.Windows.Forms.TextBox();
            this.maakNaam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Stick = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.koopList)).BeginInit();
            this.SuspendLayout();
            // 
            // koopKnop
            // 
            this.koopKnop.Location = new System.Drawing.Point(142, 67);
            this.koopKnop.Name = "koopKnop";
            this.koopKnop.Size = new System.Drawing.Size(54, 24);
            this.koopKnop.TabIndex = 0;
            this.koopKnop.Text = "Koop";
            this.koopKnop.UseVisualStyleBackColor = true;
            this.koopKnop.Click += new System.EventHandler(this.koopKnop_Click);
            // 
            // textBlik
            // 
            this.textBlik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBlik.Location = new System.Drawing.Point(259, 24);
            this.textBlik.Multiline = true;
            this.textBlik.Name = "textBlik";
            this.textBlik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBlik.Size = new System.Drawing.Size(256, 312);
            this.textBlik.TabIndex = 1;
            // 
            // Features
            // 
            this.Features.AutoSize = true;
            this.Features.Location = new System.Drawing.Point(29, 9);
            this.Features.Name = "Features";
            this.Features.Size = new System.Drawing.Size(72, 13);
            this.Features.TabIndex = 2;
            this.Features.Text = "__Features__";
            // 
            // geldIn
            // 
            this.geldIn.Location = new System.Drawing.Point(141, 34);
            this.geldIn.Name = "geldIn";
            this.geldIn.Size = new System.Drawing.Size(85, 23);
            this.geldIn.TabIndex = 3;
            this.geldIn.Text = "Werp Geld in";
            this.geldIn.UseVisualStyleBackColor = true;
            this.geldIn.Click += new System.EventHandler(this.geldIn_Click);
            // 
            // maakBlikje
            // 
            this.maakBlikje.Location = new System.Drawing.Point(141, 103);
            this.maakBlikje.Name = "maakBlikje";
            this.maakBlikje.Size = new System.Drawing.Size(73, 23);
            this.maakBlikje.TabIndex = 4;
            this.maakBlikje.Text = "Maak Blikje";
            this.maakBlikje.UseVisualStyleBackColor = true;
            this.maakBlikje.Click += new System.EventHandler(this.maakBlikje_Click);
            // 
            // verwijderBlikje
            // 
            this.verwijderBlikje.Location = new System.Drawing.Point(141, 133);
            this.verwijderBlikje.Name = "verwijderBlikje";
            this.verwijderBlikje.Size = new System.Drawing.Size(73, 48);
            this.verwijderBlikje.TabIndex = 5;
            this.verwijderBlikje.Text = "Laatste Blikje Verwijderen";
            this.verwijderBlikje.UseVisualStyleBackColor = true;
            this.verwijderBlikje.Click += new System.EventHandler(this.verwijderBlikje_Click);
            // 
            // boem
            // 
            this.boem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boem.Location = new System.Drawing.Point(7, 342);
            this.boem.Name = "boem";
            this.boem.Size = new System.Drawing.Size(124, 23);
            this.boem.TabIndex = 6;
            this.boem.Text = "Blaas de automaat op!";
            this.boem.UseVisualStyleBackColor = true;
            this.boem.Click += new System.EventHandler(this.boem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Het aantal blikjes wat de automaat kan opslaan is 100 in totaal :)";
            // 
            // koopList
            // 
            this.koopList.Location = new System.Drawing.Point(87, 67);
            this.koopList.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.koopList.Name = "koopList";
            this.koopList.Size = new System.Drawing.Size(49, 20);
            this.koopList.TabIndex = 8;
            this.koopList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.koopList.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kies Blikje =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Waarde = ";
            // 
            // geldBox
            // 
            this.geldBox.Location = new System.Drawing.Point(87, 37);
            this.geldBox.Name = "geldBox";
            this.geldBox.Size = new System.Drawing.Size(49, 20);
            this.geldBox.TabIndex = 11;
            this.geldBox.Text = "0";
            this.geldBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.geldBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.geldBox_KeyPress);
            // 
            // maakPrijs
            // 
            this.maakPrijs.Location = new System.Drawing.Point(56, 130);
            this.maakPrijs.Name = "maakPrijs";
            this.maakPrijs.Size = new System.Drawing.Size(62, 20);
            this.maakPrijs.TabIndex = 12;
            this.maakPrijs.Text = "0";
            this.maakPrijs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maakPrijs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maakPrijs_KeyPress);
            // 
            // maakNaam
            // 
            this.maakNaam.Location = new System.Drawing.Point(56, 103);
            this.maakNaam.Name = "maakNaam";
            this.maakNaam.Size = new System.Drawing.Size(62, 20);
            this.maakNaam.TabIndex = 13;
            this.maakNaam.Text = "naam?";
            this.maakNaam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Prijs    =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Naam =";
            // 
            // Stick
            // 
            this.Stick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Stick.Location = new System.Drawing.Point(7, 313);
            this.Stick.Name = "Stick";
            this.Stick.Size = new System.Drawing.Size(94, 23);
            this.Stick.TabIndex = 16;
            this.Stick.Text = "Sigaret roken";
            this.Stick.UseVisualStyleBackColor = true;
            this.Stick.Click += new System.EventHandler(this.Stick_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "__Extra Features__";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Copyright 2006";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(256, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Terminal Venster";
            // 
            // Automaat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(527, 377);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stick);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maakNaam);
            this.Controls.Add(this.maakPrijs);
            this.Controls.Add(this.geldBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.koopList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boem);
            this.Controls.Add(this.verwijderBlikje);
            this.Controls.Add(this.maakBlikje);
            this.Controls.Add(this.geldIn);
            this.Controls.Add(this.Features);
            this.Controls.Add(this.textBlik);
            this.Controls.Add(this.koopKnop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Automaat";
            this.Text = "Automaat                                                                         " +
                "BETA Versie";
            ((System.ComponentModel.ISupportInitialize)(this.koopList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button koopKnop;
        private System.Windows.Forms.TextBox textBlik;
        private System.Windows.Forms.Label Features;
        private System.Windows.Forms.Button geldIn;
        private System.Windows.Forms.Button maakBlikje;
        private System.Windows.Forms.Button verwijderBlikje;
        private System.Windows.Forms.Button boem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown koopList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox geldBox;
        private System.Windows.Forms.TextBox maakPrijs;
        private System.Windows.Forms.TextBox maakNaam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Stick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

