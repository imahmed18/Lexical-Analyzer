
namespace TOA_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browse_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.analyze_Btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // browse_Btn
            // 
            this.browse_Btn.Location = new System.Drawing.Point(613, 154);
            this.browse_Btn.Name = "browse_Btn";
            this.browse_Btn.Size = new System.Drawing.Size(105, 36);
            this.browse_Btn.TabIndex = 0;
            this.browse_Btn.Text = "Browse";
            this.browse_Btn.UseVisualStyleBackColor = true;
            this.browse_Btn.Click += new System.EventHandler(this.browse_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(245, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "C# Lexical Analyzer";
            // 
            // analyze_Btn
            // 
            this.analyze_Btn.Location = new System.Drawing.Point(613, 273);
            this.analyze_Btn.Name = "analyze_Btn";
            this.analyze_Btn.Size = new System.Drawing.Size(105, 39);
            this.analyze_Btn.TabIndex = 3;
            this.analyze_Btn.Text = "Analyze";
            this.analyze_Btn.UseVisualStyleBackColor = true;
            this.analyze_Btn.Click += new System.EventHandler(this.analyze_Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(511, 334);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.analyze_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browse_Btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button analyze_Btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

