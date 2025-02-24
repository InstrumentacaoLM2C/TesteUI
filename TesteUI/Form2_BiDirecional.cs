using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Ports;

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
        public Form2_BiDirecional(SerialPort serialPort)
        {
            InitializeComponent();

            this._serialPort = serialPort;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Write("Dados do Form2"); // Exemplo de envio de dados
            }
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

            if (VerificarTextoValido(richTextBox1) && VerificarTextoValido(richTextBox2) && _serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    

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
            catch { richTextBox_Arduino.AppendText("Algum valor está faltando. Tente novamente!" + "\r\n\r\n"); }

        }

    }
}

