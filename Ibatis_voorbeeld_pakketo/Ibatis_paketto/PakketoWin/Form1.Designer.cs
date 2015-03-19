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
namespace PakketoWin
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
            this.B_nieuwPakket = new System.Windows.Forms.Button();
            this.T_pakket_naam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_maakProduct = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.T_product_naam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.T_kleur_naam = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.T_thema_naam = new System.Windows.Forms.TextBox();
            this.B_nieuwThema = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // B_nieuwPakket
            // 
            this.B_nieuwPakket.Location = new System.Drawing.Point(12, 12);
            this.B_nieuwPakket.Name = "B_nieuwPakket";
            this.B_nieuwPakket.Size = new System.Drawing.Size(73, 82);
            this.B_nieuwPakket.TabIndex = 0;
            this.B_nieuwPakket.Text = "Nieuw Pakket met alle producten relaties";
            this.B_nieuwPakket.UseVisualStyleBackColor = true;
            this.B_nieuwPakket.Click += new System.EventHandler(this.B_nieuwPakket_Click);
            // 
            // T_pakket_naam
            // 
            this.T_pakket_naam.Location = new System.Drawing.Point(173, 12);
            this.T_pakket_naam.Name = "T_pakket_naam";
            this.T_pakket_naam.Size = new System.Drawing.Size(100, 20);
            this.T_pakket_naam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pakket Naam:";
            // 
            // B_maakProduct
            // 
            this.B_maakProduct.Location = new System.Drawing.Point(12, 239);
            this.B_maakProduct.Name = "B_maakProduct";
            this.B_maakProduct.Size = new System.Drawing.Size(62, 37);
            this.B_maakProduct.TabIndex = 3;
            this.B_maakProduct.Text = "Nieuw Product";
            this.B_maakProduct.UseVisualStyleBackColor = true;
            this.B_maakProduct.Click += new System.EventHandler(this.B_maakProduct_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Naam:";
            // 
            // T_product_naam
            // 
            this.T_product_naam.Location = new System.Drawing.Point(176, 241);
            this.T_product_naam.Name = "T_product_naam";
            this.T_product_naam.Size = new System.Drawing.Size(100, 20);
            this.T_product_naam.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kleur Naam:";
            // 
            // T_kleur_naam
            // 
            this.T_kleur_naam.Location = new System.Drawing.Point(176, 190);
            this.T_kleur_naam.Name = "T_kleur_naam";
            this.T_kleur_naam.Size = new System.Drawing.Size(100, 20);
            this.T_kleur_naam.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Nieuw Kleur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Thema Naam:";
            // 
            // T_thema_naam
            // 
            this.T_thema_naam.Location = new System.Drawing.Point(176, 130);
            this.T_thema_naam.Name = "T_thema_naam";
            this.T_thema_naam.Size = new System.Drawing.Size(100, 20);
            this.T_thema_naam.TabIndex = 10;
            // 
            // B_nieuwThema
            // 
            this.B_nieuwThema.Location = new System.Drawing.Point(12, 121);
            this.B_nieuwThema.Name = "B_nieuwThema";
            this.B_nieuwThema.Size = new System.Drawing.Size(62, 37);
            this.B_nieuwThema.TabIndex = 9;
            this.B_nieuwThema.Text = "Nieuw Thema";
            this.B_nieuwThema.UseVisualStyleBackColor = true;
            this.B_nieuwThema.Click += new System.EventHandler(this.B_nieuwThema_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(326, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 264);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 294);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.T_thema_naam);
            this.Controls.Add(this.B_nieuwThema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.T_kleur_naam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.T_product_naam);
            this.Controls.Add(this.B_maakProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T_pakket_naam);
            this.Controls.Add(this.B_nieuwPakket);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_nieuwPakket;
        private System.Windows.Forms.TextBox T_pakket_naam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_maakProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox T_product_naam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox T_kleur_naam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox T_thema_naam;
        private System.Windows.Forms.Button B_nieuwThema;
        private System.Windows.Forms.TextBox textBox1;
    }
}

