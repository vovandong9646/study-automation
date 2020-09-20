namespace AutoPC
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
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMouse = new System.Windows.Forms.CheckBox();
            this.btnClickTheoToaDo = new System.Windows.Forms.Button();
            this.btnClickTheoViTriHandle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(70, 32);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 0;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(70, 6);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Toạ độ X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Toạ độ Y";
            // 
            // chkMouse
            // 
            this.chkMouse.AutoSize = true;
            this.chkMouse.Location = new System.Drawing.Point(15, 63);
            this.chkMouse.Name = "chkMouse";
            this.chkMouse.Size = new System.Drawing.Size(102, 17);
            this.chkMouse.TabIndex = 4;
            this.chkMouse.Text = "Click chuột phải";
            this.chkMouse.UseVisualStyleBackColor = true;
            // 
            // btnClickTheoToaDo
            // 
            this.btnClickTheoToaDo.Location = new System.Drawing.Point(15, 87);
            this.btnClickTheoToaDo.Name = "btnClickTheoToaDo";
            this.btnClickTheoToaDo.Size = new System.Drawing.Size(122, 23);
            this.btnClickTheoToaDo.TabIndex = 5;
            this.btnClickTheoToaDo.Text = "Click Theo Toạ Độ";
            this.btnClickTheoToaDo.UseVisualStyleBackColor = true;
            this.btnClickTheoToaDo.Click += new System.EventHandler(this.btnClickTheoToaDo_Click);
            // 
            // btnClickTheoViTriHandle
            // 
            this.btnClickTheoViTriHandle.Location = new System.Drawing.Point(15, 126);
            this.btnClickTheoViTriHandle.Name = "btnClickTheoViTriHandle";
            this.btnClickTheoViTriHandle.Size = new System.Drawing.Size(155, 20);
            this.btnClickTheoViTriHandle.TabIndex = 6;
            this.btnClickTheoViTriHandle.Text = "Click theo vị trí handle";
            this.btnClickTheoViTriHandle.UseVisualStyleBackColor = true;
            this.btnClickTheoViTriHandle.Click += new System.EventHandler(this.btnClickTheoViTriHandle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Click không chiếm chuột";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 244);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClickTheoViTriHandle);
            this.Controls.Add(this.btnClickTheoToaDo);
            this.Controls.Add(this.chkMouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtY);
            this.Name = "Form1";
            this.Text = "form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.MaskedTextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMouse;
        private System.Windows.Forms.Button btnClickTheoToaDo;
        private System.Windows.Forms.Button btnClickTheoViTriHandle;
        private System.Windows.Forms.Button button1;
    }
}

