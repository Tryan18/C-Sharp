namespace MultipleTechniques
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
            this.button_input = new System.Windows.Forms.Button();
            this.label_output = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_input2 = new System.Windows.Forms.Button();
            this.label_output2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(33, 31);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(75, 23);
            this.button_input.TabIndex = 0;
            this.button_input.Text = "Input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // label_output
            // 
            this.label_output.AutoSize = true;
            this.label_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_output.Location = new System.Drawing.Point(30, 84);
            this.label_output.Name = "label_output";
            this.label_output.Size = new System.Drawing.Size(206, 67);
            this.label_output.TabIndex = 1;
            this.label_output.Text = "Output";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 319);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 272);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button_input2
            // 
            this.button_input2.Location = new System.Drawing.Point(308, 31);
            this.button_input2.Name = "button_input2";
            this.button_input2.Size = new System.Drawing.Size(75, 23);
            this.button_input2.TabIndex = 3;
            this.button_input2.Text = "button1";
            this.button_input2.UseVisualStyleBackColor = true;
            this.button_input2.Click += new System.EventHandler(this.button_input2_Click);
            // 
            // label_output2
            // 
            this.label_output2.AutoSize = true;
            this.label_output2.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_output2.Location = new System.Drawing.Point(30, 206);
            this.label_output2.Name = "label_output2";
            this.label_output2.Size = new System.Drawing.Size(206, 67);
            this.label_output2.TabIndex = 4;
            this.label_output2.Text = "Output";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 603);
            this.Controls.Add(this.label_output2);
            this.Controls.Add(this.button_input2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_output);
            this.Controls.Add(this.button_input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Label label_output;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_input2;
        private System.Windows.Forms.Label label_output2;
    }
}

