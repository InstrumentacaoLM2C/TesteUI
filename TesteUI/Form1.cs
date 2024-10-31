using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
        bool on_energizar_vertical = true;
        bool on_energizar_horizontal = true;
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
            try
            {
                // Ler a linha recebida da porta serial
                string indata = serialPort1.ReadLine();

                // Usar Invoke para atualizar a interface do usuário de forma segura
                d1 writeit = new d1(Write2Form);
                Invoke(writeit, indata);
            }
            catch (IOException ioEx)
            {
                // Exibir uma mensagem de erro se houver um problema de I/O
                MessageBox.Show("Erro de comunicação com a porta serial.\n\n" +
                                $"Detalhes do erro: {ioEx.Message}",
                                "Erro de Comunicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Tratar outros tipos de exceções que possam ocorrer
                MessageBox.Show("Uma falha inesperada ocorreu ao receber dados da porta serial.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro Desconhecido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
                    richTextBox_Arduino.AppendText("Calibração iniciada!\r\n\r\n");
                    break;
                case 'c':
                    richTextBox_Arduino.AppendText("Direcão motor 1: Para cima\r\n\r\n");
                    break;
                case 'C':
                    richTextBox_Arduino.AppendText("Direcão motor 2: Para cima\r\n\r\n");
                    break;

                case 'b':
                    richTextBox_Arduino.AppendText("Direcão motor 1: Para baixo\r\n\r\n");
                    break;
                case 'B':
                    richTextBox_Arduino.AppendText("Direcão motor 2: Para baixo\r\n\r\n");
                    break;

                case 'a':
                    richTextBox_Arduino.AppendText("O motor 1 está se movendo com aceleração!\r\n\r\n");
                    break;
                case 'A':
                    richTextBox_Arduino.AppendText("O motor 2 está se movendo com aceleração!" + "\r\n\r\n");
                    break;

                case 'Q':
                    richTextBox_Arduino.AppendText("Valor de velocidade inválido! Insira um valor entre 200 e 8000 pulsos/segundo" + "\r\n\r\n");
                    break;

                case 'T':
                    btnSensorHorizontal.Text = "Desligado";
                    btnSensorHorizontal.BackColor = Color.Gainsboro;
                    on_sensor = true;
                    richTextBox_Arduino.AppendText("Mude a direção do deslocamento para movimenta-lo." + "\r\n\r\n" + "Aperte o botão para ativar o sensor indutivo novamente!" + "\r\n\r\n");
                    break;

                case 'U':
                    richTextBox_Arduino.AppendText("Primeiro motor sendo operado!" + "\r\n\r\n");
                    break;
                case 'u':
                    richTextBox_Arduino.AppendText("Segundo motor sendo operado!" + "\r\n\r\n");
                    break;

                case 'Y'://motor2

                    ligarMotor_horizontal = false;
                    on_energizar_horizontal = false;
                    btnLigarHorizontal.Text = "Ligar";
                    btnLigarHorizontal.BackColor = Color.Gainsboro;
                    MessageBox.Show("O motor horizontal parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    break;

                case 'y'://motor1

                    ligarMotor_vertical = false;
                    on_energizar_vertical = false;
                    btnLigarVertical.Text = "Ligar";
                    btnLigarVertical.BackColor = Color.Gainsboro;
                    MessageBox.Show("O motor vertical parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;


                case '/':
                    richTextBox_Arduino.AppendText(texto + "\r\n\r\n");
                    break;

                case 'w':
                    if (motorVertical == true)
                    {
                        richTextBox_Arduino.AppendText("A constante de calibração do motor 1 é:" + texto + "\r\n\r\n");
                    }
                    else
                    {
                        richTextBox_Arduino.AppendText("A constante de calibração do motor 2 é:" + texto + "\r\n\r\n");
                    }

                    break;

                default:
                    richTextBox_Arduino.AppendText(texto + "\r\n\r\n");
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
            try
            {
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

                    if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                    {
                        string inputDistancia2 = richTextBox1.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float distancia_mm2 = float.Parse(inputDistancia2, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        distancia_pulsos2 = (float)Math.Round(distancia_mm2 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label6.Text = "Qtd. Pulsos: " + distancia_pulsos2.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
                    {
                        string inputVelocidade2 = richTextBox2.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float velocidade_mm2 = float.Parse(inputVelocidade2, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label8.Text = "Pulsos/s: " + velocidade_pulsos2.ToString();
                    }

                }
                else if (motorVertical == false)
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

                    if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                    {
                        string inputDistancia1 = richTextBox1.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float distancia_mm1 = float.Parse(inputDistancia1, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label7.Text = "Qtd. Pulsos: " + distancia_pulsos1.ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
                    {
                        string inputVelocidade1 = richTextBox2.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float velocidade_mm1 = float.Parse(inputVelocidade1, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label9.Text = "Pulsos/s: " + velocidade_pulsos1.ToString();
                    }

                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Erro de comunicação com a porta serial: " + ioEx.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Erro de formato nos valores inseridos: " + formatEx.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    catch (UnauthorizedAccessException ex)
                    {
                        // Erro específico para portas não autorizadas
                        MessageBox.Show("Acesso negado à porta serial. Verifique se o dispositivo está conectado corretamente ou se a porta já está em uso.",
                                        "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Erro específico para operação inválida na porta serial
                        MessageBox.Show("A operação não pôde ser completada. Verifique se a porta serial está configurada corretamente e tente novamente.",
                                        "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException ex)
                    {
                        // Erro específico para I/O
                        MessageBox.Show("Falha de comunicação com a porta serial. Certifique-se de que o dispositivo está conectado corretamente.",
                                        "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Erro genérico
                        MessageBox.Show($"Erro inesperado ao enviar comando de parada: {ex.Message}",
                                        "Erro Desconhecido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnEnergizarVertical.Text = "Energizado";
                    btnEnergizarVertical.BackColor = Color.Green;
                    on_energizar_vertical = false;

                }
                else if (on_energizar_vertical == false)
                {
                    if (ligarMotor_vertical == true)
                    {
                        MessageBox.Show("Desligue o motor vertical para desenergizá-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ligarMotor_vertical == false)
                    {
                        try
                        {
                            // Enviar comando para parar o motor
                            serialPort1.Write("a#");
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            // Erro específico para portas não autorizadas
                            MessageBox.Show("Acesso negado à porta serial. Verifique se o dispositivo está conectado corretamente ou se a porta já está em uso.",
                                            "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Erro específico para operação inválida na porta serial
                            MessageBox.Show("A operação não pôde ser completada. Verifique se a porta serial está configurada corretamente e tente novamente.",
                                            "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (IOException ex)
                        {
                            // Erro específico para I/O
                            MessageBox.Show("Falha de comunicação com a porta serial. Certifique-se de que o dispositivo está conectado corretamente.",
                                            "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            // Erro genérico
                            MessageBox.Show($"Erro inesperado ao enviar comando de parada: {ex.Message}",
                                            "Erro Desconhecido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        btnEnergizarVertical.Text = "Desenergizado";
                        btnEnergizarVertical.BackColor = Color.Gainsboro;
                        on_energizar_vertical = true;

                    }

                }
            }
            catch { richTextBox_Arduino.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); }

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
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Acesso negado à porta serial. " +
                                    "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                    "Erro de Acesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("A operação não pôde ser completada. " +
                                    "Verifique se a porta serial está aberta e configurada corretamente.",
                                    "Erro de Operação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Falha de comunicação com o sensor indutivo. " +
                                    "Certifique-se de que o dispositivo está conectado corretamente.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro de Comunicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível iniciar o sensor indutivo. " +
                                    "Uma falha inesperada ocorreu. Por favor, verifique a configuração do dispositivo.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro Desconhecido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
                    string inputDistancia2 = richTextBox1.Text.Replace('.', ',');
                    string inputVelocidade2 = richTextBox2.Text.Replace('.', ',');

                    distancia_mm2 = float.Parse(inputDistancia2, new CultureInfo("pt-BR"));
                    velocidade_mm2 = float.Parse(inputVelocidade2, new CultureInfo("pt-BR"));

                    distancia_pulsos2 = (float)Math.Round(distancia_mm2 / constanteCalibracao1);
                    velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao1);

                    label6.Text = "Qtd. Pulsos: " + distancia_pulsos2.ToString();
                    label8.Text = "Pulsos/s: " + velocidade_pulsos2.ToString();

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
                        catch (UnauthorizedAccessException)
                        {
                            MessageBox.Show("Acesso negado à porta serial. " +
                                            "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                            "Erro de Acesso",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("A operação não pôde ser completada. " +
                                            "Verifique se a porta serial está aberta e configurada corretamente.",
                                            "Erro de Operação",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Falha de comunicação ao tentar parar o motor. " +
                                            "Certifique-se de que o dispositivo está conectado corretamente.\n\n" +
                                            $"Detalhes do erro: {ex.Message}",
                                            "Erro de Comunicação",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi possível parar o motor. " +
                                            "Uma falha inesperada ocorreu. Por favor, verifique a configuração do dispositivo.\n\n" +
                                            $"Detalhes do erro: {ex.Message}",
                                            "Erro Desconhecido",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        btnLigarHorizontal.Text = "Ligar";
                        btnLigarHorizontal.BackColor = Color.Gainsboro;
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
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso negado à porta serial. " +
                                "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                "Erro de Acesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (IOException)
            {
                MessageBox.Show("Falha ao tentar abrir a porta serial. " +
                                "Certifique-se de que o dispositivo está conectado corretamente e tente novamente.",
                                "Erro de Comunicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("O nome da porta serial selecionada é inválido. " +
                                "Por favor, selecione uma porta válida no menu suspenso.",
                                "Erro de Porta Inválida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar à porta serial. " +
                                "Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro Desconhecido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
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
                if (button4.Text == "Conectar")
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    button4.Text = "Desconectar";
                    serialPort1.Open();
                }
                else
                {
                    serialPort1.Close();
                    // Atualizar a lista de portas disponíveis após a desconexão
                    string[] ports = SerialPort.GetPortNames();
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(ports);

                    button4.Text = "Conectar"; // Mantenha o texto do botão em "Conectar"
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso negado à porta serial. " +
                                "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                "Erro de Acesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Falha ao tentar abrir a porta serial. " +
                                "Certifique-se de que o dispositivo está conectado corretamente e tente novamente.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro de Comunicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("O nome da porta serial selecionada é inválido. " +
                                "Por favor, selecione uma porta válida no menu suspenso.",
                                "Erro de Porta Inválida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar à porta serial. " +
                                "Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro Desconhecido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                    if (ligarMotor_horizontal == true)
                    {
                        MessageBox.Show("Desligue o motor horizontal para desenergizá-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ligarMotor_horizontal == false)
                    {
                        serialPort1.Write("a#");
                        btnEnergizarHorizontal.Text = "Desenergizado";
                        btnEnergizarHorizontal.BackColor = Color.Gainsboro;
                        on_energizar_horizontal = true;
                    }
                }
            }
            catch { richTextBox_Arduino.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); }

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


                    serialPort1.Write("T" + distancia_pulsos1 + ";" + velocidade_pulsos1 + ";" + direcao + ";H#");
                    System.Threading.Thread.Sleep(100);
                    if (ligarMotor_vertical == true)
                    {

                        btnLigarVertical.Text = "Ligar";
                        btnLigarVertical.BackColor = Color.Gainsboro;
                        ligarMotor_vertical = false;
                        on_energizar_vertical = false;
                        try
                        {
                            // Enviar comando para parar o motor
                            serialPort1.Write("n#");
                            System.Threading.Thread.Sleep(100);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            MessageBox.Show("Acesso negado à porta serial. " +
                                            "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                            "Erro de Acesso",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("A operação não pôde ser completada. " +
                                            "Verifique se a porta serial está aberta e configurada corretamente.",
                                            "Erro de Operação",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Falha de comunicação ao tentar parar o motor. " +
                                            "Certifique-se de que o dispositivo está conectado corretamente.\n\n" +
                                            $"Detalhes do erro: {ex.Message}",
                                            "Erro de Comunicação",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi possível parar o motor. " +
                                            "Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                            $"Detalhes do erro: {ex.Message}",
                                            "Erro Desconhecido",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
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
            }
            else
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

                    
                    string inputConstanteCalibracao = richTextBox4.Text.Replace('.', ',');

                    constanteCalibracao1 = double.Parse(inputConstanteCalibracao, new CultureInfo("pt-BR"));

                    button1.Text = "Constante de Calibração: " + constanteCalibracao1;
    
                }
                else if (motorVertical == false)
                {

                  
                    string inputConstanteCalibracao = richTextBox4.Text.Replace('.', ',');

                    
                    constanteCalibracao2 = float.Parse(inputConstanteCalibracao, new CultureInfo("pt-BR"));

                

                    button1.Text = "Constante de Calibração: " + constanteCalibracao2;
                    

                }


            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido. Certifique-se de que a constante de calibração é um número válido.",
                                "Erro de Formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("O campo de constante de calibração não pode estar vazio. Preencha o campo antes de continuar.",
                                "Campo Vazio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("A porta serial não está aberta. Conecte-se à porta serial antes de enviar dados.",
                                "Erro de Conexão",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro de comunicação ao tentar enviar dados. Verifique a conexão com o dispositivo.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro de Comunicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                $"Detalhes do erro: {ex.Message}",
                                "Erro Desconhecido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Acesso negado à porta serial. Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                    "Erro de Acesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("A porta serial não está aberta. Conecte-se à porta serial antes de ativar o sensor.",
                                    "Erro de Conexão",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Erro de comunicação ao tentar ativar o sensor indutivo. " +
                                    "Verifique a conexão com o dispositivo.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro de Comunicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível ativar o sensor indutivo. Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro Desconhecido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
            if (ligarMotor_horizontal == true || ligarMotor_vertical == true)
            {
                try
                {
                    // Enviar comando para parar o motor
                    serialPort1.Write("n#");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Acesso negado à porta serial. " +
                                    "Verifique se a porta já está em uso ou se você tem permissão para acessá-la.",
                                    "Erro de Acesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("A operação não pôde ser completada. " +
                                    "Verifique se a porta serial está aberta e configurada corretamente.",
                                    "Erro de Operação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Falha de comunicação ao tentar parar o motor. " +
                                    "Certifique-se de que o dispositivo está conectado corretamente.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro de Comunicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível parar o motor. " +
                                    "Uma falha inesperada ocorreu. Tente novamente.\n\n" +
                                    $"Detalhes do erro: {ex.Message}",
                                    "Erro Desconhecido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox4 != null)
            {
                try
                {
                    if (motorVertical == true)
                    {
                        // Substitui pontos por vírgulas
                        string inputDistancia1 = richTextBox1.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float distancia_mm1 = float.Parse(inputDistancia1, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label7.Text = "Qtd. Pulsos: " + distancia_pulsos1.ToString();
                    }
                    else
                    {
                        string inputDistancia2 = richTextBox1.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float distancia_mm2 = float.Parse(inputDistancia2, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        distancia_pulsos2 = (float)Math.Round(distancia_mm2 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label6.Text = "Qtd. Pulsos: " + distancia_pulsos2.ToString();
                    }
                }
                catch (FormatException)
                {
                    // Se ocorrer uma exceção de formato, exibe uma mensagem de erro
                    if(motorVertical == true)
                    {
                        label7.Text = "Entrada inválida!";
                    }
                    else
                    {
                        label6.Text = "Entrada inválida!";
                    }
                    
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox4 != null)
            {
                try
                {
                    if (motorVertical == true)
                    {
                        // Substitui pontos por vírgulas
                        string inputVelocidade1 = richTextBox2.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float velocidade_mm1 = float.Parse(inputVelocidade1, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label9.Text = "Pulsos/s: " + velocidade_pulsos1.ToString();
                    }
                    else
                    {
                        string inputVelocidade2 = richTextBox2.Text.Replace('.', ',');

                        // Tenta converter a string para float
                        float velocidade_mm2 = float.Parse(inputVelocidade2, new CultureInfo("pt-BR"));

                        // Calcula os pulsos com base no valor convertido
                        velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao1);

                        // Atualiza o label com o valor calculado
                        label8.Text = "Pulsos/s: " + velocidade_pulsos2.ToString();
                    }
                }
                catch (FormatException)
                {
                    // Se ocorrer uma exceção de formato, exibe uma mensagem de erro
                    if(motorVertical == true)
                    {
                        label9.Text = "Entrada inválida!";
                    } else
                    {
                        label8.Text = "Entrada inválida!";
                    }
                    
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição atual do cursor
            int cursorPosition = richTextBox4.SelectionStart;

            // Seleciona todo o texto
            richTextBox4.SelectAll();

            // Centraliza o texto selecionado
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;

            // Remove a seleção e restaura a posição do cursor
            richTextBox4.Select(cursorPosition, 0);
        }

        private void richTextBox4_Click(object sender, EventArgs e)
        {
            // Salva a posição atual do cursor
            int cursorPosition = richTextBox4.SelectionStart;

            // Seleciona todo o texto
            richTextBox4.SelectAll();

            // Centraliza o texto selecionado
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;

            // Remove a seleção e restaura a posição do cursor
            richTextBox4.Select(cursorPosition, 0);
        }

        private void btnEnergizarVertical_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Botao_Painel_subsidencia_Click(object sender, EventArgs e)
        {
            if(Botao_Painel_subsidencia.Text == "Modo subsidência"){
                //Desligando os botões do modo bi-direcional
                panel1.Visible = false;
                panel_subsidencia.Visible = true;
                Botao_Painel_subsidencia.Text = "Modo Bi-Direcional";

            }
            else
            {
                panel1.Visible = true;
                panel_subsidencia.Visible = false;
                Botao_Painel_subsidencia.Text = "Modo subsidência";
            }

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void Solta_motor_Click(object sender, EventArgs e)
        {
            serialPort1.Write("n#");
        }
    }
}
