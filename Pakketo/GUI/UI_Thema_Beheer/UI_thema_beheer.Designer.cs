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
    partial class UI_thema_beheer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_thema_beheer));
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.list_pakketten = new Nevron.UI.WinForm.Controls.NListBox();
            this.list_kleuren = new Nevron.UI.WinForm.Controls.NListBox();
            this.B_themalijst = new Nevron.UI.WinForm.Controls.NButton();
            this.B_themaverwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_themawijzigen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_thematoevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.dataGridView_thema = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_beschrijving = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.T_beschrijving = new Nevron.UI.WinForm.Controls.NTextBox();
            this.B_sluiten = new Nevron.UI.WinForm.Controls.NButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_plaatje = new System.Windows.Forms.PictureBox();
            this.nGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_thema)).BeginInit();
            this.group_beschrijving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_plaatje)).BeginInit();
            this.SuspendLayout();
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox1.Controls.Add(this.label17);
            this.nGroupBox1.Controls.Add(this.label15);
            this.nGroupBox1.Controls.Add(this.list_pakketten);
            this.nGroupBox1.Controls.Add(this.list_kleuren);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(436, 12);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(282, 353);
            this.nGroupBox1.TabIndex = 8;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Thema Inhoud";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.SteelBlue;
            this.label17.Location = new System.Drawing.Point(22, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Pakketten :";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.SteelBlue;
            this.label15.Location = new System.Drawing.Point(14, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Kleuren :";
            // 
            // list_pakketten
            // 
            this.list_pakketten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_pakketten.ColumnOnLeft = false;
            this.list_pakketten.Location = new System.Drawing.Point(90, 193);
            this.list_pakketten.Name = "list_pakketten";
            this.list_pakketten.ScrollAlwaysVisible = true;
            this.list_pakketten.Size = new System.Drawing.Size(172, 144);
            this.list_pakketten.TabIndex = 1;
            // 
            // list_kleuren
            // 
            this.list_kleuren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_kleuren.ColumnOnLeft = false;
            this.list_kleuren.Location = new System.Drawing.Point(90, 33);
            this.list_kleuren.Name = "list_kleuren";
            this.list_kleuren.ScrollAlwaysVisible = true;
            this.list_kleuren.Size = new System.Drawing.Size(172, 144);
            this.list_kleuren.TabIndex = 0;
            // 
            // B_themalijst
            // 
            this.B_themalijst.Location = new System.Drawing.Point(303, 234);
            this.B_themalijst.Name = "B_themalijst";
            this.B_themalijst.Size = new System.Drawing.Size(105, 24);
            this.B_themalijst.TabIndex = 13;
            this.B_themalijst.Text = "Herlaad Thema Lijst";
            this.B_themalijst.UseVisualStyleBackColor = false;
            this.B_themalijst.Click += new System.EventHandler(this.B_themalijst_Click);
            // 
            // B_themaverwijderen
            // 
            this.B_themaverwijderen.Enabled = false;
            this.B_themaverwijderen.Location = new System.Drawing.Point(303, 101);
            this.B_themaverwijderen.Name = "B_themaverwijderen";
            this.B_themaverwijderen.Size = new System.Drawing.Size(105, 26);
            this.B_themaverwijderen.TabIndex = 12;
            this.B_themaverwijderen.Text = "Thema Verwijderen";
            this.B_themaverwijderen.UseVisualStyleBackColor = false;
            // 
            // B_themawijzigen
            // 
            this.B_themawijzigen.Enabled = false;
            this.B_themawijzigen.Location = new System.Drawing.Point(303, 56);
            this.B_themawijzigen.Name = "B_themawijzigen";
            this.B_themawijzigen.Size = new System.Drawing.Size(105, 26);
            this.B_themawijzigen.TabIndex = 11;
            this.B_themawijzigen.Text = "Thema Wijzigen";
            this.B_themawijzigen.UseVisualStyleBackColor = false;
            // 
            // B_thematoevoegen
            // 
            this.B_thematoevoegen.Location = new System.Drawing.Point(303, 12);
            this.B_thematoevoegen.Name = "B_thematoevoegen";
            this.B_thematoevoegen.Size = new System.Drawing.Size(105, 26);
            this.B_thematoevoegen.TabIndex = 10;
            this.B_thematoevoegen.Text = "Thema Toevoegen";
            this.B_thematoevoegen.UseVisualStyleBackColor = false;
            this.B_thematoevoegen.Click += new System.EventHandler(this.B_thematoevoegen_Click);
            // 
            // dataGridView_thema
            // 
            this.dataGridView_thema.AllowUserToAddRows = false;
            this.dataGridView_thema.AllowUserToDeleteRows = false;
            this.dataGridView_thema.AllowUserToResizeColumns = false;
            this.dataGridView_thema.AllowUserToResizeRows = false;
            this.dataGridView_thema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_thema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_thema.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_thema.MultiSelect = false;
            this.dataGridView_thema.Name = "dataGridView_thema";
            this.dataGridView_thema.ReadOnly = true;
            this.dataGridView_thema.RowHeadersVisible = false;
            this.dataGridView_thema.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_thema.Size = new System.Drawing.Size(272, 219);
            this.dataGridView_thema.TabIndex = 9;
            this.dataGridView_thema.RowHeaderCellChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_thema_RowHeaderCellChanged);
            this.dataGridView_thema.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_thema_CellClick);
            this.dataGridView_thema.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_thema_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Thema ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Naam";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 192;
            // 
            // group_beschrijving
            // 
            this.group_beschrijving.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.group_beschrijving.Controls.Add(this.T_beschrijving);
            this.group_beschrijving.ImageIndex = 0;
            this.group_beschrijving.Location = new System.Drawing.Point(12, 359);
            this.group_beschrijving.Name = "group_beschrijving";
            this.group_beschrijving.Size = new System.Drawing.Size(345, 141);
            this.group_beschrijving.TabIndex = 14;
            this.group_beschrijving.TabStop = false;
            this.group_beschrijving.Text = "Beschrijving";
            // 
            // T_beschrijving
            // 
            this.T_beschrijving.Location = new System.Drawing.Point(6, 19);
            this.T_beschrijving.Multiline = true;
            this.T_beschrijving.Name = "T_beschrijving";
            this.T_beschrijving.Size = new System.Drawing.Size(333, 116);
            this.T_beschrijving.TabIndex = 0;
            // 
            // B_sluiten
            // 
            this.B_sluiten.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_sluiten.Location = new System.Drawing.Point(643, 477);
            this.B_sluiten.Name = "B_sluiten";
            this.B_sluiten.Size = new System.Drawing.Size(75, 23);
            this.B_sluiten.TabIndex = 39;
            this.B_sluiten.Text = "Sluiten";
            this.B_sluiten.UseVisualStyleBackColor = false;
            this.B_sluiten.Click += new System.EventHandler(this.B_sluiten_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Plaatje Thema :";
            // 
            // pb_plaatje
            // 
            this.pb_plaatje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_plaatje.Location = new System.Drawing.Point(405, 394);
            this.pb_plaatje.Name = "pb_plaatje";
            this.pb_plaatje.Size = new System.Drawing.Size(182, 106);
            this.pb_plaatje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_plaatje.TabIndex = 41;
            this.pb_plaatje.TabStop = false;
            // 
            // UI_thema_beheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 512);
            this.Controls.Add(this.pb_plaatje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_sluiten);
            this.Controls.Add(this.group_beschrijving);
            this.Controls.Add(this.B_themalijst);
            this.Controls.Add(this.B_themaverwijderen);
            this.Controls.Add(this.B_themawijzigen);
            this.Controls.Add(this.B_thematoevoegen);
            this.Controls.Add(this.dataGridView_thema);
            this.Controls.Add(this.nGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_thema_beheer";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Thema Aanpassen";
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_thema)).EndInit();
            this.group_beschrijving.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_plaatje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private Nevron.UI.WinForm.Controls.NListBox list_pakketten;
        private Nevron.UI.WinForm.Controls.NListBox list_kleuren;
        private Nevron.UI.WinForm.Controls.NButton B_themalijst;
        private Nevron.UI.WinForm.Controls.NButton B_themaverwijderen;
        private Nevron.UI.WinForm.Controls.NButton B_themawijzigen;
        private Nevron.UI.WinForm.Controls.NButton B_thematoevoegen;
        private System.Windows.Forms.DataGridView dataGridView_thema;
        private Nevron.UI.WinForm.Controls.NGroupBox group_beschrijving;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Nevron.UI.WinForm.Controls.NButton B_sluiten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_plaatje;
        private Nevron.UI.WinForm.Controls.NTextBox T_beschrijving;
    }
}
