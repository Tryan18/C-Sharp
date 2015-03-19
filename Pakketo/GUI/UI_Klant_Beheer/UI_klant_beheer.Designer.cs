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
namespace GUI.UI_Klant_Beheer
{
    partial class UI_klant_beheer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_klant_beheer));
            this.dataGridView_klanten = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_klanttoevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_klantwijzigen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_klantverwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.nButton4 = new Nevron.UI.WinForm.Controls.NButton();
            this.group_klantgegevens = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.L_klantemail = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.L_klantfax = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.L_klantland = new System.Windows.Forms.Label();
            this.L_klantplaats = new System.Windows.Forms.Label();
            this.L_klantpostcode = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.L_klantadres = new System.Windows.Forms.Label();
            this.L_klanttel2 = new System.Windows.Forms.Label();
            this.L_klanttel = new System.Windows.Forms.Label();
            this.L_klantachternaam = new System.Windows.Forms.Label();
            this.L_klantvoornaam = new System.Windows.Forms.Label();
            this.L_klantnr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nListBox2 = new Nevron.UI.WinForm.Controls.NListBox();
            this.nListBox1 = new Nevron.UI.WinForm.Controls.NListBox();
            this.B_klantenlijst = new Nevron.UI.WinForm.Controls.NButton();
            this.label3 = new System.Windows.Forms.Label();
            this.T_opmerking = new Nevron.UI.WinForm.Controls.NTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_klanten)).BeginInit();
            this.group_klantgegevens.SuspendLayout();
            this.nGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_klanten
            // 
            this.dataGridView_klanten.AllowUserToAddRows = false;
            this.dataGridView_klanten.AllowUserToDeleteRows = false;
            this.dataGridView_klanten.AllowUserToResizeColumns = false;
            this.dataGridView_klanten.AllowUserToResizeRows = false;
            this.dataGridView_klanten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_klanten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_klanten.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_klanten.Name = "dataGridView_klanten";
            this.dataGridView_klanten.ReadOnly = true;
            this.dataGridView_klanten.RowHeadersVisible = false;
            this.dataGridView_klanten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_klanten.Size = new System.Drawing.Size(272, 247);
            this.dataGridView_klanten.TabIndex = 0;
            this.dataGridView_klanten.SelectionChanged += new System.EventHandler(this.dataGridView_klanten_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Klant ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "VoorNaam";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "AchterNaam";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // B_klanttoevoegen
            // 
            this.B_klanttoevoegen.Location = new System.Drawing.Point(316, 12);
            this.B_klanttoevoegen.Name = "B_klanttoevoegen";
            this.B_klanttoevoegen.Size = new System.Drawing.Size(92, 26);
            this.B_klanttoevoegen.TabIndex = 1;
            this.B_klanttoevoegen.Text = "Klant Toevoegen";
            this.B_klanttoevoegen.UseVisualStyleBackColor = false;
            this.B_klanttoevoegen.Click += new System.EventHandler(this.B_klanttoevoegen_Click);
            // 
            // B_klantwijzigen
            // 
            this.B_klantwijzigen.Location = new System.Drawing.Point(316, 56);
            this.B_klantwijzigen.Name = "B_klantwijzigen";
            this.B_klantwijzigen.Size = new System.Drawing.Size(92, 26);
            this.B_klantwijzigen.TabIndex = 2;
            this.B_klantwijzigen.Text = "Klant Wijzigen";
            this.B_klantwijzigen.UseVisualStyleBackColor = false;
            this.B_klantwijzigen.Click += new System.EventHandler(this.B_klantwijzigen_Click);
            // 
            // B_klantverwijderen
            // 
            this.B_klantverwijderen.Location = new System.Drawing.Point(316, 101);
            this.B_klantverwijderen.Name = "B_klantverwijderen";
            this.B_klantverwijderen.Size = new System.Drawing.Size(92, 26);
            this.B_klantverwijderen.TabIndex = 3;
            this.B_klantverwijderen.Text = "Klant Verwijderen";
            this.B_klantverwijderen.UseVisualStyleBackColor = false;
            this.B_klantverwijderen.Click += new System.EventHandler(this.B_klantverwijderen_Click);
            // 
            // nButton4
            // 
            this.nButton4.Location = new System.Drawing.Point(651, 455);
            this.nButton4.Name = "nButton4";
            this.nButton4.Size = new System.Drawing.Size(92, 26);
            this.nButton4.TabIndex = 4;
            this.nButton4.Text = "Sluiten";
            this.nButton4.UseVisualStyleBackColor = false;
            this.nButton4.Click += new System.EventHandler(this.nButton4_Click);
            // 
            // group_klantgegevens
            // 
            this.group_klantgegevens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.group_klantgegevens.Controls.Add(this.T_opmerking);
            this.group_klantgegevens.Controls.Add(this.label3);
            this.group_klantgegevens.Controls.Add(this.L_klantemail);
            this.group_klantgegevens.Controls.Add(this.label14);
            this.group_klantgegevens.Controls.Add(this.L_klantfax);
            this.group_klantgegevens.Controls.Add(this.label12);
            this.group_klantgegevens.Controls.Add(this.L_klantland);
            this.group_klantgegevens.Controls.Add(this.L_klantplaats);
            this.group_klantgegevens.Controls.Add(this.L_klantpostcode);
            this.group_klantgegevens.Controls.Add(this.label16);
            this.group_klantgegevens.Controls.Add(this.L_klantadres);
            this.group_klantgegevens.Controls.Add(this.L_klanttel2);
            this.group_klantgegevens.Controls.Add(this.L_klanttel);
            this.group_klantgegevens.Controls.Add(this.L_klantachternaam);
            this.group_klantgegevens.Controls.Add(this.L_klantvoornaam);
            this.group_klantgegevens.Controls.Add(this.L_klantnr);
            this.group_klantgegevens.Controls.Add(this.label2);
            this.group_klantgegevens.Controls.Add(this.label7);
            this.group_klantgegevens.Controls.Add(this.label6);
            this.group_klantgegevens.Controls.Add(this.label10);
            this.group_klantgegevens.Controls.Add(this.label9);
            this.group_klantgegevens.Controls.Add(this.label8);
            this.group_klantgegevens.Controls.Add(this.label4);
            this.group_klantgegevens.Controls.Add(this.label1);
            this.group_klantgegevens.ImageIndex = 0;
            this.group_klantgegevens.Location = new System.Drawing.Point(12, 296);
            this.group_klantgegevens.Name = "group_klantgegevens";
            this.group_klantgegevens.Size = new System.Drawing.Size(396, 185);
            this.group_klantgegevens.TabIndex = 6;
            this.group_klantgegevens.TabStop = false;
            this.group_klantgegevens.Text = "Klant Gegevens";
            // 
            // L_klantemail
            // 
            this.L_klantemail.AutoSize = true;
            this.L_klantemail.Location = new System.Drawing.Point(265, 73);
            this.L_klantemail.Name = "L_klantemail";
            this.L_klantemail.Size = new System.Drawing.Size(10, 13);
            this.L_klantemail.TabIndex = 15;
            this.L_klantemail.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.SteelBlue;
            this.label14.Location = new System.Drawing.Point(231, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Email :";
            // 
            // L_klantfax
            // 
            this.L_klantfax.AutoSize = true;
            this.L_klantfax.Location = new System.Drawing.Point(265, 53);
            this.L_klantfax.Name = "L_klantfax";
            this.L_klantfax.Size = new System.Drawing.Size(10, 13);
            this.L_klantfax.TabIndex = 13;
            this.L_klantfax.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(231, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Fax :";
            // 
            // L_klantland
            // 
            this.L_klantland.AutoSize = true;
            this.L_klantland.Location = new System.Drawing.Point(94, 136);
            this.L_klantland.Name = "L_klantland";
            this.L_klantland.Size = new System.Drawing.Size(10, 13);
            this.L_klantland.TabIndex = 11;
            this.L_klantland.Text = "-";
            // 
            // L_klantplaats
            // 
            this.L_klantplaats.AutoSize = true;
            this.L_klantplaats.Location = new System.Drawing.Point(94, 114);
            this.L_klantplaats.Name = "L_klantplaats";
            this.L_klantplaats.Size = new System.Drawing.Size(10, 13);
            this.L_klantplaats.TabIndex = 10;
            this.L_klantplaats.Text = "-";
            // 
            // L_klantpostcode
            // 
            this.L_klantpostcode.AutoSize = true;
            this.L_klantpostcode.Location = new System.Drawing.Point(94, 94);
            this.L_klantpostcode.Name = "L_klantpostcode";
            this.L_klantpostcode.Size = new System.Drawing.Size(10, 13);
            this.L_klantpostcode.TabIndex = 9;
            this.L_klantpostcode.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.SteelBlue;
            this.label16.Location = new System.Drawing.Point(23, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Postcode :";
            // 
            // L_klantadres
            // 
            this.L_klantadres.AutoSize = true;
            this.L_klantadres.Location = new System.Drawing.Point(94, 73);
            this.L_klantadres.Name = "L_klantadres";
            this.L_klantadres.Size = new System.Drawing.Size(10, 13);
            this.L_klantadres.TabIndex = 1;
            this.L_klantadres.Text = "-";
            // 
            // L_klanttel2
            // 
            this.L_klanttel2.AutoSize = true;
            this.L_klanttel2.Location = new System.Drawing.Point(265, 34);
            this.L_klanttel2.Name = "L_klanttel2";
            this.L_klanttel2.Size = new System.Drawing.Size(10, 13);
            this.L_klanttel2.TabIndex = 1;
            this.L_klanttel2.Text = "-";
            // 
            // L_klanttel
            // 
            this.L_klanttel.AutoSize = true;
            this.L_klanttel.Location = new System.Drawing.Point(265, 16);
            this.L_klanttel.Name = "L_klanttel";
            this.L_klanttel.Size = new System.Drawing.Size(10, 13);
            this.L_klanttel.TabIndex = 1;
            this.L_klanttel.Text = "-";
            // 
            // L_klantachternaam
            // 
            this.L_klantachternaam.AutoSize = true;
            this.L_klantachternaam.Location = new System.Drawing.Point(94, 53);
            this.L_klantachternaam.Name = "L_klantachternaam";
            this.L_klantachternaam.Size = new System.Drawing.Size(10, 13);
            this.L_klantachternaam.TabIndex = 1;
            this.L_klantachternaam.Text = "-";
            // 
            // L_klantvoornaam
            // 
            this.L_klantvoornaam.AutoSize = true;
            this.L_klantvoornaam.Location = new System.Drawing.Point(94, 34);
            this.L_klantvoornaam.Name = "L_klantvoornaam";
            this.L_klantvoornaam.Size = new System.Drawing.Size(10, 13);
            this.L_klantvoornaam.TabIndex = 1;
            this.L_klantvoornaam.Text = "-";
            // 
            // L_klantnr
            // 
            this.L_klantnr.AutoSize = true;
            this.L_klantnr.Location = new System.Drawing.Point(94, 16);
            this.L_klantnr.Name = "L_klantnr";
            this.L_klantnr.Size = new System.Drawing.Size(10, 13);
            this.L_klantnr.TabIndex = 1;
            this.L_klantnr.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nummer :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(231, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tel2 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(231, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tel :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(23, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Land :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(23, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Plaats :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(23, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Adres :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(23, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Achternaam :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voornaam : ";
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.label17);
            this.nGroupBox1.Controls.Add(this.label15);
            this.nGroupBox1.Controls.Add(this.nListBox2);
            this.nGroupBox1.Controls.Add(this.nListBox1);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(460, 12);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(282, 412);
            this.nGroupBox1.TabIndex = 7;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Bestellingen";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.SteelBlue;
            this.label17.Location = new System.Drawing.Point(22, 234);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Pakketten :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.SteelBlue;
            this.label15.Location = new System.Drawing.Point(14, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Bestellingen :";
            // 
            // nListBox2
            // 
            this.nListBox2.Location = new System.Drawing.Point(90, 232);
            this.nListBox2.Name = "nListBox2";
            this.nListBox2.ScrollAlwaysVisible = true;
            this.nListBox2.Size = new System.Drawing.Size(172, 144);
            this.nListBox2.TabIndex = 1;
            // 
            // nListBox1
            // 
            this.nListBox1.Location = new System.Drawing.Point(90, 33);
            this.nListBox1.Name = "nListBox1";
            this.nListBox1.ScrollAlwaysVisible = true;
            this.nListBox1.Size = new System.Drawing.Size(172, 144);
            this.nListBox1.TabIndex = 0;
            this.nListBox1.SelectedIndexChanged += new System.EventHandler(this.nListBox1_SelectedIndexChanged);
            // 
            // B_klantenlijst
            // 
            this.B_klantenlijst.Location = new System.Drawing.Point(303, 234);
            this.B_klantenlijst.Name = "B_klantenlijst";
            this.B_klantenlijst.Size = new System.Drawing.Size(105, 24);
            this.B_klantenlijst.TabIndex = 8;
            this.B_klantenlijst.Text = "Herlaad Klanten Lijst";
            this.B_klantenlijst.UseVisualStyleBackColor = false;
            this.B_klantenlijst.Click += new System.EventHandler(this.B_klantenlijst_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(231, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Opmerking";
            // 
            // T_opmerking
            // 
            this.T_opmerking.Location = new System.Drawing.Point(234, 112);
            this.T_opmerking.Multiline = true;
            this.T_opmerking.Name = "T_opmerking";
            this.T_opmerking.Size = new System.Drawing.Size(156, 67);
            this.T_opmerking.TabIndex = 17;
            // 
            // UI_klant_beheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 493);
            this.Controls.Add(this.B_klantenlijst);
            this.Controls.Add(this.nGroupBox1);
            this.Controls.Add(this.group_klantgegevens);
            this.Controls.Add(this.nButton4);
            this.Controls.Add(this.B_klantverwijderen);
            this.Controls.Add(this.B_klantwijzigen);
            this.Controls.Add(this.B_klanttoevoegen);
            this.Controls.Add(this.dataGridView_klanten);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_klant_beheer";
            this.Text = "Klant Administratie";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_klanten)).EndInit();
            this.group_klantgegevens.ResumeLayout(false);
            this.group_klantgegevens.PerformLayout();
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_klanten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Nevron.UI.WinForm.Controls.NButton B_klanttoevoegen;
        private Nevron.UI.WinForm.Controls.NButton B_klantwijzigen;
        private Nevron.UI.WinForm.Controls.NButton B_klantverwijderen;
        private Nevron.UI.WinForm.Controls.NButton nButton4;
        private Nevron.UI.WinForm.Controls.NGroupBox group_klantgegevens;
        private System.Windows.Forms.Label L_klantpostcode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label L_klantadres;
        private System.Windows.Forms.Label L_klanttel2;
        private System.Windows.Forms.Label L_klantachternaam;
        private System.Windows.Forms.Label L_klantvoornaam;
        private System.Windows.Forms.Label L_klantnr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_klanttel;
        private System.Windows.Forms.Label L_klantland;
        private System.Windows.Forms.Label L_klantplaats;
        private System.Windows.Forms.Label L_klantfax;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label L_klantemail;
        private System.Windows.Forms.Label label14;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private Nevron.UI.WinForm.Controls.NListBox nListBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private Nevron.UI.WinForm.Controls.NListBox nListBox2;
        private Nevron.UI.WinForm.Controls.NButton B_klantenlijst;
        private Nevron.UI.WinForm.Controls.NTextBox T_opmerking;
        private System.Windows.Forms.Label label3;

    }
}
