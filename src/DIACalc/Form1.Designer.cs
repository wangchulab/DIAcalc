namespace DIACalc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFasta = new System.Windows.Forms.OpenFileDialog();
            this.open = new System.Windows.Forms.Button();
            this.openfasta = new System.Windows.Forms.Button();
            this.calc = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.target = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "rep";
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialog1";
            // 
            // openFileDialogFasta
            // 
            this.openFileDialogFasta.FileName = "openFileDialog2";
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(82, 66);
            this.open.Margin = new System.Windows.Forms.Padding(2);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(86, 26);
            this.open.TabIndex = 0;
            this.open.Text = "open file";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openfasta
            // 
            this.openfasta.Location = new System.Drawing.Point(212, 66);
            this.openfasta.Margin = new System.Windows.Forms.Padding(2);
            this.openfasta.Name = "openfasta";
            this.openfasta.Size = new System.Drawing.Size(92, 26);
            this.openfasta.TabIndex = 1;
            this.openfasta.Text = "open fasta";
            this.openfasta.UseVisualStyleBackColor = true;
            this.openfasta.Click += new System.EventHandler(this.openfasta_Click);
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(212, 182);
            this.calc.Margin = new System.Windows.Forms.Padding(2);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(88, 30);
            this.calc.TabIndex = 2;
            this.calc.Text = "calc";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(340, 66);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 26);
            this.save.TabIndex = 3;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // target
            // 
            this.target.Location = new System.Drawing.Point(252, 133);
            this.target.Margin = new System.Windows.Forms.Padding(2);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(68, 21);
            this.target.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "target";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 240);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 22);
            this.progressBar1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 300);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.target);
            this.Controls.Add(this.save);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.openfasta);
            this.Controls.Add(this.open);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "DIAcalc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.OpenFileDialog openFileDialogFasta;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button openfasta;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox target;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

