﻿namespace TesteUI
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelPortsSubmenu = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMotor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDirecaoHorizontalCima = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDirecaoHorizontalBaixo = new System.Windows.Forms.RadioButton();
            this.btnEnergizarVertical = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSensorHorizontal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLigarHorizontal = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox_Arduino = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSensorVertical = new System.Windows.Forms.Button();
            this.btnDirecaoVerticalBaixo = new System.Windows.Forms.RadioButton();
            this.btnDireicaoVerticalCima = new System.Windows.Forms.RadioButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnEnergizarHorizontal = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnLigarVertical = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Botao_Painel_subsidencia = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_subsidencia = new System.Windows.Forms.Panel();
            this.Solta_motor = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panelPortsSubmenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_subsidencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.DarkGray;
            this.panelSideMenu.Controls.Add(this.Botao_Painel_subsidencia);
            this.panelSideMenu.Controls.Add(this.button6);
            this.panelSideMenu.Controls.Add(this.richTextBox4);
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.panelPortsSubmenu);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.ForeColor = System.Drawing.Color.Gray;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(314, 562);
            this.panelSideMenu.TabIndex = 0;
            this.panelSideMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSideMenu_Paint);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Gainsboro;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(0, 415);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(314, 47);
            this.button6.TabIndex = 22;
            this.button6.Text = "Enviar";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.White;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.Location = new System.Drawing.Point(0, 372);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox4.Size = new System.Drawing.Size(314, 43);
            this.richTextBox4.TabIndex = 21;
            this.richTextBox4.Text = "";
            this.richTextBox4.Click += new System.EventHandler(this.richTextBox4_Click);
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(0, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(314, 73);
            this.button1.TabIndex = 19;
            this.button1.Text = "Constante de Calibração: ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panelPortsSubmenu
            // 
            this.panelPortsSubmenu.BackColor = System.Drawing.Color.DimGray;
            this.panelPortsSubmenu.Controls.Add(this.button4);
            this.panelPortsSubmenu.Controls.Add(this.button3);
            this.panelPortsSubmenu.Controls.Add(this.comboBox1);
            this.panelPortsSubmenu.Controls.Add(this.button2);
            this.panelPortsSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPortsSubmenu.Location = new System.Drawing.Point(0, 163);
            this.panelPortsSubmenu.Name = "panelPortsSubmenu";
            this.panelPortsSubmenu.Size = new System.Drawing.Size(314, 136);
            this.panelPortsSubmenu.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(0, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(314, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "Conectar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_3);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGray;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(0, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(314, 39);
            this.button3.TabIndex = 3;
            this.button3.Text = " Conectar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(314, 37);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(314, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Escanear Portas";
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Silver;
            this.panelLogo.BackgroundImage = global::TesteUI.Properties.Resources.LM2C_Retina___Copia;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(314, 163);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // btnMotor
            // 
            this.btnMotor.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMotor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMotor.FlatAppearance.BorderSize = 0;
            this.btnMotor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotor.Location = new System.Drawing.Point(0, -1);
            this.btnMotor.Margin = new System.Windows.Forms.Padding(0);
            this.btnMotor.Name = "btnMotor";
            this.btnMotor.Size = new System.Drawing.Size(624, 78);
            this.btnMotor.TabIndex = 0;
            this.btnMotor.Text = "Motor Vertical";
            this.btnMotor.UseVisualStyleBackColor = false;
            this.btnMotor.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Distância (mm):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Velocidade (mm/s):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnDirecaoHorizontalCima
            // 
            this.btnDirecaoHorizontalCima.AutoSize = true;
            this.btnDirecaoHorizontalCima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoHorizontalCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoHorizontalCima.Location = new System.Drawing.Point(397, 155);
            this.btnDirecaoHorizontalCima.Name = "btnDirecaoHorizontalCima";
            this.btnDirecaoHorizontalCima.Size = new System.Drawing.Size(17, 16);
            this.btnDirecaoHorizontalCima.TabIndex = 5;
            this.btnDirecaoHorizontalCima.UseVisualStyleBackColor = true;
            this.btnDirecaoHorizontalCima.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Direção do motor:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnDirecaoHorizontalBaixo
            // 
            this.btnDirecaoHorizontalBaixo.AutoSize = true;
            this.btnDirecaoHorizontalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoHorizontalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoHorizontalBaixo.Location = new System.Drawing.Point(523, 155);
            this.btnDirecaoHorizontalBaixo.Name = "btnDirecaoHorizontalBaixo";
            this.btnDirecaoHorizontalBaixo.Size = new System.Drawing.Size(17, 16);
            this.btnDirecaoHorizontalBaixo.TabIndex = 8;
            this.btnDirecaoHorizontalBaixo.UseVisualStyleBackColor = true;
            this.btnDirecaoHorizontalBaixo.CheckedChanged += new System.EventHandler(this.rdBtn2_CheckedChanged);
            // 
            // btnEnergizarVertical
            // 
            this.btnEnergizarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEnergizarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnergizarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnergizarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnergizarVertical.Location = new System.Drawing.Point(33, 133);
            this.btnEnergizarVertical.Name = "btnEnergizarVertical";
            this.btnEnergizarVertical.Size = new System.Drawing.Size(165, 60);
            this.btnEnergizarVertical.TabIndex = 9;
            this.btnEnergizarVertical.Text = "Desenergizado";
            this.btnEnergizarVertical.UseVisualStyleBackColor = false;
            this.btnEnergizarVertical.Click += new System.EventHandler(this.button4_Click);
            this.btnEnergizarVertical.MouseHover += new System.EventHandler(this.btnEnergizarVertical_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Motor";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnSensorHorizontal
            // 
            this.btnSensorHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSensorHorizontal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSensorHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSensorHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensorHorizontal.Location = new System.Drawing.Point(207, 133);
            this.btnSensorHorizontal.Name = "btnSensorHorizontal";
            this.btnSensorHorizontal.Size = new System.Drawing.Size(165, 60);
            this.btnSensorHorizontal.TabIndex = 11;
            this.btnSensorHorizontal.Text = "Desligado";
            this.btnSensorHorizontal.UseVisualStyleBackColor = false;
            this.btnSensorHorizontal.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sensor indutivo";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnLigarHorizontal
            // 
            this.btnLigarHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarHorizontal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarHorizontal.Location = new System.Drawing.Point(33, 361);
            this.btnLigarHorizontal.Name = "btnLigarHorizontal";
            this.btnLigarHorizontal.Size = new System.Drawing.Size(240, 60);
            this.btnLigarHorizontal.TabIndex = 13;
            this.btnLigarHorizontal.Text = "Ligar";
            this.btnLigarHorizontal.UseVisualStyleBackColor = false;
            this.btnLigarHorizontal.Click += new System.EventHandler(this.btnLigar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel_subsidencia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(314, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 562);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // richTextBox_Arduino
            // 
            this.richTextBox_Arduino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Arduino.Cursor = System.Windows.Forms.Cursors.Help;
            this.richTextBox_Arduino.Location = new System.Drawing.Point(334, 344);
            this.richTextBox_Arduino.Name = "richTextBox_Arduino";
            this.richTextBox_Arduino.Size = new System.Drawing.Size(240, 96);
            this.richTextBox_Arduino.TabIndex = 29;
            this.richTextBox_Arduino.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(329, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "Pulsos/s:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 29);
            this.label8.TabIndex = 27;
            this.label8.Text = "Pulsos/s:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 26;
            this.label7.Text = "Qtd. Pulsos:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 29);
            this.label6.TabIndex = 25;
            this.label6.Text = "Qtd. Pulsos:";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // btnSensorVertical
            // 
            this.btnSensorVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSensorVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSensorVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSensorVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensorVertical.Location = new System.Drawing.Point(207, 133);
            this.btnSensorVertical.Name = "btnSensorVertical";
            this.btnSensorVertical.Size = new System.Drawing.Size(165, 60);
            this.btnSensorVertical.TabIndex = 22;
            this.btnSensorVertical.Text = "Desligado";
            this.btnSensorVertical.UseVisualStyleBackColor = false;
            this.btnSensorVertical.Click += new System.EventHandler(this.btnSensorVertical_Click);
            // 
            // btnDirecaoVerticalBaixo
            // 
            this.btnDirecaoVerticalBaixo.AutoSize = true;
            this.btnDirecaoVerticalBaixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirecaoVerticalBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirecaoVerticalBaixo.Location = new System.Drawing.Point(523, 153);
            this.btnDirecaoVerticalBaixo.Name = "btnDirecaoVerticalBaixo";
            this.btnDirecaoVerticalBaixo.Size = new System.Drawing.Size(82, 29);
            this.btnDirecaoVerticalBaixo.TabIndex = 21;
            this.btnDirecaoVerticalBaixo.Text = "Baixo";
            this.btnDirecaoVerticalBaixo.UseVisualStyleBackColor = true;
            this.btnDirecaoVerticalBaixo.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // btnDireicaoVerticalCima
            // 
            this.btnDireicaoVerticalCima.AutoSize = true;
            this.btnDireicaoVerticalCima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDireicaoVerticalCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireicaoVerticalCima.Location = new System.Drawing.Point(397, 153);
            this.btnDireicaoVerticalCima.Name = "btnDireicaoVerticalCima";
            this.btnDireicaoVerticalCima.Size = new System.Drawing.Size(79, 29);
            this.btnDireicaoVerticalCima.TabIndex = 20;
            this.btnDireicaoVerticalCima.Text = "Cima";
            this.btnDireicaoVerticalCima.UseVisualStyleBackColor = true;
            this.btnDireicaoVerticalCima.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(334, 248);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(240, 38);
            this.richTextBox2.TabIndex = 16;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(33, 248);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(240, 38);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            this.richTextBox1.SizeChanged += new System.EventHandler(this.richTextBox1_SizeChanged);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnEnergizarHorizontal
            // 
            this.btnEnergizarHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEnergizarHorizontal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnergizarHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnergizarHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnergizarHorizontal.Location = new System.Drawing.Point(33, 133);
            this.btnEnergizarHorizontal.Name = "btnEnergizarHorizontal";
            this.btnEnergizarHorizontal.Size = new System.Drawing.Size(165, 60);
            this.btnEnergizarHorizontal.TabIndex = 18;
            this.btnEnergizarHorizontal.Text = "Desenergizado";
            this.btnEnergizarHorizontal.UseVisualStyleBackColor = false;
            this.btnEnergizarHorizontal.Click += new System.EventHandler(this.btnMotorHorizontal_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.Red;
            this.button7.Cursor = System.Windows.Forms.Cursors.No;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(0, 466);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(625, 95);
            this.button7.TabIndex = 24;
            this.button7.Text = "Parar";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnLigarVertical
            // 
            this.btnLigarVertical.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLigarVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLigarVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLigarVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarVertical.Location = new System.Drawing.Point(33, 361);
            this.btnLigarVertical.Name = "btnLigarVertical";
            this.btnLigarVertical.Size = new System.Drawing.Size(240, 60);
            this.btnLigarVertical.TabIndex = 19;
            this.btnLigarVertical.Text = "Ligar";
            this.btnLigarVertical.UseVisualStyleBackColor = false;
            this.btnLigarVertical.Click += new System.EventHandler(this.btnLigarVertical_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM14";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Botao_Painel_subsidencia
            // 
            this.Botao_Painel_subsidencia.BackColor = System.Drawing.Color.Gainsboro;
            this.Botao_Painel_subsidencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Botao_Painel_subsidencia.FlatAppearance.BorderSize = 0;
            this.Botao_Painel_subsidencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Botao_Painel_subsidencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botao_Painel_subsidencia.ForeColor = System.Drawing.Color.Black;
            this.Botao_Painel_subsidencia.Location = new System.Drawing.Point(0, 505);
            this.Botao_Painel_subsidencia.Name = "Botao_Painel_subsidencia";
            this.Botao_Painel_subsidencia.Size = new System.Drawing.Size(314, 52);
            this.Botao_Painel_subsidencia.TabIndex = 23;
            this.Botao_Painel_subsidencia.Text = "Modo subsidência";
            this.Botao_Painel_subsidencia.UseVisualStyleBackColor = false;
            this.Botao_Painel_subsidencia.Click += new System.EventHandler(this.Botao_Painel_subsidencia_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMotor);
            this.panel1.Controls.Add(this.richTextBox_Arduino);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnLigarHorizontal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnLigarVertical);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnEnergizarHorizontal);
            this.panel1.Controls.Add(this.btnSensorVertical);
            this.panel1.Controls.Add(this.btnSensorHorizontal);
            this.panel1.Controls.Add(this.btnDirecaoVerticalBaixo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDireicaoVerticalCima);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.btnDirecaoHorizontalCima);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDirecaoHorizontalBaixo);
            this.panel1.Controls.Add(this.btnEnergizarVertical);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 557);
            this.panel1.TabIndex = 30;
            // 
            // panel_subsidencia
            // 
            this.panel_subsidencia.Controls.Add(this.Solta_motor);
            this.panel_subsidencia.Location = new System.Drawing.Point(-1, -2);
            this.panel_subsidencia.Name = "panel_subsidencia";
            this.panel_subsidencia.Size = new System.Drawing.Size(624, 563);
            this.panel_subsidencia.TabIndex = 30;
            // 
            // Solta_motor
            // 
            this.Solta_motor.BackColor = System.Drawing.Color.Gainsboro;
            this.Solta_motor.Location = new System.Drawing.Point(222, 248);
            this.Solta_motor.Name = "Solta_motor";
            this.Solta_motor.Size = new System.Drawing.Size(179, 110);
            this.Solta_motor.TabIndex = 0;
            this.Solta_motor.Text = "Solta Motor";
            this.Solta_motor.UseVisualStyleBackColor = false;
            this.Solta_motor.Click += new System.EventHandler(this.Solta_motor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.Text = "Atuador Bi-Direcional UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelPortsSubmenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_subsidencia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelPortsSubmenu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnMotor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton btnDirecaoHorizontalCima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton btnDirecaoHorizontalBaixo;
        private System.Windows.Forms.Button btnEnergizarVertical;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSensorHorizontal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLigarHorizontal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnEnergizarHorizontal;
        private System.Windows.Forms.Button btnLigarVertical;
        private System.Windows.Forms.RadioButton btnDirecaoVerticalBaixo;
        private System.Windows.Forms.RadioButton btnDireicaoVerticalCima;
        private System.Windows.Forms.Button btnSensorVertical;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox_Arduino;
        private System.Windows.Forms.Button Botao_Painel_subsidencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_subsidencia;
        private System.Windows.Forms.Button Solta_motor;
    }
}

