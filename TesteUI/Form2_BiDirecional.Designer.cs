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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnDirecaoVerticalBaixo = new System.Windows.Forms.RadioButton();
            this.btnDireicaoVerticalCima = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_parar_vertical = new System.Windows.Forms.Button();
            this.btnEnergizarVertical = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.btnLigarVertical = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_Arduino = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_parar_horizontal = new System.Windows.Forms.Button();
            this.btnEnergizarHorizontal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDireicaoHorizontallCima = new System.Windows.Forms.RadioButton();
            this.btnLigarHorizontal = new System.Windows.Forms.Button();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDirecaoHorizontalBaixo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBox_Arduino2 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Distância (mm):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Velocidade (mm/s):";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 116);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(212, 34);
            this.richTextBox2.TabIndex = 20;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // btnDirecaoVerticalBaixo
            // 
            this.btnDirecaoVerticalBaixo.AutoSize = true;
            this.btnDirecaoVerticalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoVerticalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoVerticalBaixo.Location = new System.Drawing.Point(134, 261);
            this.btnDirecaoVerticalBaixo.Name = "btnDirecaoVerticalBaixo";
            this.btnDirecaoVerticalBaixo.Size = new System.Drawing.Size(82, 29);
            this.btnDirecaoVerticalBaixo.TabIndex = 23;
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
            this.btnDireicaoVerticalCima.TabIndex = 22;
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
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 577);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel2.Size = new System.Drawing.Size(234, 515);
            this.panel2.TabIndex = 27;
            // 
            // button_parar_vertical
            // 
            this.button_parar_vertical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_parar_vertical.BackColor = System.Drawing.Color.Red;
            this.button_parar_vertical.Cursor = System.Windows.Forms.Cursors.No;
            this.button_parar_vertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_parar_vertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_parar_vertical.Location = new System.Drawing.Point(18, 439);
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
            this.btnEnergizarVertical.Location = new System.Drawing.Point(18, 301);
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
            this.richTextBox4.Location = new System.Drawing.Point(12, 45);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox4.Size = new System.Drawing.Size(212, 34);
            this.richTextBox4.TabIndex = 19;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // btnLigarVertical
            // 
            this.btnLigarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarVertical.Location = new System.Drawing.Point(18, 372);
            this.btnLigarVertical.Name = "btnLigarVertical";
            this.btnLigarVertical.Size = new System.Drawing.Size(198, 54);
            this.btnLigarVertical.TabIndex = 25;
            this.btnLigarVertical.Text = "Ligar";
            this.btnLigarVertical.UseVisualStyleBackColor = false;
            this.btnLigarVertical.Click += new System.EventHandler(this.btnLigarVertical_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 181);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(212, 34);
            this.richTextBox1.TabIndex = 21;
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // richTextBox_Arduino
            // 
            this.richTextBox_Arduino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Arduino.Cursor = System.Windows.Forms.Cursors.Help;
            this.richTextBox_Arduino.Location = new System.Drawing.Point(601, 154);
            this.richTextBox_Arduino.Name = "richTextBox_Arduino";
            this.richTextBox_Arduino.Size = new System.Drawing.Size(240, 96);
            this.richTextBox_Arduino.TabIndex = 30;
            this.richTextBox_Arduino.Text = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Location = new System.Drawing.Point(298, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 577);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button_parar_horizontal);
            this.panel4.Controls.Add(this.btnEnergizarHorizontal);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.richTextBox3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnDireicaoHorizontallCima);
            this.panel4.Controls.Add(this.btnLigarHorizontal);
            this.panel4.Controls.Add(this.richTextBox5);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.btnDirecaoHorizontalBaixo);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.richTextBox6);
            this.panel4.Location = new System.Drawing.Point(3, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 515);
            this.panel4.TabIndex = 27;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // button_parar_horizontal
            // 
            this.button_parar_horizontal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_parar_horizontal.BackColor = System.Drawing.Color.Red;
            this.button_parar_horizontal.Cursor = System.Windows.Forms.Cursors.No;
            this.button_parar_horizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_parar_horizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_parar_horizontal.Location = new System.Drawing.Point(18, 439);
            this.button_parar_horizontal.Name = "button_parar_horizontal";
            this.button_parar_horizontal.Size = new System.Drawing.Size(198, 61);
            this.button_parar_horizontal.TabIndex = 30;
            this.button_parar_horizontal.Text = "Parar";
            this.button_parar_horizontal.UseVisualStyleBackColor = false;
            this.button_parar_horizontal.Click += new System.EventHandler(this.button_parar_horizontal_Click);
            // 
            // btnEnergizarHorizontal
            // 
            this.btnEnergizarHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEnergizarHorizontal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnergizarHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnergizarHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnergizarHorizontal.Location = new System.Drawing.Point(18, 301);
            this.btnEnergizarHorizontal.Name = "btnEnergizarHorizontal";
            this.btnEnergizarHorizontal.Size = new System.Drawing.Size(198, 60);
            this.btnEnergizarHorizontal.TabIndex = 24;
            this.btnEnergizarHorizontal.Text = "Desenergizado";
            this.btnEnergizarHorizontal.UseVisualStyleBackColor = false;
            this.btnEnergizarHorizontal.Click += new System.EventHandler(this.btnEnergizarHorizontal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 25);
            this.label6.TabIndex = 28;
            this.label6.Text = "Constante de Calibração:";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox3.BackColor = System.Drawing.Color.White;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(12, 45);
            this.richTextBox3.Multiline = false;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox3.Size = new System.Drawing.Size(212, 34);
            this.richTextBox3.TabIndex = 19;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox6_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Distância (mm):";
            // 
            // btnDireicaoHorizontallCima
            // 
            this.btnDireicaoHorizontallCima.AutoSize = true;
            this.btnDireicaoHorizontallCima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDireicaoHorizontallCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireicaoHorizontallCima.Location = new System.Drawing.Point(10, 261);
            this.btnDireicaoHorizontallCima.Name = "btnDireicaoHorizontallCima";
            this.btnDireicaoHorizontallCima.Size = new System.Drawing.Size(117, 29);
            this.btnDireicaoHorizontallCima.TabIndex = 22;
            this.btnDireicaoHorizontallCima.Text = "Esquerda";
            this.btnDireicaoHorizontallCima.UseVisualStyleBackColor = true;
            this.btnDireicaoHorizontallCima.CheckedChanged += new System.EventHandler(this.btnDireicaoHorizontallCima_CheckedChanged);
            // 
            // btnLigarHorizontal
            // 
            this.btnLigarHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarHorizontal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarHorizontal.Location = new System.Drawing.Point(18, 372);
            this.btnLigarHorizontal.Name = "btnLigarHorizontal";
            this.btnLigarHorizontal.Size = new System.Drawing.Size(198, 54);
            this.btnLigarHorizontal.TabIndex = 25;
            this.btnLigarHorizontal.Text = "Ligar";
            this.btnLigarHorizontal.UseVisualStyleBackColor = false;
            this.btnLigarHorizontal.Click += new System.EventHandler(this.btnLigarHorizontal_Click);
            // 
            // richTextBox5
            // 
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox5.Location = new System.Drawing.Point(12, 116);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(212, 34);
            this.richTextBox5.TabIndex = 20;
            this.richTextBox5.Text = "";
            this.richTextBox5.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Velocidade (mm/s):";
            // 
            // btnDirecaoHorizontalBaixo
            // 
            this.btnDirecaoHorizontalBaixo.AutoSize = true;
            this.btnDirecaoHorizontalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoHorizontalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoHorizontalBaixo.Location = new System.Drawing.Point(138, 261);
            this.btnDirecaoHorizontalBaixo.Name = "btnDirecaoHorizontalBaixo";
            this.btnDirecaoHorizontalBaixo.Size = new System.Drawing.Size(88, 29);
            this.btnDirecaoHorizontalBaixo.TabIndex = 23;
            this.btnDirecaoHorizontalBaixo.Text = "Direita";
            this.btnDirecaoHorizontalBaixo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Direção de movimento:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBox6
            // 
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox6.Location = new System.Drawing.Point(12, 181);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(212, 34);
            this.richTextBox6.TabIndex = 21;
            this.richTextBox6.Text = "";
            this.richTextBox6.TextChanged += new System.EventHandler(this.richTextBox6_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(65, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 29);
            this.label10.TabIndex = 26;
            this.label10.Text = "Horizontal";
            // 
            // richTextBox_Arduino2
            // 
            this.richTextBox_Arduino2.Cursor = System.Windows.Forms.Cursors.Help;
            this.richTextBox_Arduino2.Location = new System.Drawing.Point(24, 595);
            this.richTextBox_Arduino2.Name = "richTextBox_Arduino2";
            this.richTextBox_Arduino2.Size = new System.Drawing.Size(516, 53);
            this.richTextBox_Arduino2.TabIndex = 30;
            this.richTextBox_Arduino2.Text = "";
            // 
            // Form2_BiDirecional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 660);
            this.Controls.Add(this.richTextBox_Arduino2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.richTextBox_Arduino);
            this.Controls.Add(this.panel1);
            this.Name = "Form2_BiDirecional";
            this.Text = "Atuador Bi-Direcional";
            this.Load += new System.EventHandler(this.Form2_BiDirecional_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Button btnLigarVertical;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnergizarVertical;
        private System.Windows.Forms.RichTextBox richTextBox_Arduino;
        private System.Windows.Forms.Button button_parar_vertical;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEnergizarHorizontal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton btnDireicaoHorizontallCima;
        private System.Windows.Forms.Button btnLigarHorizontal;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton btnDirecaoHorizontalBaixo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_parar_horizontal;
        private System.Windows.Forms.RichTextBox richTextBox_Arduino2;
    }
}