namespace Woorden_teller
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
            this.T_input = new System.Windows.Forms.TextBox();
            this.T_output = new System.Windows.Forms.TextBox();
            this.btn_convert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // T_input
            // 
            this.T_input.Location = new System.Drawing.Point(12, 12);
            this.T_input.Multiline = true;
            this.T_input.Name = "T_input";
            this.T_input.Size = new System.Drawing.Size(505, 161);
            this.T_input.TabIndex = 0;
            // 
            // T_output
            // 
            this.T_output.Location = new System.Drawing.Point(12, 213);
            this.T_output.Multiline = true;
            this.T_output.Name = "T_output";
            this.T_output.Size = new System.Drawing.Size(505, 161);
            this.T_output.TabIndex = 1;
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(224, 184);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(75, 23);
            this.btn_convert.TabIndex = 2;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 387);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.T_output);
            this.Controls.Add(this.T_input);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woorden Teller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_input;
        private System.Windows.Forms.TextBox T_output;
        private System.Windows.Forms.Button btn_convert;
    }
}

