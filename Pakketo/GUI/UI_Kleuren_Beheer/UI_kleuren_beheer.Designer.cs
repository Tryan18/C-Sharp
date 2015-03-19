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
    partial class UI_kleuren_beheer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_kleuren_beheer));
            this.B_sluiten = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurlijst = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurverwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurwijzigen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurtoevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.dataGridView_kleur = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kleur = new System.Windows.Forms.DataGridViewImageColumn();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.list_pakketten = new Nevron.UI.WinForm.Controls.NListBox();
            this.list_themas = new Nevron.UI.WinForm.Controls.NListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kleur)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_sluiten
            // 
            this.B_sluiten.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_sluiten.Location = new System.Drawing.Point(490, 496);
            this.B_sluiten.Name = "B_sluiten";
            this.B_sluiten.Size = new System.Drawing.Size(75, 23);
            this.B_sluiten.TabIndex = 47;
            this.B_sluiten.Text = "Sluiten";
            this.B_sluiten.UseVisualStyleBackColor = false;
            this.B_sluiten.Click += new System.EventHandler(this.B_sluiten_Click);
            // 
            // B_kleurlijst
            // 
            this.B_kleurlijst.Enabled = false;
            this.B_kleurlijst.Location = new System.Drawing.Point(303, 234);
            this.B_kleurlijst.Name = "B_kleurlijst";
            this.B_kleurlijst.Size = new System.Drawing.Size(105, 24);
            this.B_kleurlijst.TabIndex = 45;
            this.B_kleurlijst.Text = "Herlaad Kleur Lijst";
            this.B_kleurlijst.UseVisualStyleBackColor = false;
            // 
            // B_kleurverwijderen
            // 
            this.B_kleurverwijderen.Enabled = false;
            this.B_kleurverwijderen.Location = new System.Drawing.Point(303, 101);
            this.B_kleurverwijderen.Name = "B_kleurverwijderen";
            this.B_kleurverwijderen.Size = new System.Drawing.Size(105, 26);
            this.B_kleurverwijderen.TabIndex = 44;
            this.B_kleurverwijderen.Text = "Kleur Verwijderen";
            this.B_kleurverwijderen.UseVisualStyleBackColor = false;
            // 
            // B_kleurwijzigen
            // 
            this.B_kleurwijzigen.Enabled = false;
            this.B_kleurwijzigen.Location = new System.Drawing.Point(303, 56);
            this.B_kleurwijzigen.Name = "B_kleurwijzigen";
            this.B_kleurwijzigen.Size = new System.Drawing.Size(105, 26);
            this.B_kleurwijzigen.TabIndex = 43;
            this.B_kleurwijzigen.Text = "Kleur Wijzigen";
            this.B_kleurwijzigen.UseVisualStyleBackColor = false;
            // 
            // B_kleurtoevoegen
            // 
            this.B_kleurtoevoegen.Location = new System.Drawing.Point(303, 12);
            this.B_kleurtoevoegen.Name = "B_kleurtoevoegen";
            this.B_kleurtoevoegen.Size = new System.Drawing.Size(105, 26);
            this.B_kleurtoevoegen.TabIndex = 42;
            this.B_kleurtoevoegen.Text = "Kleur Toevoegen";
            this.B_kleurtoevoegen.UseVisualStyleBackColor = false;
            this.B_kleurtoevoegen.Click += new System.EventHandler(this.B_kleurtoevoegen_Click);
            // 
            // dataGridView_kleur
            // 
            this.dataGridView_kleur.AllowUserToAddRows = false;
            this.dataGridView_kleur.AllowUserToDeleteRows = false;
            this.dataGridView_kleur.AllowUserToResizeColumns = false;
            this.dataGridView_kleur.AllowUserToResizeRows = false;
            this.dataGridView_kleur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_kleur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.HexID,
            this.Kleur});
            this.dataGridView_kleur.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_kleur.MultiSelect = false;
            this.dataGridView_kleur.Name = "dataGridView_kleur";
            this.dataGridView_kleur.ReadOnly = true;
            this.dataGridView_kleur.RowHeadersVisible = false;
            this.dataGridView_kleur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_kleur.Size = new System.Drawing.Size(272, 247);
            this.dataGridView_kleur.TabIndex = 41;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Kleur ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Naam";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // HexID
            // 
            this.HexID.Frozen = true;
            this.HexID.HeaderText = "HexID";
            this.HexID.Name = "HexID";
            this.HexID.ReadOnly = true;
            this.HexID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HexID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexID.Width = 70;
            // 
            // Kleur
            // 
            this.Kleur.Frozen = true;
            this.Kleur.HeaderText = "Kleur";
            this.Kleur.Name = "Kleur";
            this.Kleur.ReadOnly = true;
            this.Kleur.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Kleur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Kleur.Width = 50;
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nGroupBox1.Controls.Add(this.label17);
            this.nGroupBox1.Controls.Add(this.label15);
            this.nGroupBox1.Controls.Add(this.list_pakketten);
            this.nGroupBox1.Controls.Add(this.list_themas);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(12, 298);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(535, 192);
            this.nGroupBox1.TabIndex = 40;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Kleur Inhoud";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.SteelBlue;
            this.label17.Location = new System.Drawing.Point(270, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Pakketten :";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.SteelBlue;
            this.label15.Location = new System.Drawing.Point(14, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Thema\'s :";
            // 
            // list_pakketten
            // 
            this.list_pakketten.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.list_pakketten.Location = new System.Drawing.Point(338, 33);
            this.list_pakketten.Name = "list_pakketten";
            this.list_pakketten.ScrollAlwaysVisible = true;
            this.list_pakketten.Size = new System.Drawing.Size(172, 144);
            this.list_pakketten.TabIndex = 1;
            // 
            // list_themas
            // 
            this.list_themas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.list_themas.Location = new System.Drawing.Point(90, 33);
            this.list_themas.Name = "list_themas";
            this.list_themas.ScrollAlwaysVisible = true;
            this.list_themas.Size = new System.Drawing.Size(172, 144);
            this.list_themas.TabIndex = 0;
            // 
            // UI_kleuren_beheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 531);
            this.Controls.Add(this.B_sluiten);
            this.Controls.Add(this.B_kleurlijst);
            this.Controls.Add(this.B_kleurverwijderen);
            this.Controls.Add(this.B_kleurwijzigen);
            this.Controls.Add(this.B_kleurtoevoegen);
            this.Controls.Add(this.dataGridView_kleur);
            this.Controls.Add(this.nGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_kleuren_beheer";
            this.Text = "Kleuren Beheer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kleur)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton B_sluiten;
        private Nevron.UI.WinForm.Controls.NButton B_kleurlijst;
        private Nevron.UI.WinForm.Controls.NButton B_kleurverwijderen;
        private Nevron.UI.WinForm.Controls.NButton B_kleurwijzigen;
        private Nevron.UI.WinForm.Controls.NButton B_kleurtoevoegen;
        private System.Windows.Forms.DataGridView dataGridView_kleur;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private Nevron.UI.WinForm.Controls.NListBox list_pakketten;
        private Nevron.UI.WinForm.Controls.NListBox list_themas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexID;
        private System.Windows.Forms.DataGridViewImageColumn Kleur;
    }
}
