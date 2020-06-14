namespace PoolProblem
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
            this.dugum_sayisi = new System.Windows.Forms.Label();
            this.dugumekle_button = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dugum_sayisi
            // 
            this.dugum_sayisi.AutoSize = true;
            this.dugum_sayisi.Font = new System.Drawing.Font("Vivaldi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dugum_sayisi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dugum_sayisi.Location = new System.Drawing.Point(29, 24);
            this.dugum_sayisi.Name = "dugum_sayisi";
            this.dugum_sayisi.Size = new System.Drawing.Size(84, 14);
            this.dugum_sayisi.TabIndex = 0;
            this.dugum_sayisi.Text = "Düğüm Sayısı:";
            this.dugum_sayisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dugumekle_button
            // 
            this.dugumekle_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dugumekle_button.Location = new System.Drawing.Point(226, 22);
            this.dugumekle_button.Name = "dugumekle_button";
            this.dugumekle_button.Size = new System.Drawing.Size(75, 20);
            this.dugumekle_button.TabIndex = 2;
            this.dugumekle_button.Text = "Ekle";
            this.dugumekle_button.UseVisualStyleBackColor = true;
            this.dugumekle_button.Click += new System.EventHandler(this.dugumekle_button_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(119, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dugumekle_button);
            this.Controls.Add(this.dugum_sayisi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dugum_sayisi;
        private System.Windows.Forms.Button dugumekle_button;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

