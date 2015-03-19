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
namespace GUI.UI_Thema_Beheer
{
    partial class UI_thema_toevoegen_wijzigen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_thema_toevoegen_wijzigen));
            this.B_annuleren = new Nevron.UI.WinForm.Controls.NButton();
            this.B_ok = new Nevron.UI.WinForm.Controls.NButton();
            this.T_themanaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.group_themaoverzicht = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.combo_plaatjes = new Nevron.UI.WinForm.Controls.NColorComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.B_plaatjes = new Nevron.UI.WinForm.Controls.NButton();
            this.label15 = new System.Windows.Forms.Label();
            this.pb_plaatje = new System.Windows.Forms.PictureBox();
            this.group_kleuren = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.list_kleuren = new Nevron.UI.WinForm.Controls.NColorListBox();
            this.combo_kleuren = new Nevron.UI.WinForm.Controls.NColorComboBox();
            this.B_kleurverwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurtoevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.group_beschrijving = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.T_beschrijving = new System.Windows.Forms.TextBox();
            this.group_themaoverzicht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_plaatje)).BeginInit();
            this.group_kleuren.SuspendLayout();
            this.group_beschrijving.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_annuleren
            // 
            this.B_annuleren.Location = new System.Drawing.Point(592, 357);
            this.B_annuleren.Name = "B_annuleren";
            this.B_annuleren.Size = new System.Drawing.Size(75, 23);
            this.B_annuleren.TabIndex = 38;
            this.B_annuleren.Text = "Annuleren";
            this.B_annuleren.UseVisualStyleBackColor = false;
            this.B_annuleren.Click += new System.EventHandler(this.B_annuleren_Click);
            // 
            // B_ok
            // 
            this.B_ok.Location = new System.Drawing.Point(484, 357);
            this.B_ok.Name = "B_ok";
            this.B_ok.Size = new System.Drawing.Size(75, 23);
            this.B_ok.TabIndex = 29;
            this.B_ok.Text = "Ok";
            this.B_ok.UseVisualStyleBackColor = false;
            this.B_ok.Click += new System.EventHandler(this.B_ok_Click);
            // 
            // T_themanaam
            // 
            this.T_themanaam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_themanaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_themanaam.Location = new System.Drawing.Point(413, 329);
            this.T_themanaam.Name = "T_themanaam";
            this.T_themanaam.Size = new System.Drawing.Size(100, 20);
            this.T_themanaam.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Thema Naam:";
            // 
            // group_themaoverzicht
            // 
            this.group_themaoverzicht.Controls.Add(this.combo_plaatjes);
            this.group_themaoverzicht.Controls.Add(this.label19);
            this.group_themaoverzicht.Controls.Add(this.B_plaatjes);
            this.group_themaoverzicht.Controls.Add(this.label15);
            this.group_themaoverzicht.Controls.Add(this.pb_plaatje);
            this.group_themaoverzicht.ImageIndex = 0;
            this.group_themaoverzicht.Location = new System.Drawing.Point(290, 12);
            this.group_themaoverzicht.Name = "group_themaoverzicht";
            this.group_themaoverzicht.Size = new System.Drawing.Size(377, 306);
            this.group_themaoverzicht.TabIndex = 39;
            this.group_themaoverzicht.TabStop = false;
            this.group_themaoverzicht.Text = "Thema Overzicht";
            // 
            // combo_plaatjes
            // 
            this.combo_plaatjes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.combo_plaatjes.ListProperties.ColumnOnLeft = false;
            this.combo_plaatjes.Location = new System.Drawing.Point(261, 262);
            this.combo_plaatjes.Name = "combo_plaatjes";
            this.combo_plaatjes.Size = new System.Drawing.Size(100, 22);
            this.combo_plaatjes.TabIndex = 4;
            this.combo_plaatjes.Text = "(geen)";
            this.combo_plaatjes.SelectedIndexChanged += new System.EventHandler(this.combo_plaatjes_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(233, 267);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "of";
            // 
            // B_plaatjes
            // 
            this.B_plaatjes.Location = new System.Drawing.Point(144, 262);
            this.B_plaatjes.Name = "B_plaatjes";
            this.B_plaatjes.Size = new System.Drawing.Size(75, 23);
            this.B_plaatjes.TabIndex = 2;
            this.B_plaatjes.Text = "Bladeren";
            this.B_plaatjes.UseVisualStyleBackColor = false;
            this.B_plaatjes.Click += new System.EventHandler(this.B_plaatjes_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Kies een Afbeelding:";
            // 
            // pb_plaatje
            // 
            this.pb_plaatje.BackColor = System.Drawing.Color.LightGray;
            this.pb_plaatje.InitialImage = null;
            this.pb_plaatje.Location = new System.Drawing.Point(37, 31);
            this.pb_plaatje.Name = "pb_plaatje";
            this.pb_plaatje.Size = new System.Drawing.Size(324, 222);
            this.pb_plaatje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_plaatje.TabIndex = 0;
            this.pb_plaatje.TabStop = false;
            // 
            // group_kleuren
            // 
            this.group_kleuren.Controls.Add(this.list_kleuren);
            this.group_kleuren.Controls.Add(this.combo_kleuren);
            this.group_kleuren.Controls.Add(this.B_kleurverwijderen);
            this.group_kleuren.Controls.Add(this.B_kleurtoevoegen);
            this.group_kleuren.ImageIndex = 0;
            this.group_kleuren.Location = new System.Drawing.Point(12, 14);
            this.group_kleuren.Name = "group_kleuren";
            this.group_kleuren.Size = new System.Drawing.Size(261, 240);
            this.group_kleuren.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.group_kleuren.TabIndex = 40;
            this.group_kleuren.TabStop = false;
            this.group_kleuren.Text = "Kleuren Kiezen";
            // 
            // list_kleuren
            // 
            this.list_kleuren.Location = new System.Drawing.Point(6, 29);
            this.list_kleuren.Name = "list_kleuren";
            this.list_kleuren.Size = new System.Drawing.Size(249, 144);
            this.list_kleuren.TabIndex = 4;
            // 
            // combo_kleuren
            // 
            this.combo_kleuren.Location = new System.Drawing.Point(6, 208);
            this.combo_kleuren.Name = "combo_kleuren";
            this.combo_kleuren.Size = new System.Drawing.Size(128, 22);
            this.combo_kleuren.TabIndex = 3;
            this.combo_kleuren.Text = "kies een kleur";
            // 
            // B_kleurverwijderen
            // 
            this.B_kleurverwijderen.Location = new System.Drawing.Point(182, 179);
            this.B_kleurverwijderen.Name = "B_kleurverwijderen";
            this.B_kleurverwijderen.Size = new System.Drawing.Size(75, 23);
            this.B_kleurverwijderen.TabIndex = 2;
            this.B_kleurverwijderen.Text = "Verwijderen";
            this.B_kleurverwijderen.UseVisualStyleBackColor = false;
            this.B_kleurverwijderen.Click += new System.EventHandler(this.B_kleurverwijderen_Click);
            // 
            // B_kleurtoevoegen
            // 
            this.B_kleurtoevoegen.Location = new System.Drawing.Point(6, 179);
            this.B_kleurtoevoegen.Name = "B_kleurtoevoegen";
            this.B_kleurtoevoegen.Size = new System.Drawing.Size(75, 23);
            this.B_kleurtoevoegen.TabIndex = 1;
            this.B_kleurtoevoegen.Text = "Toevoegen";
            this.B_kleurtoevoegen.UseVisualStyleBackColor = false;
            this.B_kleurtoevoegen.Click += new System.EventHandler(this.B_kleurtoevoegen_Click);
            // 
            // group_beschrijving
            // 
            this.group_beschrijving.Controls.Add(this.T_beschrijving);
            this.group_beschrijving.ImageIndex = 0;
            this.group_beschrijving.Location = new System.Drawing.Point(18, 274);
            this.group_beschrijving.Name = "group_beschrijving";
            this.group_beschrijving.Size = new System.Drawing.Size(251, 106);
            this.group_beschrijving.TabIndex = 41;
            this.group_beschrijving.TabStop = false;
            this.group_beschrijving.Text = "Beschrijving";
            // 
            // T_beschrijving
            // 
            this.T_beschrijving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_beschrijving.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.T_beschrijving.Location = new System.Drawing.Point(6, 24);
            this.T_beschrijving.Multiline = true;
            this.T_beschrijving.Name = "T_beschrijving";
            this.T_beschrijving.Size = new System.Drawing.Size(243, 76);
            this.T_beschrijving.TabIndex = 0;
            // 
            // UI_thema_toevoegen_wijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 392);
            this.Controls.Add(this.group_beschrijving);
            this.Controls.Add(this.group_kleuren);
            this.Controls.Add(this.group_themaoverzicht);
            this.Controls.Add(this.B_annuleren);
            this.Controls.Add(this.B_ok);
            this.Controls.Add(this.T_themanaam);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_thema_toevoegen_wijzigen";
            this.Text = "Thema Toevoegen";
            this.group_themaoverzicht.ResumeLayout(false);
            this.group_themaoverzicht.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_plaatje)).EndInit();
            this.group_kleuren.ResumeLayout(false);
            this.group_beschrijving.ResumeLayout(false);
            this.group_beschrijving.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton B_annuleren;
        private Nevron.UI.WinForm.Controls.NButton B_ok;
        private System.Windows.Forms.TextBox T_themanaam;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NGroupBox group_themaoverzicht;
        private Nevron.UI.WinForm.Controls.NColorComboBox combo_plaatjes;
        private System.Windows.Forms.Label label19;
        private Nevron.UI.WinForm.Controls.NButton B_plaatjes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pb_plaatje;
        private Nevron.UI.WinForm.Controls.NGroupBox group_kleuren;
        private Nevron.UI.WinForm.Controls.NColorComboBox combo_kleuren;
        private Nevron.UI.WinForm.Controls.NButton B_kleurverwijderen;
        private Nevron.UI.WinForm.Controls.NButton B_kleurtoevoegen;
        private Nevron.UI.WinForm.Controls.NGroupBox group_beschrijving;
        private System.Windows.Forms.TextBox T_beschrijving;
        private Nevron.UI.WinForm.Controls.NColorListBox list_kleuren;
    }
}
