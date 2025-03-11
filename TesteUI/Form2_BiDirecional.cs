using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;

namespace TesteUI
{
    public partial class Form2_BiDirecional : Form
    {
        //Declaração de variáveis 


        //Variavél de comunicação
        private delegate void d1(string indata);

        // Variáveis para o motor
        string direcao1 = "0";  // direção
        string direcao2 = "0";  // direção
        double distancia_pulsos1;  //Variavel que armazena a quantidade de pulsos que será dado pelo motor vertical
        double distancia_pulsos2;
        double velocidade_pulsos1;
        double velocidade_pulsos2;
        double constanteCalibracao1 = 1;  //A constante de calibração default dos motores que representa a velocidade de aceleração de 2500pulsos/s
        double constanteCalibracao2 = 1;
        bool on_energizar_vertical = true;
        bool on_energizar_horizontal = true;
        bool on_sensor_vertical = false;
        bool on_sensor_horizontal = false;
        bool motorVertical = true;
        bool ligarMotor_vertical = false;
        bool ligarMotor_horizontal = false;
        int motor = 1; // Armazena qual motor está sendo utilizado

        bool on_sensor = false;

        private SerialPort _serialPort;
        public Form2_BiDirecional(SerialPort SerialPort)
        {
            InitializeComponent();

            this._serialPort = SerialPort;

            // Attach the DataReceived event handler here!  IMPORTANT!
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        private void Form2_BiDirecional_Load(object sender, System.EventArgs e)
        {
            // Verifica se a porta serial foi inicializada
            if (_serialPort == null)
            {
                MessageBox.Show("A porta serial não foi inicializada. Conecte-se através do Form1 primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Fecha o Form2 se a porta serial não estiver inicializada
                return;
            }

            // Faça outras inicializações ou configurações aqui, se necessário
        }

        // NEW:  Add this DataReceived event handler in Form2
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadExisting(); // Reads the received data
                //MessageBox.Show(data);
                // Update the graphical interface in the main thread
                this.Invoke(new Action(() => AtualizarInterface(data))); // Use AtualizarInterface here


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing received data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AtualizarInterface(string indata) // como se fosse a função "Write2Form"
        {
            if (InvokeRequired) // Se estiver sendo chamado de uma thread diferente da thread da interface do usuário
            {
                Invoke(new Action<string>(AtualizarInterface), indata); // Chama a si mesmo na thread da interface do usuário
                return;
            }

            // Atualize os controles do Form2 com os dados recebidos
            // This function handles data sent from the arduino

            char g = '/';   //indata[0];
            String texto = "";// Convert.ToString(indata).Substring(1).Replace("#", "");

            switch (g)
            {

                //Algumas mensagens com caracteres especiais
                case 'j':
                    richTextBox_Arduino2.AppendText("Calibração iniciada!\r\n\r\n");
                    break;
                case 'c':
                    richTextBox_Arduino2.AppendText("Direcão motor 1: Para cima\r\n\r\n");
                    break;
                case 'C':
                    richTextBox_Arduino2.AppendText("Direcão motor 2: Para cima\r\n\r\n");
                    break;

                case 'b':
                    richTextBox_Arduino2.AppendText("Direcão motor 1: Para baixo\r\n\r\n");
                    break;
                case 'B':
                    richTextBox_Arduino2.AppendText("Direcão motor 2: Para baixo\r\n\r\n");
                    break;

                case 'a':
                    richTextBox_Arduino2.AppendText("O motor 1 está se movendo com aceleração!\r\n\r\n");
                    break;
                case 'A':
                    richTextBox_Arduino2.AppendText("O motor 2 está se movendo com aceleração!" + "\r\n\r\n");
                    break;

                case 'Q':
                    richTextBox_Arduino2.AppendText("Valor de velocidade inválido! Insira um valor entre 200 e 8000 pulsos/segundo" + "\r\n\r\n");
                    break;

                case 'U':
                    richTextBox_Arduino2.AppendText("Primeiro motor sendo operado!" + "\r\n\r\n");
                    break;
                case 'u':
                    richTextBox_Arduino2.AppendText("Segundo motor sendo operado!" + "\r\n\r\n");
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
                    richTextBox_Arduino2.AppendText(texto + "\r\n\r\n");
                    break;

                case 'w':
                    if (motorVertical == true)
                    {
                        richTextBox_Arduino2.AppendText("A constante de calibração do motor 1 é:" + texto + "\r\n\r\n");
                    }
                    else
                    {
                        richTextBox_Arduino2.AppendText("A constante de calibração do motor 2 é:" + texto + "\r\n\r\n");
                    }

                    break;

                default:
                    richTextBox_Arduino2.AppendText(texto + "\r\n\r\n");
                    break;


            }
            // Exemplo: Adiciona os dados a um RichTextBox
        }

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

        private void richTextBox2_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (richTextBox4 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputVelocidade1 = richTextBox2.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float velocidade_mm1 = float.Parse(inputVelocidade1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);
                    
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (richTextBox4 != null)
            {
                try
                {
                    string inputConstanteCalibracao = richTextBox4.Text.Replace('.', ',');

                    constanteCalibracao1 = double.Parse(inputConstanteCalibracao, new CultureInfo("pt-BR"));
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e) //função pra receber os dados da distancia
        {
            if (richTextBox4 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputDistancia1 = richTextBox1.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float distancia_mm1 = float.Parse(inputDistancia1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);
                }

                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (richTextBox4 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputVelocidade1 = richTextBox5.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float velocidade_mm1 = float.Parse(inputVelocidade1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);

                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (richTextBox4 != null)
            {
                try
                {
                    string inputConstanteCalibracao = richTextBox3.Text.Replace('.', ',');

                    constanteCalibracao1 = double.Parse(inputConstanteCalibracao, new CultureInfo("pt-BR"));
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void richTextBox6_TextChanged(object sender, EventArgs e) //função pra receber os dados da distancia
        {
            if (richTextBox4 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputDistancia1 = richTextBox6.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float distancia_mm1 = float.Parse(inputDistancia1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);
                }

                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLigarVertical_Click(object sender, EventArgs e)
        {
            if (btnDirecaoVerticalBaixo.Checked)
            {
                direcao1 = "B";
            }
            else if (btnDireicaoVerticalCima.Checked)
            {
                direcao1 = "C";
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

                    _serialPort.Write("M#"); // troca para o motor vertical
                    _serialPort.Write("T" + distancia_pulsos1 + ";" + velocidade_pulsos1 + ";" + direcao1 + ";H#");
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
                            _serialPort.Write("n#");
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

        private void btnDireicaoVerticalCima_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEnergizarVertical_Click(object sender, EventArgs e)
        {

            try
            {
                if (on_energizar_vertical)
                {
                    // Send command to the arduino to turn on the enable function of the driver energizing the motor
                    try
                    {
                        // Enviar comando para parar o motor
                        _serialPort.Write("M#"); // troca para o motor vertical
                        _serialPort.Write("A#");
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
                            _serialPort.Write("a#");
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
            catch { richTextBox_Arduino2.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); }

        }

        private void button_parar_vertical_Click(object sender, EventArgs e)
        {

            if (ligarMotor_vertical == true)
            {
                try
                {
                    // Enviar comando para parar o motor
                    _serialPort.Write("M#"); // troca para o motor vertical
                    _serialPort.Write("n#");
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

        private void button_parar_horizontal_Click(object sender, EventArgs e)
        {

            if (ligarMotor_vertical == true)
            {
                try
                {
                    // Enviar comando para parar o motor
                    _serialPort.Write("R#"); // troca para o motor horizontal
                    _serialPort.Write("n#");
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

        private void btnLigarHorizontal_Click(object sender, EventArgs e)
        {
            
            if (btnDirecaoHorizontalBaixo.Checked)
            {
                direcao1 = "B";
            }
            else if (btnDirecaoHorizontalBaixo.Checked)
            {
                direcao1 = "C";
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma direção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerificarTextoValido(richTextBox3) && VerificarTextoValido(richTextBox5) && VerificarTextoValido(richTextBox6))
            {
                try
                {

                    _serialPort.Write("R#"); // troca para o motor horizontal
                    _serialPort.Write("T" + distancia_pulsos2 + ";" + velocidade_pulsos2 + ";" + direcao2 + ";H#");
                    System.Threading.Thread.Sleep(100);
                    if (ligarMotor_horizontal == true)
                    {

                        btnLigarHorizontal.Text = "Ligar";
                        btnLigarHorizontal.BackColor = Color.Gainsboro;
                        ligarMotor_horizontal = false;
                        on_energizar_horizontal = false;
                        try
                        {
                            // Enviar comando para parar o motor
                            _serialPort.Write("n#");
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
                    else if (ligarMotor_horizontal == false)
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

        private void btnEnergizarHorizontal_Click(object sender, EventArgs e)
        {


            try
            {
                if (on_energizar_horizontal)
                {
                    // Send command to the arduino to turn on the enable function of the driver energizing the motor
                    try
                    {
                        // Enviar comando para parar o motor
                        _serialPort.Write("R#"); // troca para o motor horizontal
                        _serialPort.Write("A#");
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
                    btnEnergizarHorizontal.Text = "Energizado";
                    btnEnergizarHorizontal.BackColor = Color.Green;
                    on_energizar_horizontal = false;

                }
                else if (on_energizar_horizontal == false)
                {
                    if (ligarMotor_horizontal == true)
                    {
                        MessageBox.Show("Desligue o motor Horizontal para desenergizá-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ligarMotor_horizontal == false)
                    {
                        try
                        {
                            // Enviar comando para parar o motor
                            _serialPort.Write("a#");
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
                        btnEnergizarHorizontal.Text = "Desenergizado";
                        btnEnergizarHorizontal.BackColor = Color.Gainsboro;
                        on_energizar_horizontal = true;

                    }

                }
            }
            catch { richTextBox_Arduino2.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); }
        }

        private void btnDireicaoHorizontallCima_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}

