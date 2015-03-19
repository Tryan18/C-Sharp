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
    partial class UI_hoofd_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_hoofd_menu));
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_pakketbeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_productbeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_kleurenbeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_klantbeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_bestellingbeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_themabeheer = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.B_pakketbeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.B_productbeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.B_kleurenbeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.nGroupBoxEx2 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.B_klantbeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.B_bestellingbeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.B_themabeheer = new Nevron.UI.WinForm.Controls.NButton();
            this.label_statusBar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.nTooltip = new Nevron.UI.WinForm.Controls.NTooltip();
            this.label_DatumTijd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.L_status = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
            this.nGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).BeginInit();
            this.nGroupBoxEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 460);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(605, 22);
            this.nStatusBar1.TabIndex = 0;
            this.nStatusBar1.Text = "nStatusBar1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem1,
            this.optiesToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem1
            // 
            this.bestandToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem});
            this.bestandToolStripMenuItem1.Name = "bestandToolStripMenuItem1";
            this.bestandToolStripMenuItem1.Size = new System.Drawing.Size(58, 20);
            this.bestandToolStripMenuItem1.Text = "Bestand";
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // optiesToolStripMenuItem1
            // 
            this.optiesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_pakketbeheer,
            this.tool_productbeheer,
            this.tool_kleurenbeheer,
            this.tool_klantbeheer,
            this.tool_bestellingbeheer,
            this.tool_themabeheer});
            this.optiesToolStripMenuItem1.Name = "optiesToolStripMenuItem1";
            this.optiesToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.optiesToolStripMenuItem1.Text = "Opties";
            // 
            // tool_pakketbeheer
            // 
            this.tool_pakketbeheer.Enabled = false;
            this.tool_pakketbeheer.Name = "tool_pakketbeheer";
            this.tool_pakketbeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_pakketbeheer.Text = "Pakket Beheren";
            this.tool_pakketbeheer.Click += new System.EventHandler(this.pakketBeherenToolStripMenuItem_Click);
            // 
            // tool_productbeheer
            // 
            this.tool_productbeheer.Enabled = false;
            this.tool_productbeheer.Name = "tool_productbeheer";
            this.tool_productbeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_productbeheer.Text = "Product Beheren";
            this.tool_productbeheer.Click += new System.EventHandler(this.productBeherenToolStripMenuItem_Click);
            // 
            // tool_kleurenbeheer
            // 
            this.tool_kleurenbeheer.Enabled = false;
            this.tool_kleurenbeheer.Name = "tool_kleurenbeheer";
            this.tool_kleurenbeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_kleurenbeheer.Text = "Kleuren Beheren";
            this.tool_kleurenbeheer.Click += new System.EventHandler(this.kleurenBeherenToolStripMenuItem_Click);
            // 
            // tool_klantbeheer
            // 
            this.tool_klantbeheer.Enabled = false;
            this.tool_klantbeheer.Name = "tool_klantbeheer";
            this.tool_klantbeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_klantbeheer.Text = "Klanten Beheren";
            this.tool_klantbeheer.Click += new System.EventHandler(this.klantenBeherenToolStripMenuItem_Click);
            // 
            // tool_bestellingbeheer
            // 
            this.tool_bestellingbeheer.Enabled = false;
            this.tool_bestellingbeheer.Name = "tool_bestellingbeheer";
            this.tool_bestellingbeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_bestellingbeheer.Text = "Bestellingen Beheren";
            this.tool_bestellingbeheer.Click += new System.EventHandler(this.bestellingenBeherenToolStripMenuItem_Click);
            // 
            // tool_themabeheer
            // 
            this.tool_themabeheer.Enabled = false;
            this.tool_themabeheer.Name = "tool_themabeheer";
            this.tool_themabeheer.Size = new System.Drawing.Size(185, 22);
            this.tool_themabeheer.Text = "Themas Beheren";
            this.tool_themabeheer.Click += new System.EventHandler(this.themasBeherenToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // optiesToolStripMenuItem
            // 
            this.optiesToolStripMenuItem.Name = "optiesToolStripMenuItem";
            this.optiesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.optiesToolStripMenuItem.Text = "Opties";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // nGroupBoxEx1
            // 
            this.nGroupBoxEx1.Controls.Add(this.B_pakketbeheer);
            this.nGroupBoxEx1.Controls.Add(this.B_productbeheer);
            this.nGroupBoxEx1.Controls.Add(this.B_kleurenbeheer);
            this.nGroupBoxEx1.HeaderItem.Text = "Pakket Samenstellen";
            this.nGroupBoxEx1.Location = new System.Drawing.Point(28, 156);
            this.nGroupBoxEx1.Name = "nGroupBoxEx1";
            this.nGroupBoxEx1.Size = new System.Drawing.Size(550, 110);
            this.nGroupBoxEx1.TabIndex = 0;
            this.nGroupBoxEx1.TabStop = false;
            this.nGroupBoxEx1.Text = "Beheren";
            // 
            // B_pakketbeheer
            // 
            this.B_pakketbeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_pakketbeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_pakketbeheer.Enabled = false;
            this.B_pakketbeheer.Image = global::GUI.Properties.Resources.Yeti_Box_Drop__Blue_;
            this.B_pakketbeheer.Location = new System.Drawing.Point(30, 29);
            this.B_pakketbeheer.Name = "B_pakketbeheer";
            this.B_pakketbeheer.Size = new System.Drawing.Size(74, 67);
            this.B_pakketbeheer.TabIndex = 1;
            this.B_pakketbeheer.UseVisualStyleBackColor = false;
            this.B_pakketbeheer.MouseLeave += new System.EventHandler(this.nButton_PakketBeheren_MouseLeave);
            this.B_pakketbeheer.Click += new System.EventHandler(this.nButton_PakketBeheren_Click);
            this.B_pakketbeheer.MouseHover += new System.EventHandler(this.nButton_PakketBeheren_MouseHover);
            // 
            // B_productbeheer
            // 
            this.B_productbeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_productbeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_productbeheer.Enabled = false;
            this.B_productbeheer.Image = ((System.Drawing.Image)(resources.GetObject("B_productbeheer.Image")));
            this.B_productbeheer.Location = new System.Drawing.Point(238, 29);
            this.B_productbeheer.Name = "B_productbeheer";
            this.B_productbeheer.Size = new System.Drawing.Size(74, 67);
            this.B_productbeheer.TabIndex = 2;
            this.B_productbeheer.UseVisualStyleBackColor = false;
            this.B_productbeheer.MouseLeave += new System.EventHandler(this.nButton_ProductenBeheren_MouseLeave);
            this.B_productbeheer.Click += new System.EventHandler(this.nButton_ProductenBeheren_Click);
            this.B_productbeheer.MouseHover += new System.EventHandler(this.nButton_ProductenBeheren_MouseHover);
            // 
            // B_kleurenbeheer
            // 
            this.B_kleurenbeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_kleurenbeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_kleurenbeheer.Enabled = false;
            this.B_kleurenbeheer.Image = global::GUI.Properties.Resources.color;
            this.B_kleurenbeheer.Location = new System.Drawing.Point(440, 29);
            this.B_kleurenbeheer.Name = "B_kleurenbeheer";
            this.B_kleurenbeheer.Size = new System.Drawing.Size(74, 67);
            this.B_kleurenbeheer.TabIndex = 3;
            this.B_kleurenbeheer.UseVisualStyleBackColor = false;
            this.B_kleurenbeheer.MouseLeave += new System.EventHandler(this.nButton_KleurenBeheren_MouseLeave);
            this.B_kleurenbeheer.Click += new System.EventHandler(this.nButton_KleurenBeheren_Click);
            this.B_kleurenbeheer.MouseHover += new System.EventHandler(this.nButton_KleurenBeheren_MouseHover);
            // 
            // nGroupBoxEx2
            // 
            this.nGroupBoxEx2.Controls.Add(this.B_klantbeheer);
            this.nGroupBoxEx2.Controls.Add(this.B_bestellingbeheer);
            this.nGroupBoxEx2.Controls.Add(this.B_themabeheer);
            this.nGroupBoxEx2.HeaderItem.Text = "Administratie";
            this.nGroupBoxEx2.Location = new System.Drawing.Point(28, 285);
            this.nGroupBoxEx2.Name = "nGroupBoxEx2";
            this.nGroupBoxEx2.Size = new System.Drawing.Size(550, 110);
            this.nGroupBoxEx2.TabIndex = 0;
            this.nGroupBoxEx2.TabStop = false;
            // 
            // B_klantbeheer
            // 
            this.B_klantbeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_klantbeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_klantbeheer.Enabled = false;
            this.B_klantbeheer.Image = global::GUI.Properties.Resources.user;
            this.B_klantbeheer.Location = new System.Drawing.Point(30, 29);
            this.B_klantbeheer.Name = "B_klantbeheer";
            this.B_klantbeheer.Size = new System.Drawing.Size(74, 67);
            this.B_klantbeheer.TabIndex = 4;
            this.B_klantbeheer.UseVisualStyleBackColor = false;
            this.B_klantbeheer.MouseLeave += new System.EventHandler(this.nButton_KlantBeheren_MouseLeave);
            this.B_klantbeheer.Click += new System.EventHandler(this.nButton_KlantBeheren_Click);
            this.B_klantbeheer.MouseHover += new System.EventHandler(this.nButton_KlantBeheren_MouseHover);
            // 
            // B_bestellingbeheer
            // 
            this.B_bestellingbeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_bestellingbeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_bestellingbeheer.Enabled = false;
            this.B_bestellingbeheer.Image = global::GUI.Properties.Resources.ADONIA_1_55;
            this.B_bestellingbeheer.Location = new System.Drawing.Point(238, 29);
            this.B_bestellingbeheer.Name = "B_bestellingbeheer";
            this.B_bestellingbeheer.Size = new System.Drawing.Size(74, 67);
            this.B_bestellingbeheer.TabIndex = 5;
            this.B_bestellingbeheer.UseVisualStyleBackColor = false;
            this.B_bestellingbeheer.MouseLeave += new System.EventHandler(this.nButton_BestellingenBeheren_MouseLeave);
            this.B_bestellingbeheer.Click += new System.EventHandler(this.nButton_BestellingenBeheren_Click);
            this.B_bestellingbeheer.MouseHover += new System.EventHandler(this.nButton_BestellingenBeheren_MouseHover);
            // 
            // B_themabeheer
            // 
            this.B_themabeheer.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.B_themabeheer.ButtonProperties.ImageSize = new System.Drawing.Size(64, 64);
            this.B_themabeheer.Enabled = false;
            this.B_themabeheer.Image = global::GUI.Properties.Resources.Project;
            this.B_themabeheer.Location = new System.Drawing.Point(440, 29);
            this.B_themabeheer.Name = "B_themabeheer";
            this.B_themabeheer.Size = new System.Drawing.Size(74, 67);
            this.B_themabeheer.TabIndex = 6;
            this.B_themabeheer.UseVisualStyleBackColor = false;
            this.B_themabeheer.MouseLeave += new System.EventHandler(this.nButton_ThemasBeheren_MouseLeave);
            this.B_themabeheer.Click += new System.EventHandler(this.nButton_ThemasBeheren_Click);
            this.B_themabeheer.MouseHover += new System.EventHandler(this.nButton_ThemasBeheren_MouseHover);
            // 
            // label_statusBar
            // 
            this.label_statusBar.AutoSize = true;
            this.label_statusBar.Location = new System.Drawing.Point(12, 463);
            this.label_statusBar.Name = "label_statusBar";
            this.label_statusBar.Size = new System.Drawing.Size(47, 13);
            this.label_statusBar.TabIndex = 2;
            this.label_statusBar.Text = "Pakketo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(344, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 68);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(9, 118);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(588, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // nTooltip
            // 
            this.nTooltip.Content.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
            this.nTooltip.Content.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip.Content.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip.Content.TreatAsOneEntity = false;
            this.nTooltip.HasRounding = true;
            this.nTooltip.Heading.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
            this.nTooltip.Heading.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip.Heading.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 8.25F, Nevron.GraphicsCore.FontStyleEx.Bold);
            this.nTooltip.Heading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip.Heading.TreatAsOneEntity = false;
            this.nTooltip.HideDelay = 100;
            this.nTooltip.ShowDelay = 100;
            // 
            // label_DatumTijd
            // 
            this.label_DatumTijd.AutoSize = true;
            this.label_DatumTijd.Location = new System.Drawing.Point(491, 463);
            this.label_DatumTijd.Name = "label_DatumTijd";
            this.label_DatumTijd.Size = new System.Drawing.Size(10, 13);
            this.label_DatumTijd.TabIndex = 6;
            this.label_DatumTijd.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingelogd als :";
            // 
            // L_status
            // 
            this.L_status.AutoSize = true;
            this.L_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_status.Location = new System.Drawing.Point(115, 95);
            this.L_status.Name = "L_status";
            this.L_status.Size = new System.Drawing.Size(17, 17);
            this.L_status.TabIndex = 9;
            this.L_status.Text = "_";
            // 
            // UI_hoofd_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 482);
            this.Controls.Add(this.L_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_DatumTijd);
            this.Controls.Add(this.nLineControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_statusBar);
            this.Controls.Add(this.nGroupBoxEx2);
            this.Controls.Add(this.nGroupBoxEx1);
            this.Controls.Add(this.nStatusBar1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(632, 530);
            this.MinimumSize = new System.Drawing.Size(632, 530);
            this.Name = "UI_hoofd_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pakketo - Hoofd Venster";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
            this.nGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).EndInit();
            this.nGroupBoxEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx2;
        private Nevron.UI.WinForm.Controls.NButton B_pakketbeheer;
        private System.Windows.Forms.Label label_statusBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private Nevron.UI.WinForm.Controls.NButton B_klantbeheer;
        private Nevron.UI.WinForm.Controls.NTooltip nTooltip;
        private System.Windows.Forms.Label label_DatumTijd;
        private Nevron.UI.WinForm.Controls.NButton B_productbeheer;
        private Nevron.UI.WinForm.Controls.NButton B_bestellingbeheer;
        private Nevron.UI.WinForm.Controls.NButton B_kleurenbeheer;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool_pakketbeheer;
        private System.Windows.Forms.ToolStripMenuItem tool_productbeheer;
        private System.Windows.Forms.ToolStripMenuItem tool_kleurenbeheer;
        private System.Windows.Forms.ToolStripMenuItem tool_klantbeheer;
        private System.Windows.Forms.ToolStripMenuItem tool_bestellingbeheer;
        private System.Windows.Forms.ToolStripMenuItem tool_themabeheer;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private Nevron.UI.WinForm.Controls.NButton B_themabeheer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_status;












    }
}

