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
namespace UMP_Client
{
    partial class Services
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
            this.list_oldPlugins = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.list_newPlugins = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.group_installedPlugins = new System.Windows.Forms.GroupBox();
            this.group_newPlugins = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.B_remove = new System.Windows.Forms.Button();
            this.T_inst_description = new System.Windows.Forms.TextBox();
            this.T_new_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.B_install = new System.Windows.Forms.Button();
            this.B_refresh = new System.Windows.Forms.Button();
            this.group_installedPlugins.SuspendLayout();
            this.group_newPlugins.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_oldPlugins
            // 
            this.list_oldPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.list_oldPlugins.FullRowSelect = true;
            this.list_oldPlugins.Location = new System.Drawing.Point(6, 19);
            this.list_oldPlugins.MultiSelect = false;
            this.list_oldPlugins.Name = "list_oldPlugins";
            this.list_oldPlugins.Size = new System.Drawing.Size(514, 158);
            this.list_oldPlugins.TabIndex = 0;
            this.list_oldPlugins.UseCompatibleStateImageBehavior = false;
            this.list_oldPlugins.View = System.Windows.Forms.View.Details;
            this.list_oldPlugins.SelectedIndexChanged += new System.EventHandler(this.list_oldPlugins_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 204;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 220;
            // 
            // list_newPlugins
            // 
            this.list_newPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.list_newPlugins.FullRowSelect = true;
            this.list_newPlugins.Location = new System.Drawing.Point(6, 19);
            this.list_newPlugins.MultiSelect = false;
            this.list_newPlugins.Name = "list_newPlugins";
            this.list_newPlugins.Size = new System.Drawing.Size(514, 158);
            this.list_newPlugins.TabIndex = 1;
            this.list_newPlugins.UseCompatibleStateImageBehavior = false;
            this.list_newPlugins.View = System.Windows.Forms.View.Details;
            this.list_newPlugins.SelectedIndexChanged += new System.EventHandler(this.list_newPlugins_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 207;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 221;
            // 
            // group_installedPlugins
            // 
            this.group_installedPlugins.Controls.Add(this.B_remove);
            this.group_installedPlugins.Controls.Add(this.T_inst_description);
            this.group_installedPlugins.Controls.Add(this.label1);
            this.group_installedPlugins.Controls.Add(this.list_oldPlugins);
            this.group_installedPlugins.Location = new System.Drawing.Point(12, 12);
            this.group_installedPlugins.Name = "group_installedPlugins";
            this.group_installedPlugins.Size = new System.Drawing.Size(626, 263);
            this.group_installedPlugins.TabIndex = 2;
            this.group_installedPlugins.TabStop = false;
            this.group_installedPlugins.Text = "Installed Plugins";
            // 
            // group_newPlugins
            // 
            this.group_newPlugins.Controls.Add(this.B_refresh);
            this.group_newPlugins.Controls.Add(this.B_install);
            this.group_newPlugins.Controls.Add(this.T_new_description);
            this.group_newPlugins.Controls.Add(this.label2);
            this.group_newPlugins.Controls.Add(this.list_newPlugins);
            this.group_newPlugins.Location = new System.Drawing.Point(12, 282);
            this.group_newPlugins.Name = "group_newPlugins";
            this.group_newPlugins.Size = new System.Drawing.Size(626, 263);
            this.group_newPlugins.TabIndex = 3;
            this.group_newPlugins.TabStop = false;
            this.group_newPlugins.Text = "New Plugins";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.L_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(652, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Status : ";
            // 
            // L_status
            // 
            this.L_status.Name = "L_status";
            this.L_status.Size = new System.Drawing.Size(46, 17);
            this.L_status.Text = "standby";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description :";
            // 
            // B_remove
            // 
            this.B_remove.Location = new System.Drawing.Point(526, 84);
            this.B_remove.Name = "B_remove";
            this.B_remove.Size = new System.Drawing.Size(75, 23);
            this.B_remove.TabIndex = 5;
            this.B_remove.Text = "Remove";
            this.B_remove.UseVisualStyleBackColor = true;
            this.B_remove.Click += new System.EventHandler(this.B_remove_Click);
            // 
            // T_inst_description
            // 
            this.T_inst_description.Location = new System.Drawing.Point(78, 183);
            this.T_inst_description.Multiline = true;
            this.T_inst_description.Name = "T_inst_description";
            this.T_inst_description.ReadOnly = true;
            this.T_inst_description.Size = new System.Drawing.Size(523, 74);
            this.T_inst_description.TabIndex = 2;
            // 
            // T_new_description
            // 
            this.T_new_description.Location = new System.Drawing.Point(82, 183);
            this.T_new_description.Multiline = true;
            this.T_new_description.Name = "T_new_description";
            this.T_new_description.ReadOnly = true;
            this.T_new_description.Size = new System.Drawing.Size(519, 74);
            this.T_new_description.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description :";
            // 
            // B_install
            // 
            this.B_install.Location = new System.Drawing.Point(526, 87);
            this.B_install.Name = "B_install";
            this.B_install.Size = new System.Drawing.Size(75, 23);
            this.B_install.TabIndex = 6;
            this.B_install.Text = "Install";
            this.B_install.UseVisualStyleBackColor = true;
            this.B_install.Click += new System.EventHandler(this.B_install_Click);
            // 
            // B_refresh
            // 
            this.B_refresh.Location = new System.Drawing.Point(526, 19);
            this.B_refresh.Name = "B_refresh";
            this.B_refresh.Size = new System.Drawing.Size(75, 23);
            this.B_refresh.TabIndex = 7;
            this.B_refresh.Text = "Refresh";
            this.B_refresh.UseVisualStyleBackColor = true;
            this.B_refresh.Click += new System.EventHandler(this.B_refresh_Click);
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 574);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.group_newPlugins);
            this.Controls.Add(this.group_installedPlugins);
            this.Name = "Services";
            this.ShowIcon = false;
            this.Text = "Services";
            this.group_installedPlugins.ResumeLayout(false);
            this.group_installedPlugins.PerformLayout();
            this.group_newPlugins.ResumeLayout(false);
            this.group_newPlugins.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_oldPlugins;
        private System.Windows.Forms.ListView list_newPlugins;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox group_installedPlugins;
        private System.Windows.Forms.GroupBox group_newPlugins;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel L_status;
        private System.Windows.Forms.Button B_remove;
        private System.Windows.Forms.TextBox T_inst_description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_install;
        private System.Windows.Forms.TextBox T_new_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_refresh;
    }
}
