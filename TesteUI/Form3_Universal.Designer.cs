namespace TesteUI
{
    partial class Form3_Universal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button_parar_vertical = new System.Windows.Forms.Button();
            this.btnEnergizarVertical = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDireicaoVerticalCima = new System.Windows.Forms.RadioButton();
            this.btnLigarVertical = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDirecaoVerticalBaixo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_Arduino2 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 577);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.richTextBox3);
            this.panel2.Controls.Add(this.button_parar_vertical);
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
            this.panel2.Location = new System.Drawing.Point(3, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 515);
            this.panel2.TabIndex = 27;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(296, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Constante Motor 2";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox3.BackColor = System.Drawing.Color.White;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(273, 45);
            this.richTextBox3.Multiline = false;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox3.Size = new System.Drawing.Size(212, 34);
            this.richTextBox3.TabIndex = 30;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // button_parar_vertical
            // 
            this.button_parar_vertical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_parar_vertical.BackColor = System.Drawing.Color.Red;
            this.button_parar_vertical.Cursor = System.Windows.Forms.Cursors.No;
            this.button_parar_vertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_parar_vertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_parar_vertical.Location = new System.Drawing.Point(147, 440);
            this.button_parar_vertical.Name = "button_parar_vertical";
            this.button_parar_vertical.Size = new System.Drawing.Size(198, 61);
            this.button_parar_vertical.TabIndex = 29;
            this.button_parar_vertical.Text = "Parar";
            this.button_parar_vertical.UseVisualStyleBackColor = false;
            this.button_parar_vertical.Click += new System.EventHandler(this.button_parar_vertical_Click);
            // 
            // btnEnergizarVertical
            // 
            this.btnEnergizarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEnergizarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnergizarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnergizarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnergizarVertical.Location = new System.Drawing.Point(147, 310);
            this.btnEnergizarVertical.Name = "btnEnergizarVertical";
            this.btnEnergizarVertical.Size = new System.Drawing.Size(198, 60);
            this.btnEnergizarVertical.TabIndex = 24;
            this.btnEnergizarVertical.Text = "Desenergizado";
            this.btnEnergizarVertical.UseVisualStyleBackColor = false;
            this.btnEnergizarVertical.Click += new System.EventHandler(this.btnEnergizarVertical_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Constante Motor 1";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox4.BackColor = System.Drawing.Color.White;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.Location = new System.Drawing.Point(26, 45);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox4.Size = new System.Drawing.Size(212, 34);
            this.richTextBox4.TabIndex = 19;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Distância (mm):";
            // 
            // btnDireicaoVerticalCima
            // 
            this.btnDireicaoVerticalCima.AutoSize = true;
            this.btnDireicaoVerticalCima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDireicaoVerticalCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireicaoVerticalCima.Location = new System.Drawing.Point(147, 270);
            this.btnDireicaoVerticalCima.Name = "btnDireicaoVerticalCima";
            this.btnDireicaoVerticalCima.Size = new System.Drawing.Size(79, 29);
            this.btnDireicaoVerticalCima.TabIndex = 22;
            this.btnDireicaoVerticalCima.Text = "Cima";
            this.btnDireicaoVerticalCima.UseVisualStyleBackColor = true;
            this.btnDireicaoVerticalCima.CheckedChanged += new System.EventHandler(this.btnDireicaoVerticalCima_CheckedChanged);
            // 
            // btnLigarVertical
            // 
            this.btnLigarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarVertical.Location = new System.Drawing.Point(147, 381);
            this.btnLigarVertical.Name = "btnLigarVertical";
            this.btnLigarVertical.Size = new System.Drawing.Size(198, 54);
            this.btnLigarVertical.TabIndex = 25;
            this.btnLigarVertical.Text = "Ligar";
            this.btnLigarVertical.UseVisualStyleBackColor = false;
            this.btnLigarVertical.Click += new System.EventHandler(this.btnLigarVertical_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(141, 132);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(212, 34);
            this.richTextBox2.TabIndex = 20;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Velocidade (mm/s):";
            // 
            // btnDirecaoVerticalBaixo
            // 
            this.btnDirecaoVerticalBaixo.AutoSize = true;
            this.btnDirecaoVerticalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoVerticalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoVerticalBaixo.Location = new System.Drawing.Point(270, 270);
            this.btnDirecaoVerticalBaixo.Name = "btnDirecaoVerticalBaixo";
            this.btnDirecaoVerticalBaixo.Size = new System.Drawing.Size(82, 29);
            this.btnDirecaoVerticalBaixo.TabIndex = 23;
            this.btnDirecaoVerticalBaixo.Text = "Baixo";
            this.btnDirecaoVerticalBaixo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Direção de movimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(140, 197);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(212, 34);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label4.Location = new System.Drawing.Point(138, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 39);
            this.label4.TabIndex = 26;
            this.label4.Text = "Motor Universal";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // richTextBox_Arduino2
            // 
            this.richTextBox_Arduino2.Cursor = System.Windows.Forms.Cursors.Help;
            this.richTextBox_Arduino2.Location = new System.Drawing.Point(12, 595);
            this.richTextBox_Arduino2.Name = "richTextBox_Arduino2";
            this.richTextBox_Arduino2.Size = new System.Drawing.Size(532, 53);
            this.richTextBox_Arduino2.TabIndex = 31;
            this.richTextBox_Arduino2.Text = "";
            // 
            // Form3_Universal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 655);
            this.Controls.Add(this.richTextBox_Arduino2);
            this.Controls.Add(this.panel1);
            this.Name = "Form3_Universal";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form3_Universal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_parar_vertical;
        private System.Windows.Forms.Button btnEnergizarVertical;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton btnDireicaoVerticalCima;
        private System.Windows.Forms.Button btnLigarVertical;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton btnDirecaoVerticalBaixo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_Arduino2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox3;
    }
}