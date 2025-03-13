using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteUI
{
    public partial class Form3_Universal : Form
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
        bool on_sensor_vertical = false;
        bool on_sensor_horizontal = false;
        bool motorVertical = true;
        bool ligarMotor_vertical = false;
        int motor = 1; // Armazena qual motor está sendo utilizado

        bool on_sensor = false;

        private SerialPort _serialPort;

            public Form3_Universal(SerialPort serialPort)
            {
                InitializeComponent();

                if (serialPort == null)
                {
                    MessageBox.Show("A porta serial não foi fornecida. Conecte-se através do Form1 primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); // Fecha o Form3 se a porta serial não for fornecida
                    return;
                }

                this._serialPort = serialPort;

                // Inscreve o evento DataReceived
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }

            private void Form3_Universal_Load(object sender, EventArgs e)
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    MessageBox.Show("A porta serial não está inicializada ou não está aberta. Conecte-se através do Form1 primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); // Fecha o Form3 se a porta serial não estiver inicializada ou aberta
                    return;
                }
            }

            private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadExisting(); // Lê os dados recebidos

                // Atualiza a interface gráfica na thread principal
                if (!IsDisposed && richTextBox_Arduino2.IsHandleCreated && btnLigarVertical.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string>(AtualizarInterface), data); // Usa AtualizarInterface aqui
                }
            }
            catch (Exception ex)
            {
                // Log de erro mais detalhado
                string errorMessage = $"Error processing received data: {ex.Message}\nStack Trace: {ex.StackTrace}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AtualizarInterface(string indata)
        {
            // Verifica se o formulário ou controles foram descartados
            if (IsDisposed || richTextBox_Arduino2.IsDisposed || btnLigarVertical.IsDisposed)
            {
                return; // Sai do método se o formulário ou controles não existirem mais
            }

            // Processa os dados recebidos
            if (indata.Contains("y")) // Verifica se o caractere 'y' está presente
            {
                ligarMotor_vertical = false;
                on_energizar_vertical = false;
                btnLigarVertical.Text = "Ligar";
                btnLigarVertical.BackColor = Color.Gainsboro;
                MessageBox.Show("O motor vertical parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Exemplo: Adiciona os dados a um RichTextBox
            richTextBox_Arduino2.AppendText(indata + Environment.NewLine);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEnergizarVertical_Click(object sender, EventArgs e)
        {
            try
            {

                if (on_energizar_vertical == true)
                {
                    // Send command to the arduino to turn on the enable function of the driver energizing the motor
                    try
                    {
                        // Enviar comando para ligar o motor
                        _serialPort.Write("A#");
                        System.Threading.Thread.Sleep(100);
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
                        MessageBox.Show("Pare os motores antes de desenergizá-los", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ligarMotor_vertical == false)
                    {
                        try
                        {
                            // Enviar comando para parar o motor
                            _serialPort.Write("a#");
                            System.Threading.Thread.Sleep(100);
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
            catch { 
                
                richTextBox_Arduino2.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); 
           
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnLigarVertical_Click(object sender, EventArgs e)
        {
            // Verifica a direção selecionada
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

            // Verifica se os valores de distância e velocidade são válidos
            if (VerificarTextoValido(richTextBox1) && VerificarTextoValido(richTextBox2))
            {
                try
                {

                    _serialPort.Write("W" + distancia_pulsos1 + ";" + velocidade_pulsos1 + ";" + distancia_pulsos2 + ";" + velocidade_pulsos2 + ";" + direcao1 + ";H#");
                    System.Threading.Thread.Sleep(100);

                    if (ligarMotor_vertical == true)
                    {
                        
                        btnLigarVertical.Text = "Ligar";
                        btnLigarVertical.BackColor = Color.Gainsboro;
                        on_energizar_vertical = false;
                        ligarMotor_vertical = false;
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

                    // Pequeno delay para garantir que o comando seja processado
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
            else
            {
                MessageBox.Show("Por favor, selecione valores válidos para distância e velocidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void button_parar_vertical_Click(object sender, EventArgs e)
        {

            if (ligarMotor_vertical == true)
            {
                try
                {
                    // Enviar comando para parar o motor
                 
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

            } else if (ligarMotor_vertical == false)
            {
                MessageBox.Show("O motor já está parado.", "Erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox4 != null)
            {
                try
                {
                    string inputConstanteCalibracao1 = richTextBox4.Text.Replace('.', ',');

                    constanteCalibracao1 = double.Parse(inputConstanteCalibracao1, new CultureInfo("pt-BR"));
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox3 != null)
            {
                try
                {
                    string inputConstanteCalibracao2 = richTextBox3.Text.Replace('.', ',');

                    constanteCalibracao2 = double.Parse(inputConstanteCalibracao2, new CultureInfo("pt-BR"));
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox4 != null && richTextBox3 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputVelocidade1 = richTextBox2.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float velocidade_mm1 = float.Parse(inputVelocidade1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);

                    // Calcula os pulsos com base no valor convertido
                    velocidade_pulsos2 = (float)Math.Round(velocidade_mm1 / constanteCalibracao2);

                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox4 != null && richTextBox3 != null)
            {
                try
                {
                    // Substitui pontos por vírgulas
                    string inputDistancia1 = richTextBox1.Text.Replace('.', ',');

                    // Tenta converter a string para float
                    float distancia_mm1 = float.Parse(inputDistancia1, new CultureInfo("pt-BR"));

                    // Calcula os pulsos com base no valor convertido
                    distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);

                    distancia_pulsos2 = (float)Math.Round(distancia_mm1 / constanteCalibracao2);
                }

                catch (Exception ex)
                {
                    // Captura qualquer outra exceção que possa ocorrer
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
