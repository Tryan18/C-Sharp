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
    partial class UI_product_beheer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_product_beheer));
            this.B_producttoevoegen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_productwijzigen = new Nevron.UI.WinForm.Controls.NButton();
            this.B_productverwijderen = new Nevron.UI.WinForm.Controls.NButton();
            this.dataGridView_product = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combo_thema = new Nevron.UI.WinForm.Controls.NColorComboBox();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.T_beschrijving = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_sluiten = new Nevron.UI.WinForm.Controls.NButton();
            this.pb_afbeelding = new System.Windows.Forms.PictureBox();
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.label3 = new System.Windows.Forms.Label();
            this.L_fout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_product)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_afbeelding)).BeginInit();
            this.SuspendLayout();
            // 
            // B_producttoevoegen
            // 
            this.B_producttoevoegen.Location = new System.Drawing.Point(306, 12);
            this.B_producttoevoegen.Name = "B_producttoevoegen";
            this.B_producttoevoegen.Size = new System.Drawing.Size(110, 23);
            this.B_producttoevoegen.TabIndex = 1;
            this.B_producttoevoegen.Text = "Product Toevoegen";
            this.B_producttoevoegen.UseVisualStyleBackColor = false;
            this.B_producttoevoegen.Click += new System.EventHandler(this.B_producttoevoegen_Click);
            // 
            // B_productwijzigen
            // 
            this.B_productwijzigen.Location = new System.Drawing.Point(306, 58);
            this.B_productwijzigen.Name = "B_productwijzigen";
            this.B_productwijzigen.Size = new System.Drawing.Size(110, 23);
            this.B_productwijzigen.TabIndex = 2;
            this.B_productwijzigen.Text = "Product Wijzigen";
            this.B_productwijzigen.UseVisualStyleBackColor = false;
            this.B_productwijzigen.Click += new System.EventHandler(this.B_productwijzigen_Click);
            // 
            // B_productverwijderen
            // 
            this.B_productverwijderen.Location = new System.Drawing.Point(306, 108);
            this.B_productverwijderen.Name = "B_productverwijderen";
            this.B_productverwijderen.Size = new System.Drawing.Size(110, 23);
            this.B_productverwijderen.TabIndex = 3;
            this.B_productverwijderen.Text = "Product Verwijderen";
            this.B_productverwijderen.UseVisualStyleBackColor = false;
            this.B_productverwijderen.Click += new System.EventHandler(this.B_productverwijderen_Click);
            // 
            // dataGridView_product
            // 
            this.dataGridView_product.AllowUserToAddRows = false;
            this.dataGridView_product.AllowUserToDeleteRows = false;
            this.dataGridView_product.AllowUserToResizeColumns = false;
            this.dataGridView_product.AllowUserToResizeRows = false;
            this.dataGridView_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_product.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_product.MultiSelect = false;
            this.dataGridView_product.Name = "dataGridView_product";
            this.dataGridView_product.ReadOnly = true;
            this.dataGridView_product.RowHeadersVisible = false;
            this.dataGridView_product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_product.Size = new System.Drawing.Size(268, 209);
            this.dataGridView_product.TabIndex = 42;
            this.dataGridView_product.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_product_RowStateChanged);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Product ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Naam";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 192;
            // 
            // combo_thema
            // 
            this.combo_thema.ListProperties.ColumnOnLeft = false;
            this.combo_thema.Location = new System.Drawing.Point(163, 224);
            this.combo_thema.Name = "combo_thema";
            this.combo_thema.Size = new System.Drawing.Size(117, 22);
            this.combo_thema.TabIndex = 46;
            this.combo_thema.SelectedIndexChanged += new System.EventHandler(this.combo_thema_SelectedIndexChanged);
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.T_beschrijving);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(12, 252);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(268, 149);
            this.nGroupBox1.TabIndex = 47;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Beschrijving";
            // 
            // T_beschrijving
            // 
            this.T_beschrijving.Enabled = false;
            this.T_beschrijving.Location = new System.Drawing.Point(6, 19);
            this.T_beschrijving.Multiline = true;
            this.T_beschrijving.Name = "T_beschrijving";
            this.T_beschrijving.Size = new System.Drawing.Size(256, 124);
            this.T_beschrijving.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Kies een Thema :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Afbeelding";
            // 
            // B_sluiten
            // 
            this.B_sluiten.Location = new System.Drawing.Point(345, 372);
            this.B_sluiten.Name = "B_sluiten";
            this.B_sluiten.Size = new System.Drawing.Size(75, 23);
            this.B_sluiten.TabIndex = 50;
            this.B_sluiten.Text = "Sluiten";
            this.B_sluiten.UseVisualStyleBackColor = false;
            this.B_sluiten.Click += new System.EventHandler(this.B_sluiten_Click);
            // 
            // pb_afbeelding
            // 
            this.pb_afbeelding.Location = new System.Drawing.Point(306, 268);
            this.pb_afbeelding.Name = "pb_afbeelding";
            this.pb_afbeelding.Size = new System.Drawing.Size(115, 87);
            this.pb_afbeelding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_afbeelding.TabIndex = 51;
            this.pb_afbeelding.TabStop = false;
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 409);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(432, 22);
            this.nStatusBar1.SizingGrip = false;
            this.nStatusBar1.TabIndex = 52;
            this.nStatusBar1.Tag = "";
            this.nStatusBar1.Text = "Pakketo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Pakketo";
            // 
            // L_fout
            // 
            this.L_fout.AutoSize = true;
            this.L_fout.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fout.ForeColor = System.Drawing.Color.Red;
            this.L_fout.Location = new System.Drawing.Point(160, 412);
            this.L_fout.Name = "L_fout";
            this.L_fout.Size = new System.Drawing.Size(0, 14);
            this.L_fout.TabIndex = 54;
            this.L_fout.Leave += new System.EventHandler(this.L_fout_Leave);
            // 
            // UI_product_beheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 431);
            this.Controls.Add(this.L_fout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nStatusBar1);
            this.Controls.Add(this.pb_afbeelding);
            this.Controls.Add(this.B_sluiten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nGroupBox1);
            this.Controls.Add(this.combo_thema);
            this.Controls.Add(this.dataGridView_product);
            this.Controls.Add(this.B_productverwijderen);
            this.Controls.Add(this.B_productwijzigen);
            this.Controls.Add(this.B_producttoevoegen);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI_product_beheer";
            this.Sizable = false;
            this.Text = "Producten Beheren";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_product)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_afbeelding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton B_producttoevoegen;
        private Nevron.UI.WinForm.Controls.NButton B_productwijzigen;
        private Nevron.UI.WinForm.Controls.NButton B_productverwijderen;
        private System.Windows.Forms.DataGridView dataGridView_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Nevron.UI.WinForm.Controls.NColorComboBox combo_thema;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private Nevron.UI.WinForm.Controls.NTextBox T_beschrijving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NButton B_sluiten;
        private System.Windows.Forms.PictureBox pb_afbeelding;
        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_fout;
    }
}
