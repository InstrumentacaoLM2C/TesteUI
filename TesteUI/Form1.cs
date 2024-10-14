using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TesteUI
{
    public partial class Form1 : Form
    {
        bool on_sensor = false;
        private delegate void d1(string indata);
        bool on_energizar_vertical = false;
        bool on_energizar_horizontal = false;
        bool on_sensor_vertical = false;
        bool on_sensor_horizontal = false;
        bool motorVertical = true;
        bool ligarMotor_vertical = false;
        bool ligarMotor_horizontal = false;
        double distancia_mm1;
        float distancia_mm2;
        float velocidade_mm1;
        float velocidade_mm2;
        double distancia_pulsos1;
        double distancia_pulsos2;
        double velocidade_pulsos1;
        double velocidade_pulsos2;
        string distancia = "0";  // posição
        string velocidade = "0";  // velocidade
        string direcao = "0";  // direção
        int motor = 1; // Armazena qual motor está sendo utilizado
        double constanteCalibracao2 = 1;
        double constanteCalibracao1 = 1;  //A constante de calibração default dos motores que representa a velocidade de aceleração de 2500pulsos/s

        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
           

            btnMotor.Text = "Motor Vertical";

            btnDireicaoVerticalCima.Text = "Cima";
            btnDirecaoVerticalBaixo.Text = "Baixo";

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = serialPort1.ReadLine();
            d1 writeit = new d1(Write2Form);
            Invoke(writeit, indata);

        }

        private void commit() { }
        private bool VerificarTextoValido(RichTextBox richTextBox)
        {
            // Verifica se a RichTextBox está vazia ou contém apenas espaços em branco
            if (string.IsNullOrWhiteSpace(richTextBox.Text))
            {
                return false; // Não é válido
            }

            // Adicionalmente, você pode verificar se o texto é um número
            // Exemplo: Verifica se o texto pode ser convertido para um número
            if (!double.TryParse(richTextBox.Text, out _))
            {
                return false; // Não é um número válido
            }

            return true; // Texto é válido
        }

        public void Write2Form(String indata)
        {
            // This function handles data sent from the arduino

            char g = indata[0];
            String texto = Convert.ToString(indata).Substring(1).Replace("#", "");

            switch (g)
            {

                //Algumas mensagens com caracteres especiais
                case 'j':
                    TextBox.AppendText("Calibração iniciada!\r\n");
                    break;
                case 'c':
                    TextBox.AppendText("Direcão motor 1: Para cima\r\n");
                    break;
                case 'C':
                    TextBox.AppendText("Direcão motor 2: Para cima\r\n");
                    break;

                case 'b':
                    TextBox.AppendText("Direcão motor 1: Para baixo\r\n");
                    break;
                case 'B':
                    TextBox.AppendText("Direcão motor 2: Para baixo\r\n");
                    break;

                case 'a':
                    TextBox.AppendText("O motor 1 está se movendo com aceleração!\r\n");
                    break;
                case 'A':
                    TextBox.AppendText("O motor 2 está se movendo com aceleração!" + "\r\n");
                    break;

                case 'Q':
                    TextBox.AppendText("Valor de velocidade inválido! Insira um valor entre 200 e 8000 pulsos/segundo" + "\r\n");
                    break;

                case 'T':
                    btnSensorHorizontal.Text = "Desligado";
                    btnSensorHorizontal.BackColor = Color.DarkGray;
                    on_sensor = true;
                    TextBox.AppendText("Mude a direção do deslocamento para movimenta-lo." + "\r\n" + "Aperte o botão para ativar o sensor indutivo novamente!" + "\r\n");
                    break;

                case 'U':
                    TextBox.AppendText("Primeiro motor sendo operado!" + "\r\n");
                    break;
                case 'u':
                    TextBox.AppendText("Segundo motor sendo operado!" + "\r\n");
                    break;

                case 'Y'://motor2

                    ligarMotor_horizontal = false;
                    on_energizar_horizontal = false;
                    btnLigarHorizontal.Text = "Ligar";
                    btnLigarHorizontal.BackColor = Color.DarkGray;
                    MessageBox.Show("O motor horizontal parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
            
                    break;

                case 'y'://motor1

                    ligarMotor_vertical = false;
                    on_energizar_vertical = false;
                    btnLigarVertical.Text = "Ligar";
                    btnLigarVertical.BackColor = Color.DarkGray;
                    MessageBox.Show("O motor vertical parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;
                    

                case '/':
                    TextBox.AppendText(texto + "\r\n");
                    break;

                case 'w':
                    if (motor == 1)
                    {
                        TextBox.AppendText("A constante de calibração do motor 1 é:" + texto + "\r\n");
                    }
                    else
                    {
                        TextBox.AppendText("A constante de calibração do motor 2 é:" + texto + "\r\n");
                    }

                    break;

                default:
                    TextBox.AppendText(texto + "\r\n");
                    break;


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        } 
        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try { 
                if (motorVertical == true)// Se o motor vertical estiver acionado, trocar para o horizontal e vice versa
            {

                serialPort1.Write("M#");
                    System.Threading.Thread.Sleep(100);
                    motorVertical = false;
                    label6.Visible = true;
                    label8.Visible = true;
                    label7.Visible = false;
                    label9.Visible = false;
                    btnEnergizarVertical.SendToBack();
                btnLigarVertical.SendToBack();
                btnSensorVertical.SendToBack();

                btnDireicaoVerticalCima.Visible = false;
                btnDirecaoVerticalBaixo.Visible = false;
                btnDirecaoHorizontalBaixo.Visible = true;
                btnDirecaoHorizontalCima.Visible = true;
                
                btnMotor.Text = "Motor Horizontal";
                btnDireicaoVerticalCima.Text = " ";
                btnDirecaoVerticalBaixo.Text = " ";
                btnDirecaoHorizontalCima.Text = "Direita";
                btnDirecaoHorizontalBaixo.Text = "Esquerda";
            }
            else if(motorVertical == false) 
            {

                
                serialPort1.Write("R#");
                    System.Threading.Thread.Sleep(100);
                    motorVertical = true;
                    
                    label7.Visible = true;
                    label9.Visible = true;
                    label6.Visible = false;
                    label8.Visible = false;
                    btnEnergizarHorizontal.SendToBack();
                btnLigarHorizontal.SendToBack();
                btnSensorHorizontal.SendToBack();
                btnDireicaoVerticalCima.Visible = true;
                btnDirecaoVerticalBaixo.Visible = true;
                btnDirecaoHorizontalBaixo.Visible = false;
                btnDirecaoHorizontalCima.Visible = false;

                btnMotor.Text = "Motor Vertical";
                btnDireicaoVerticalCima.Text = "Cima";
                btnDirecaoVerticalBaixo.Text = "Baixo";
                btnDirecaoHorizontalCima.Text = " ";
                btnDirecaoHorizontalBaixo.Text = " ";
                
            }
        }catch (Exception ex)
            {
                MessageBox.Show("Conecte a porta serial!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Send Send direction(CW or CCW) to driver  
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            try
            {
                if (on_energizar_vertical)
                {
                    // Send command to the arduino to turn on the enable function of the driver energizing the motor
                    try
                    {
                        // Enviar comando para parar o motor
                        serialPort1.Write("A#");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnEnergizarVertical.Text = "Energizado";
                    btnEnergizarVertical.BackColor = Color.Green;
                    on_energizar_vertical = false;
                }
                else
                {
                    if(ligarMotor_vertical == true)
                    {
                        MessageBox.Show("Desligue o motor vertical para desenergizá-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else if (ligarMotor_vertical == false)
                    {
                        try
                        {
                            // Enviar comando para parar o motor
                            serialPort1.Write("a#");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        btnEnergizarVertical.Text = "Desenergizado";
                        btnEnergizarVertical.BackColor = Color.DarkGray;
                        on_energizar_vertical = true;
                    }
                    
                }
            }
            catch { TextBox.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n"); }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (on_sensor_horizontal == false)
            {
                //Ativa o sensor indutivo
                try
                {
                    // Enviar comando para parar o motor
                    serialPort1.Write("S#");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSensorHorizontal.Text = "Ligado";
                btnSensorHorizontal.BackColor = Color.Green;
                on_sensor_horizontal = true;
            }
            else
            {
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdBtn2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnLigar_Click(object sender, EventArgs e)
        {
            if (btnDirecaoHorizontalBaixo.Checked)
            {
                direcao = "B";
            }
            else if (btnDirecaoHorizontalCima.Checked)
            {
                direcao = "C";
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma direção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (VerificarTextoValido(richTextBox1) && VerificarTextoValido(richTextBox2))
            {
                try
                {
                    distancia = richTextBox1.Text;
                    velocidade = richTextBox2.Text;
                    serialPort1.Write("T" + distancia_pulsos2 + ";" + velocidade_pulsos2 + ";" + direcao + ";H#");
                    System.Threading.Thread.Sleep(100);
                    if (ligarMotor_horizontal)
                    {
                        try
                        {
                            // Enviar comando para parar o motor
                            serialPort1.Write("n#");
                            System.Threading.Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        btnLigarHorizontal.Text = "Ligar";
                        btnLigarHorizontal.BackColor = Color.DarkGray;
                        ligarMotor_horizontal = false;
                        on_energizar_horizontal = false;
                       
                    }
                    else if (!ligarMotor_horizontal)
                    {
                        btnLigarHorizontal.Text = "Ligado";
                        btnLigarHorizontal.BackColor = Color.Green;
                        ligarMotor_horizontal = true;
                        on_energizar_horizontal = true;
                       
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione valores válidos para distância e velocidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                button3.Text = "desconectar";
            }
            catch (Exception err)
            {
                //TextBox.AppendText("Erro! Tente novamente!" + "\r\n");
                string[] ports = SerialPort.GetPortNames();
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(ports);

            }
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            // Send pulse qntd to driver

            serialPort1.Write("n#");
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            try
            {
                if(button4.Text == " Conectar")
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.Open();
                    button4.Text = "Desconectar";
                }
                else
                {
                    serialPort1.Close();
                    string[] ports = SerialPort.GetPortNames();
                    comboBox1.Items.Clear();
                    button4.Text = " Conectar";
                    comboBox1.Items.AddRange(ports);
                }
            }
            catch
            {
                TextBox.AppendText("Erro! Tente novamente!" + "\r\n");
                string[] ports = SerialPort.GetPortNames();
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(ports);

            }
        }

        private void btnMotorHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                if (on_energizar_horizontal)
                {
                    // Send command to the arduino to turn on the enable function of the driver energizing the motor
                    serialPort1.Write("A#");
                    btnEnergizarHorizontal.Text = "Energizado";
                    btnEnergizarHorizontal.BackColor = Color.Green;
                    on_energizar_horizontal = false;
                }
                else
                {
                    if (ligarMotor_horizontal== true)
                    {
                        MessageBox.Show("Desligue o motor horizontal para desenergizá-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ligarMotor_horizontal == false)
                    {
                        serialPort1.Write("a#");
                        btnEnergizarHorizontal.Text = "Desenergizado";
                        btnEnergizarHorizontal.BackColor = Color.DarkGray;
                        on_energizar_horizontal = true;
                    }
                }
            }
            catch { TextBox.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n"); }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void btnLigarVertical_Click(object sender, EventArgs e)
        {
            if (btnDirecaoVerticalBaixo.Checked)
            {
                direcao = "B";
            }
            else if (btnDireicaoVerticalCima.Checked)
            {
                direcao = "C";
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma direção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerificarTextoValido(richTextBox1) && VerificarTextoValido(richTextBox2))
            {
                try
                {
                    distancia = richTextBox1.Text;
                    velocidade = richTextBox2.Text;
                    serialPort1.Write("T" + distancia_pulsos1 + ";" + velocidade_pulsos1 + ";" + direcao + ";H#");
                    System.Threading.Thread.Sleep(100);
                    if (ligarMotor_vertical == true) { 

                        btnLigarVertical.Text = "Ligar";
                        btnLigarVertical.BackColor = Color.DarkGray;
                        ligarMotor_vertical = false;
                        on_energizar_vertical = false;
                        try
                        {
                            // Enviar comando para parar o motor
                            serialPort1.Write("n#");
                            System.Threading.Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                }
                    else if (ligarMotor_vertical == false)
                    {
                        btnLigarVertical.Text = "Ligado";
                        btnLigarVertical.BackColor = Color.Green;
                        ligarMotor_vertical = true;
                        on_energizar_vertical = true;
                        
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Por favor, selecione valores válidos para distância e velocidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("U" + richTextBox4.Text + "#");
                // Send calibration constant to arduino
                if (motorVertical == true)
                {

                    distancia_mm1 = float.Parse(richTextBox1.Text, new CultureInfo("pt-BR"));
                    velocidade_mm1 = float.Parse(richTextBox2.Text, new CultureInfo("pt-BR"));
                    constanteCalibracao1 = double.Parse(richTextBox4.Text, new CultureInfo("pt-BR"));



                    distancia_pulsos1 = Math.Round(distancia_mm1 / constanteCalibracao1, 4);
                    velocidade_pulsos1 = Math.Round(velocidade_mm1 / constanteCalibracao1, 4);

                    button1.Text = "Constante de Calibração: " + constanteCalibracao1;
                    label7.Text = "Qtd. Pulsos: " + distancia_pulsos1.ToString();
                    label9.Text = "Pulsos/s: " + velocidade_pulsos1.ToString();
                    label6.Text = "Qtd. Pulsos: " + distancia_pulsos2.ToString();
                    label8.Text = "Pulsos/s: " + velocidade_pulsos2.ToString();


                }
                else if (motorVertical == false)
                {

                    distancia_mm2 = float.Parse(richTextBox1.Text, new CultureInfo("pt-BR"));
                    velocidade_mm2 = float.Parse(richTextBox2.Text, new CultureInfo("pt-BR"));
                    constanteCalibracao2 = float.Parse(richTextBox4.Text, new CultureInfo("pt-BR"));

                    distancia_pulsos2 = (float)Math.Round(distancia_mm2 / constanteCalibracao2, 2);
                    velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao2, 2);

                    button1.Text = "Constante de Calibração: " + constanteCalibracao2;
                    label7.Text = "Qtd. Pulsos: " + distancia_pulsos1.ToString();
                    label9.Text = "Pulsos/s: " + velocidade_pulsos1.ToString();
                    label6.Text = "Qtd. Pulsos: " + distancia_pulsos2.ToString();
                    label8.Text = "Pulsos/s: " + velocidade_pulsos2.ToString();

                }

                
            }
            catch
            {
                MessageBox.Show("Conecte-se a porta serial e escreva apenas números!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBox.AppendText("O tipo de texto que você colocou na caixa de constante não é válido. Tente Novamente!\r\n");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSensorVertical_Click(object sender, EventArgs e)
        {
            if (on_sensor_vertical == false)
            {
                //Ativa o sensor indutivo
                try
                {
                    // Enviar comando para parar o motor
                    serialPort1.Write("S#");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSensorVertical.Text = "Ligado";
                btnSensorVertical.BackColor = Color.Green;
                on_sensor_vertical = true;
            }
            else
            {
                return; 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(ligarMotor_horizontal == true || ligarMotor_vertical == true)
            {
                try
                {
                    // Enviar comando para parar o motor
                    serialPort1.Write("n#");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar comando de parada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                MessageBox.Show("A porta serial foi fechada.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Libere recursos, se necessário
            serialPort1.Dispose();
            base.OnFormClosed(e);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
