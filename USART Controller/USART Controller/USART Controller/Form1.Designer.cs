namespace USART_Controller
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCoef = new System.Windows.Forms.TextBox();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.lblErr = new System.Windows.Forms.Label();
            this.chbY = new System.Windows.Forms.CheckBox();
            this.chbX = new System.Windows.Forms.CheckBox();
            this.btnMAF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 6);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 37);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 23);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(114, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(512, 22);
            this.textBox3.TabIndex = 21;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(114, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add to equation";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCoef
            // 
            this.txtCoef.Location = new System.Drawing.Point(204, 12);
            this.txtCoef.Name = "txtCoef";
            this.txtCoef.Size = new System.Drawing.Size(100, 22);
            this.txtCoef.TabIndex = 23;
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(457, 12);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(100, 22);
            this.txtExp.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Coefficient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Exponent";
            // 
            // btnClr
            // 
            this.btnClr.Location = new System.Drawing.Point(114, 134);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(71, 23);
            this.btnClr.TabIndex = 27;
            this.btnClr.Text = "Clear";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(191, 134);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(71, 23);
            this.btnSet.TabIndex = 28;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(454, 41);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 17);
            this.lblErr.TabIndex = 29;
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Location = new System.Drawing.Point(333, 12);
            this.chbY.Name = "chbY";
            this.chbY.Size = new System.Drawing.Size(39, 21);
            this.chbY.TabIndex = 31;
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            this.chbY.CheckedChanged += new System.EventHandler(this.chbY_CheckedChanged);
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Location = new System.Drawing.Point(333, 39);
            this.chbX.Name = "chbX";
            this.chbX.Size = new System.Drawing.Size(39, 21);
            this.chbX.TabIndex = 32;
            this.chbX.Text = "X";
            this.chbX.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chbX.UseVisualStyleBackColor = true;
            this.chbX.CheckedChanged += new System.EventHandler(this.chbX_CheckedChanged);
            // 
            // btnMAF
            // 
            this.btnMAF.Location = new System.Drawing.Point(574, 134);
            this.btnMAF.Name = "btnMAF";
            this.btnMAF.Size = new System.Drawing.Size(52, 23);
            this.btnMAF.TabIndex = 33;
            this.btnMAF.Text = "MAF";
            this.btnMAF.UseVisualStyleBackColor = true;
            this.btnMAF.Click += new System.EventHandler(this.btnMAF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 178);
            this.Controls.Add(this.btnMAF);
            this.Controls.Add(this.chbX);
            this.Controls.Add(this.chbY);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExp);
            this.Controls.Add(this.txtCoef);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "USART Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCoef;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbX;
        private System.Windows.Forms.Button btnMAF;
    }
}

