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
namespace GUI
{
    partial class UI_nieuw_wijzig_product
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_nieuw_wijzig_product));
            this.B_annuleren = new Nevron.UI.WinForm.Controls.NButton();
            this.T_prijs = new System.Windows.Forms.TextBox();
            this.T_gewicht = new System.Windows.Forms.TextBox();
            this.T_lengte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.B_ok = new Nevron.UI.WinForm.Controls.NButton();
            this.T_naam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_afbeelding = new Nevron.UI.WinForm.Controls.NComboBox();
            this.pb_thema = new System.Windows.Forms.PictureBox();
            this.B_plaatjes = new Nevron.UI.WinForm.Controls.NButton();
            this.label7 = new System.Windows.Forms.Label();
            this.group_beschrijving = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.T_beschrijving = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.T_breedte = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.T_hoogte = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_thema = new Nevron.UI.WinForm.Controls.NComboBox();
            this.pb_product = new System.Windows.Forms.PictureBox();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.B_verwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.listbox_themas = new Nevron.UI.WinForm.Controls.NListBox();
            this.B_toevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.L_fout = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.group_wijziging = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.T_wijziging = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pb_wijzigafbeelding = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_thema)).BeginInit();
            this.group_beschrijving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            this.group_wijziging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wijzigafbeelding)).BeginInit();
            this.nGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_annuleren
            // 
            this.B_annuleren.Location = new System.Drawing.Point(738, 413);
            this.B_annuleren.Name = "B_annuleren";
            this.B_annuleren.Size = new System.Drawing.Size(75, 23);
            this.B_annuleren.TabIndex = 12;
            this.B_annuleren.Text = "Sluiten";
            this.B_annuleren.UseVisualStyleBackColor = false;
            this.B_annuleren.Click += new System.EventHandler(this.B_annuleren_Click);
            // 
            // T_prijs
            // 
            this.T_prijs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_prijs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_prijs.Location = new System.Drawing.Point(173, 73);
            this.T_prijs.MaxLength = 13;
            this.T_prijs.Name = "T_prijs";
            this.T_prijs.Size = new System.Drawing.Size(93, 20);
            this.T_prijs.TabIndex = 2;
            this.T_prijs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Allow_prijs_komma);
            // 
            // T_gewicht
            // 
            this.T_gewicht.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_gewicht.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_gewicht.Location = new System.Drawing.Point(173, 39);
            this.T_gewicht.MaxLength = 13;
            this.T_gewicht.Name = "T_gewicht";
            this.T_gewicht.Size = new System.Drawing.Size(93, 20);
            this.T_gewicht.TabIndex = 1;
            this.T_gewicht.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Allow_gewicht_komma);
            // 
            // T_lengte
            // 
            this.T_lengte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_lengte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_lengte.Location = new System.Drawing.Point(228, 149);
            this.T_lengte.MaxLength = 5;
            this.T_lengte.Name = "T_lengte";
            this.T_lengte.Size = new System.Drawing.Size(36, 20);
            this.T_lengte.TabIndex = 3;
            this.T_lengte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Block_Letters_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Product Prijs (�):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Product Gewicht (kg):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Product Afmeting (cm):";
            // 
            // B_ok
            // 
            this.B_ok.Location = new System.Drawing.Point(648, 413);
            this.B_ok.Name = "B_ok";
            this.B_ok.Size = new System.Drawing.Size(75, 23);
            this.B_ok.TabIndex = 11;
            this.B_ok.Text = "Ok";
            this.B_ok.UseVisualStyleBackColor = false;
            this.B_ok.Click += new System.EventHandler(this.B_ok_Click);
            // 
            // T_naam
            // 
            this.T_naam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_naam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_naam.Location = new System.Drawing.Point(173, 7);
            this.T_naam.MaxLength = 13;
            this.T_naam.Name = "T_naam";
            this.T_naam.Size = new System.Drawing.Size(93, 20);
            this.T_naam.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Product Naam:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "Kies een afbeelding:";
            // 
            // combo_afbeelding
            // 
            this.combo_afbeelding.ListProperties.ColumnOnLeft = false;
            this.combo_afbeelding.Location = new System.Drawing.Point(287, 191);
            this.combo_afbeelding.Name = "combo_afbeelding";
            this.combo_afbeelding.Size = new System.Drawing.Size(168, 22);
            this.combo_afbeelding.TabIndex = 7;
            this.combo_afbeelding.Text = "nComboBox1";
            this.combo_afbeelding.SelectedIndexChanged += new System.EventHandler(this.combo_afbeelding_SelectedIndexChanged);
            // 
            // pb_thema
            // 
            this.pb_thema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_thema.Location = new System.Drawing.Point(275, 50);
            this.pb_thema.Name = "pb_thema";
            this.pb_thema.Size = new System.Drawing.Size(133, 109);
            this.pb_thema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_thema.TabIndex = 26;
            this.pb_thema.TabStop = false;
            // 
            // B_plaatjes
            // 
            this.B_plaatjes.Location = new System.Drawing.Point(161, 191);
            this.B_plaatjes.Name = "B_plaatjes";
            this.B_plaatjes.Size = new System.Drawing.Size(75, 23);
            this.B_plaatjes.TabIndex = 6;
            this.B_plaatjes.Text = "Bladeren";
            this.B_plaatjes.UseVisualStyleBackColor = false;
            this.B_plaatjes.Click += new System.EventHandler(this.B_plaatjes_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(248, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "of";
            // 
            // group_beschrijving
            // 
            this.group_beschrijving.Controls.Add(this.T_beschrijving);
            this.group_beschrijving.ImageIndex = 0;
            this.group_beschrijving.Location = new System.Drawing.Point(471, 12);
            this.group_beschrijving.Name = "group_beschrijving";
            this.group_beschrijving.Size = new System.Drawing.Size(358, 144);
            this.group_beschrijving.TabIndex = 9;
            this.group_beschrijving.TabStop = false;
            this.group_beschrijving.Text = "Beschrijving";
            // 
            // T_beschrijving
            // 
            this.T_beschrijving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_beschrijving.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_beschrijving.Location = new System.Drawing.Point(6, 24);
            this.T_beschrijving.MaxLength = 255;
            this.T_beschrijving.Multiline = true;
            this.T_beschrijving.Name = "T_beschrijving";
            this.T_beschrijving.Size = new System.Drawing.Size(339, 114);
            this.T_beschrijving.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Lengte:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Breedte:";
            // 
            // T_breedte
            // 
            this.T_breedte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_breedte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_breedte.Location = new System.Drawing.Point(323, 149);
            this.T_breedte.MaxLength = 5;
            this.T_breedte.Name = "T_breedte";
            this.T_breedte.Size = new System.Drawing.Size(36, 20);
            this.T_breedte.TabIndex = 4;
            this.T_breedte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Block_Letters_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(366, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Hoogte:";
            // 
            // T_hoogte
            // 
            this.T_hoogte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_hoogte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_hoogte.Location = new System.Drawing.Point(417, 149);
            this.T_hoogte.MaxLength = 5;
            this.T_hoogte.Name = "T_hoogte";
            this.T_hoogte.Size = new System.Drawing.Size(36, 20);
            this.T_hoogte.TabIndex = 5;
            this.T_hoogte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Block_Letters_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 14);
            this.label11.TabIndex = 48;
            this.label11.Text = "Kies een thema:";
            // 
            // combo_thema
            // 
            this.combo_thema.ListProperties.ColumnOnLeft = false;
            this.combo_thema.Location = new System.Drawing.Point(131, 35);
            this.combo_thema.Name = "combo_thema";
            this.combo_thema.Size = new System.Drawing.Size(119, 22);
            this.combo_thema.TabIndex = 1;
            this.combo_thema.Text = "nComboBox1";
            this.combo_thema.SelectedIndexChanged += new System.EventHandler(this.combo_thema_SelectedIndexChanged);
            // 
            // pb_product
            // 
            this.pb_product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_product.Location = new System.Drawing.Point(285, 7);
            this.pb_product.Name = "pb_product";
            this.pb_product.Size = new System.Drawing.Size(168, 123);
            this.pb_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_product.TabIndex = 49;
            this.pb_product.TabStop = false;
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.B_verwijderen);
            this.nGroupBox1.Controls.Add(this.listbox_themas);
            this.nGroupBox1.Controls.Add(this.B_toevoegen);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(15, 65);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(235, 125);
            this.nGroupBox1.TabIndex = 0;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Themas";
            // 
            // B_verwijderen
            // 
            this.B_verwijderen.Location = new System.Drawing.Point(160, 48);
            this.B_verwijderen.Name = "B_verwijderen";
            this.B_verwijderen.Size = new System.Drawing.Size(75, 23);
            this.B_verwijderen.TabIndex = 3;
            this.B_verwijderen.Text = "Verwijderen";
            this.B_verwijderen.UseVisualStyleBackColor = false;
            this.B_verwijderen.Click += new System.EventHandler(this.B_verwijderen_Click);
            // 
            // listbox_themas
            // 
            this.listbox_themas.ColumnOnLeft = false;
            this.listbox_themas.Location = new System.Drawing.Point(6, 19);
            this.listbox_themas.Name = "listbox_themas";
            this.listbox_themas.Size = new System.Drawing.Size(120, 104);
            this.listbox_themas.TabIndex = 1;
            this.listbox_themas.SelectedIndexChanged += new System.EventHandler(this.listbox_themas_SelectedIndexChanged);
            // 
            // B_toevoegen
            // 
            this.B_toevoegen.Location = new System.Drawing.Point(160, 19);
            this.B_toevoegen.Name = "B_toevoegen";
            this.B_toevoegen.Size = new System.Drawing.Size(75, 23);
            this.B_toevoegen.TabIndex = 2;
            this.B_toevoegen.Text = "Toevoegen";
            this.B_toevoegen.UseVisualStyleBackColor = false;
            this.B_toevoegen.Click += new System.EventHandler(this.B_toevoegen_Click);
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 442);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(841, 22);
            this.nStatusBar1.SizingGrip = false;
            this.nStatusBar1.TabIndex = 51;
            this.nStatusBar1.Text = "nStatusBar1";
            // 
            // L_fout
            // 
            this.L_fout.AutoSize = true;
            this.L_fout.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fout.ForeColor = System.Drawing.Color.Red;
            this.L_fout.Location = new System.Drawing.Point(90, 445);
            this.L_fout.Name = "L_fout";
            this.L_fout.Size = new System.Drawing.Size(0, 14);
            this.L_fout.TabIndex = 52;
            this.L_fout.TextChanged += new System.EventHandler(this.L_fout_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 446);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Pakketo :";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // group_wijziging
            // 
            this.group_wijziging.Controls.Add(this.T_wijziging);
            this.group_wijziging.Controls.Add(this.label13);
            this.group_wijziging.Controls.Add(this.pb_wijzigafbeelding);
            this.group_wijziging.ImageIndex = 0;
            this.group_wijziging.Location = new System.Drawing.Point(477, 197);
            this.group_wijziging.Name = "group_wijziging";
            this.group_wijziging.Size = new System.Drawing.Size(352, 191);
            this.group_wijziging.TabIndex = 10;
            this.group_wijziging.TabStop = false;
            this.group_wijziging.Text = "Recente Wijzigen";
            this.group_wijziging.Visible = false;
            // 
            // T_wijziging
            // 
            this.T_wijziging.Location = new System.Drawing.Point(15, 23);
            this.T_wijziging.Multiline = true;
            this.T_wijziging.Name = "T_wijziging";
            this.T_wijziging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.T_wijziging.Size = new System.Drawing.Size(157, 153);
            this.T_wijziging.TabIndex = 0;
            this.T_wijziging.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T_wijziging_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(181, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 14);
            this.label13.TabIndex = 13;
            this.label13.Text = "Gewijzigde Afbeelding";
            // 
            // pb_wijzigafbeelding
            // 
            this.pb_wijzigafbeelding.Location = new System.Drawing.Point(186, 69);
            this.pb_wijzigafbeelding.Name = "pb_wijzigafbeelding";
            this.pb_wijzigafbeelding.Size = new System.Drawing.Size(150, 106);
            this.pb_wijzigafbeelding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_wijzigafbeelding.TabIndex = 1;
            this.pb_wijzigafbeelding.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 14);
            this.label2.TabIndex = 55;
            this.label2.Text = "Product Afbeelding :";
            // 
            // nGroupBox2
            // 
            this.nGroupBox2.Controls.Add(this.pb_thema);
            this.nGroupBox2.Controls.Add(this.nGroupBox1);
            this.nGroupBox2.Controls.Add(this.label11);
            this.nGroupBox2.Controls.Add(this.combo_thema);
            this.nGroupBox2.ImageIndex = 0;
            this.nGroupBox2.Location = new System.Drawing.Point(12, 229);
            this.nGroupBox2.Name = "nGroupBox2";
            this.nGroupBox2.Size = new System.Drawing.Size(443, 195);
            this.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.nGroupBox2.TabIndex = 8;
            this.nGroupBox2.TabStop = false;
            this.nGroupBox2.Text = "Thema Gegevens";
            // 
            // UI_nieuw_wijzig_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.group_wijziging);
            this.Controls.Add(this.combo_afbeelding);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.B_plaatjes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.L_fout);
            this.Controls.Add(this.nStatusBar1);
            this.Controls.Add(this.pb_product);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.T_hoogte);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.T_breedte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.group_beschrijving);
            this.Controls.Add(this.B_annuleren);
            this.Controls.Add(this.T_prijs);
            this.Controls.Add(this.T_gewicht);
            this.Controls.Add(this.T_lengte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B_ok);
            this.Controls.Add(this.T_naam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nGroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_nieuw_wijzig_product";
            this.Sizable = false;
            this.Text = "Nieuw Product";
            ((System.ComponentModel.ISupportInitialize)(this.pb_thema)).EndInit();
            this.group_beschrijving.ResumeLayout(false);
            this.group_beschrijving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            this.group_wijziging.ResumeLayout(false);
            this.group_wijziging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wijzigafbeelding)).EndInit();
            this.nGroupBox2.ResumeLayout(false);
            this.nGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton B_annuleren;
        private System.Windows.Forms.TextBox T_prijs;
        private System.Windows.Forms.TextBox T_gewicht;
        private System.Windows.Forms.TextBox T_lengte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Nevron.UI.WinForm.Controls.NButton B_ok;
        private System.Windows.Forms.TextBox T_naam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Nevron.UI.WinForm.Controls.NComboBox combo_afbeelding;
        private System.Windows.Forms.PictureBox pb_thema;
        private Nevron.UI.WinForm.Controls.NButton B_plaatjes;
        private System.Windows.Forms.Label label7;
        private Nevron.UI.WinForm.Controls.NGroupBox group_beschrijving;
        private System.Windows.Forms.TextBox T_beschrijving;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox T_breedte;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox T_hoogte;
        private System.Windows.Forms.Label label11;
        private Nevron.UI.WinForm.Controls.NComboBox combo_thema;
        private System.Windows.Forms.PictureBox pb_product;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private Nevron.UI.WinForm.Controls.NListBox listbox_themas;
        private Nevron.UI.WinForm.Controls.NButton B_toevoegen;
        private Nevron.UI.WinForm.Controls.NButton B_verwijderen;
        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        private System.Windows.Forms.Label L_fout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer;
        private Nevron.UI.WinForm.Controls.NGroupBox group_wijziging;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pb_wijzigafbeelding;
        private Nevron.UI.WinForm.Controls.NTextBox T_wijziging;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
    }
}
