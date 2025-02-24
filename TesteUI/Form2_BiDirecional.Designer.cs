namespace TesteUI
{
    partial class Form2_BiDirecional
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnDirecaoVerticalBaixo = new System.Windows.Forms.RadioButton();
            this.btnDireicaoVerticalCima = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnergizarVertical = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.btnLigarVertical = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox_Arduino = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Distância (mm):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Velocidade (mm/s):";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 108);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(212, 34);
            this.richTextBox2.TabIndex = 20;
            this.richTextBox2.Text = "";
            // 
            // btnDirecaoVerticalBaixo
            // 
            this.btnDirecaoVerticalBaixo.AutoSize = true;
            this.btnDirecaoVerticalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoVerticalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoVerticalBaixo.Location = new System.Drawing.Point(134, 261);
            this.btnDirecaoVerticalBaixo.Name = "btnDirecaoVerticalBaixo";
            this.btnDirecaoVerticalBaixo.Size = new System.Drawing.Size(82, 29);
            this.btnDirecaoVerticalBaixo.TabIndex = 25;
            this.btnDirecaoVerticalBaixo.Text = "Baixo";
            this.btnDirecaoVerticalBaixo.UseVisualStyleBackColor = true;
            // 
            // btnDireicaoVerticalCima
            // 
            this.btnDireicaoVerticalCima.AutoSize = true;
            this.btnDireicaoVerticalCima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDireicaoVerticalCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireicaoVerticalCima.Location = new System.Drawing.Point(27, 261);
            this.btnDireicaoVerticalCima.Name = "btnDireicaoVerticalCima";
            this.btnDireicaoVerticalCima.Size = new System.Drawing.Size(79, 29);
            this.btnDireicaoVerticalCima.TabIndex = 24;
            this.btnDireicaoVerticalCima.Text = "Cima";
            this.btnDireicaoVerticalCima.UseVisualStyleBackColor = true;
            this.btnDireicaoVerticalCima.CheckedChanged += new System.EventHandler(this.btnDireicaoVerticalCima_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Direção de movimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(34, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 496);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEnergizarVertical);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.richTextBox4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDireicaoVerticalCima);
            this.panel2.Controls.Add(this.btnLigarVertical);
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnDirecaoVerticalBaixo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(4, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 434);
            this.panel2.TabIndex = 27;
            // 
            // btnEnergizarVertical
            // 
            this.btnEnergizarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEnergizarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnergizarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnergizarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnergizarVertical.Location = new System.Drawing.Point(18, 296);
            this.btnEnergizarVertical.Name = "btnEnergizarVertical";
            this.btnEnergizarVertical.Size = new System.Drawing.Size(198, 60);
            this.btnEnergizarVertical.TabIndex = 29;
            this.btnEnergizarVertical.Text = "Desenergizado";
            this.btnEnergizarVertical.UseVisualStyleBackColor = false;
            this.btnEnergizarVertical.Click += new System.EventHandler(this.btnEnergizarVertical_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Constante de Calibração:";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox4.BackColor = System.Drawing.Color.White;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.Location = new System.Drawing.Point(12, 41);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox4.Size = new System.Drawing.Size(210, 34);
            this.richTextBox4.TabIndex = 27;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // btnLigarVertical
            // 
            this.btnLigarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarVertical.Location = new System.Drawing.Point(18, 369);
            this.btnLigarVertical.Name = "btnLigarVertical";
            this.btnLigarVertical.Size = new System.Drawing.Size(198, 54);
            this.btnLigarVertical.TabIndex = 27;
            this.btnLigarVertical.Text = "Ligar";
            this.btnLigarVertical.UseVisualStyleBackColor = false;
            this.btnLigarVertical.Click += new System.EventHandler(this.btnLigarVertical_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 186);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(212, 34);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 26;
            this.label4.Text = "Vertical";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(355, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 29);
            this.label8.TabIndex = 26;
            this.label8.Text = "Horizontal";
            // 
            // richTextBox_Arduino
            // 
            this.richTextBox_Arduino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Arduino.Cursor = System.Windows.Forms.Cursors.Help;
            this.richTextBox_Arduino.Location = new System.Drawing.Point(297, 158);
            this.richTextBox_Arduino.Name = "richTextBox_Arduino";
            this.richTextBox_Arduino.Size = new System.Drawing.Size(240, 96);
            this.richTextBox_Arduino.TabIndex = 30;
            this.richTextBox_Arduino.Text = "";
            // 
            // Form2_BiDirecional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 541);
            this.Controls.Add(this.richTextBox_Arduino);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form2_BiDirecional";
            this.Text = "Form2_BiDirecional";
            this.Load += new System.EventHandler(this.Form2_BiDirecional_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton btnDirecaoVerticalBaixo;
        private System.Windows.Forms.RadioButton btnDireicaoVerticalCima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLigarVertical;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnergizarVertical;
        private System.Windows.Forms.RichTextBox richTextBox_Arduino;
    }
}