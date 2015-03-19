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
    partial class UI_login_scherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_login_scherm));
            this.button_OK = new Nevron.UI.WinForm.Controls.NButton();
            this.label_Close = new System.Windows.Forms.LinkLabel();
            this.textbox_gebNaam = new Nevron.UI.WinForm.Controls.NEntryBox();
            this.textbox_wachtwoord = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label_wachtwoord = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.nTooltip1 = new Nevron.UI.WinForm.Controls.NTooltip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_gebNaam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_wachtwoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(192, 211);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_Close
            // 
            this.label_Close.AccessibleDescription = "";
            this.label_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Close.AutoSize = true;
            this.label_Close.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Close.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Close.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.label_Close.LinkColor = System.Drawing.Color.DimGray;
            this.label_Close.Location = new System.Drawing.Point(271, 14);
            this.label_Close.Name = "label_Close";
            this.label_Close.Size = new System.Drawing.Size(15, 18);
            this.label_Close.TabIndex = 4;
            this.label_Close.TabStop = true;
            this.label_Close.Text = "X";
            this.label_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Close_MouseClick);
            this.label_Close.MouseHover += new System.EventHandler(this.label_Close_MouseHover);
            // 
            // textbox_gebNaam
            // 
            this.textbox_gebNaam.BackColor = System.Drawing.Color.Transparent;
            this.textbox_gebNaam.ClientPadding = new Nevron.UI.NPadding(2);
            // 
            // 
            // 
            this.textbox_gebNaam.EditControl.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.textbox_gebNaam.EditControl.Location = new System.Drawing.Point(95, 3);
            this.textbox_gebNaam.EditControl.Name = "";
            this.textbox_gebNaam.EditControl.Size = new System.Drawing.Size(141, 17);
            this.textbox_gebNaam.EditControl.TabIndex = 0;
            this.textbox_gebNaam.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_gebNaam.Interactive = false;
            this.textbox_gebNaam.Location = new System.Drawing.Point(27, 131);
            this.textbox_gebNaam.Name = "textbox_gebNaam";
            this.textbox_gebNaam.Size = new System.Drawing.Size(244, 34);
            this.textbox_gebNaam.TabIndex = 1;
            this.textbox_gebNaam.Text = "Gebruikersnaam :";
            this.textbox_gebNaam.TooltipText = "Vul uw gebruikersnaam in";
            this.textbox_gebNaam.TextChanged += new System.EventHandler(this.textbox_gebNaam_TextChanged);
            // 
            // textbox_wachtwoord
            // 
            this.textbox_wachtwoord.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.textbox_wachtwoord.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_wachtwoord.Location = new System.Drawing.Point(123, 174);
            this.textbox_wachtwoord.Name = "textbox_wachtwoord";
            this.textbox_wachtwoord.PasswordChar = '●';
            this.textbox_wachtwoord.Size = new System.Drawing.Size(142, 17);
            this.textbox_wachtwoord.TabIndex = 2;
            this.textbox_wachtwoord.UseSystemPasswordChar = true;
            this.textbox_wachtwoord.TextChanged += new System.EventHandler(this.textbox_wachtwoord_TextChanged);
            this.textbox_wachtwoord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_wachtwoord_KeyDown);
            // 
            // label_wachtwoord
            // 
            this.label_wachtwoord.BackColor = System.Drawing.Color.Transparent;
            this.label_wachtwoord.ClientPadding = new Nevron.UI.NPadding(3, 0, 0, 0);
            this.label_wachtwoord.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_wachtwoord.Location = new System.Drawing.Point(27, 171);
            this.label_wachtwoord.Name = "label_wachtwoord";
            this.label_wachtwoord.Size = new System.Drawing.Size(244, 34);
            this.label_wachtwoord.TabIndex = 6;
            this.label_wachtwoord.TabStop = false;
            this.label_wachtwoord.Text = "Wachtwoord :";
            this.label_wachtwoord.MouseHover += new System.EventHandler(this.label_wachtwoord_MouseHover);
            // 
            // nTooltip1
            // 
            this.nTooltip1.Content.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
            this.nTooltip1.Content.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip1.Content.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip1.Content.TreatAsOneEntity = false;
            this.nTooltip1.Heading.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
            this.nTooltip1.Heading.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip1.Heading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.nTooltip1.Heading.TreatAsOneEntity = false;
            this.nTooltip1.HideDelay = 100;
            this.nTooltip1.ShowDelay = 700;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(69, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(24, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Login_Scherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::GUI.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textbox_wachtwoord);
            this.Controls.Add(this.label_wachtwoord);
            this.Controls.Add(this.textbox_gebNaam);
            this.Controls.Add(this.label_Close);
            this.Controls.Add(this.button_OK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Login_Scherm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Scherm";
            ((System.ComponentModel.ISupportInitialize)(this.textbox_gebNaam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_wachtwoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton button_OK;
        private System.Windows.Forms.LinkLabel label_Close;
        private Nevron.UI.WinForm.Controls.NEntryBox textbox_gebNaam;
        private Nevron.UI.WinForm.Controls.NTextBox textbox_wachtwoord;
        private Nevron.UI.WinForm.Controls.NRichTextLabel label_wachtwoord;
        private Nevron.UI.WinForm.Controls.NTooltip nTooltip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

