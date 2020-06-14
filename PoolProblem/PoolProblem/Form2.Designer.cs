namespace PoolProblem
{
    partial class Form2
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
            this.maxflowbtn = new System.Windows.Forms.Button();
            this.mincutbtn = new System.Windows.Forms.Button();
            this.maxflowvalue = new System.Windows.Forms.Label();
            this.mincutvalue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maxflowbtn
            // 
            this.maxflowbtn.Location = new System.Drawing.Point(12, 12);
            this.maxflowbtn.Name = "maxflowbtn";
            this.maxflowbtn.Size = new System.Drawing.Size(114, 23);
            this.maxflowbtn.TabIndex = 0;
            this.maxflowbtn.Text = "MaxFlow Hesapla";
            this.maxflowbtn.UseVisualStyleBackColor = true;
            this.maxflowbtn.Click += new System.EventHandler(this.maxflowbtn_Click);
            // 
            // mincutbtn
            // 
            this.mincutbtn.Location = new System.Drawing.Point(12, 55);
            this.mincutbtn.Name = "mincutbtn";
            this.mincutbtn.Size = new System.Drawing.Size(114, 23);
            this.mincutbtn.TabIndex = 1;
            this.mincutbtn.Text = "MinCut Hesapla";
            this.mincutbtn.UseVisualStyleBackColor = true;
            this.mincutbtn.Click += new System.EventHandler(this.mincutbtn_Click);
            // 
            // maxflowvalue
            // 
            this.maxflowvalue.AutoSize = true;
            this.maxflowvalue.Location = new System.Drawing.Point(145, 17);
            this.maxflowvalue.Name = "maxflowvalue";
            this.maxflowvalue.Size = new System.Drawing.Size(0, 13);
            this.maxflowvalue.TabIndex = 2;
            // 
            // mincutvalue
            // 
            this.mincutvalue.AutoSize = true;
            this.mincutvalue.Location = new System.Drawing.Point(145, 60);
            this.mincutvalue.Name = "mincutvalue";
            this.mincutvalue.Size = new System.Drawing.Size(0, 13);
            this.mincutvalue.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mincutvalue);
            this.Controls.Add(this.maxflowvalue);
            this.Controls.Add(this.mincutbtn);
            this.Controls.Add(this.maxflowbtn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGraph);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button maxflowbtn;
        private System.Windows.Forms.Button mincutbtn;
        private System.Windows.Forms.Label maxflowvalue;
        private System.Windows.Forms.Label mincutvalue;
    }
}