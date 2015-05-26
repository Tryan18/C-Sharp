namespace Memory2015
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
            this.btn_start = new System.Windows.Forms.Button();
            this.gb_speeldveld = new System.Windows.Forms.GroupBox();
            this.num_matrixIndex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_matrixIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Location = new System.Drawing.Point(694, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // gb_speeldveld
            // 
            this.gb_speeldveld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_speeldveld.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gb_speeldveld.Location = new System.Drawing.Point(12, 12);
            this.gb_speeldveld.Name = "gb_speeldveld";
            this.gb_speeldveld.Size = new System.Drawing.Size(676, 603);
            this.gb_speeldveld.TabIndex = 1;
            this.gb_speeldveld.TabStop = false;
            this.gb_speeldveld.Text = "Speelveld";
            // 
            // num_matrixIndex
            // 
            this.num_matrixIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_matrixIndex.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_matrixIndex.Location = new System.Drawing.Point(724, 85);
            this.num_matrixIndex.Name = "num_matrixIndex";
            this.num_matrixIndex.Size = new System.Drawing.Size(44, 20);
            this.num_matrixIndex.TabIndex = 2;
            this.num_matrixIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_matrixIndex.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Matrix Index";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 627);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_matrixIndex);
            this.Controls.Add(this.gb_speeldveld);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory 2015";
            ((System.ComponentModel.ISupportInitialize)(this.num_matrixIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.GroupBox gb_speeldveld;
        private System.Windows.Forms.NumericUpDown num_matrixIndex;
        private System.Windows.Forms.Label label1;
    }
}

