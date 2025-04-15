using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;
using System.Threading.Tasks;

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
        double velocidade_mm1, velocidade_mm2, distancia_mm1, distancia_mm2;
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

            if (serialPort == null || !serialPort.IsOpen)
            {
                MessageBox.Show("A porta serial não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _serialPort = serialPort;
            _serialPort.DataReceived += SerialPort_DataReceived;
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
        

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Lê os dados da porta serial
                string data = _serialPort.ReadExisting().Trim();

                // Verifica se contém 'y' e chama a atualização da interface
                if (data.Contains("y"))
                {
                    this.BeginInvoke(new Action(UpdateButton));
                }

                if (data.Contains("Y"))
                {
                    this.BeginInvoke(new Action (UpdateButton2));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na leitura da porta serial: {ex.Message}");
            }
        }

        private void UpdateButton()
        {
            btnLigarVertical.Text = "Ligar";
            btnLigarVertical.BackColor = System.Drawing.Color.Gainsboro;
            MessageBox.Show("O motor vertical parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ligarMotor_vertical = false;
        }

        private void UpdateButton2()
        {
            btnLigarHorizontal.Text = "Ligar";
            btnLigarHorizontal.BackColor = System.Drawing.Color.Gainsboro;
            MessageBox.Show("O motor horizontal parou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ligarMotor_horizontal = false;
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
            
            if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                // Substitui pontos por vírgulas para o formato brasileiro
                string inputVelocidade1 = richTextBox2.Text.Replace('.', ',');

                // Tenta converter a string para float
                if (float.TryParse(inputVelocidade1, NumberStyles.Any, new CultureInfo("pt-BR"), out float velocidade_mm1))
                {
                    // Calcula os pulsos com base no valor convertido
                    if (constanteCalibracao1 != 0)
                        velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Define valores padrão caso o campo fique vazio
                velocidade_pulsos1 = 0;
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
    
            if (!string.IsNullOrWhiteSpace(richTextBox4.Text))
            {
                // Substitui pontos por vírgulas para o formato brasileiro
                string inputConstanteCalibracao1 = richTextBox4.Text.Replace('.', ',');

                // Tenta converter a string para double
                if (double.TryParse(inputConstanteCalibracao1, NumberStyles.Any, new CultureInfo("pt-BR"), out double valorConvertido))
                {
                    constanteCalibracao1 = valorConvertido; // Atualiza apenas se a conversão for bem-sucedida

                    // Agora recalcula as variáveis de distância e velocidade com a nova constante de calibração
                    RecalcularDistanciaEVelocidade();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                constanteCalibracao1 = 1; // Define um valor padrão quando o campo está vazio

                // Recalcula as variáveis de distância e velocidade com o valor padrão
                RecalcularDistanciaEVelocidade();
            }
        }

        private void RecalcularDistanciaEVelocidade()
        {
            // Recalcula os pulsos de distância e velocidade com a nova constante de calibração
            if (constanteCalibracao1 != 0)
            {
                distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);
                distancia_pulsos2 = (float)Math.Round(distancia_mm2 / constanteCalibracao1);
                velocidade_pulsos1 = (float)Math.Round(velocidade_mm1 / constanteCalibracao1);
                velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao1);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) //função pra receber os dados da distancia
        {
            
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                // Substitui pontos por vírgulas para o formato brasileiro
                string inputDistancia1 = richTextBox1.Text.Replace('.', ',');

                // Tenta converter a string para float
                if (float.TryParse(inputDistancia1, NumberStyles.Any, new CultureInfo("pt-BR"), out float distancia_mm1))
                {
                    // Calcula os pulsos com base no valor convertido
                    if (constanteCalibracao1 != 0)
                        distancia_pulsos1 = (float)Math.Round(distancia_mm1 / constanteCalibracao1);

                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Define valores padrão caso o campo fique vazio
                distancia_pulsos1 = 0;
          
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (!string.IsNullOrWhiteSpace(richTextBox5.Text))
            {
                // Substitui pontos por vírgulas para o formato brasileiro
                string inputVelocidade2 = richTextBox5.Text.Replace('.', ',');

                // Tenta converter a string para float
                if (float.TryParse(inputVelocidade2, NumberStyles.Any, new CultureInfo("pt-BR"), out float velocidade_mm2))
                {
                    // Calcula os pulsos com base no valor convertido
                    if (constanteCalibracao2 != 0)
                        velocidade_pulsos2 = (float)Math.Round(velocidade_mm2 / constanteCalibracao2);
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Define valores padrão caso o campo fique vazio
                velocidade_pulsos2 = 0;
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)//função pra receber os dados da constante de calibração
        {
            if (richTextBox3 != null)
            {
                try
                {
                    string inputConstanteCalibracao = richTextBox3.Text.Replace('.', ',');

                    constanteCalibracao2 = double.Parse(inputConstanteCalibracao, new CultureInfo("pt-BR"));
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
            if (!string.IsNullOrWhiteSpace(richTextBox6.Text))
            {
                // Substitui pontos por vírgulas para o formato brasileiro
                string inputDistancia2 = richTextBox6.Text.Replace('.', ',');

                // Tenta converter a string para float
                if (float.TryParse(inputDistancia2, NumberStyles.Any, new CultureInfo("pt-BR"), out float distancia_mm2))
                {
                    // Calcula os pulsos com base no valor convertido
                    if (constanteCalibracao2 != 0)
                        distancia_pulsos2 = (float)Math.Round(distancia_mm2/ constanteCalibracao2);

                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Define valores padrão caso o campo fique vazio
                distancia_pulsos2 = 0;

            }
        }

        private async void btnLigarVertical_Click(object sender, EventArgs e)
        {
            // Verifica a direção do motor vertical
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

            // Verifica se os valores são válidos
            if (!VerificarTextoValido(richTextBox1) || !VerificarTextoValido(richTextBox2))
            {
                MessageBox.Show("Por favor, insira valores válidos para distância e velocidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLigarVertical.Enabled = false; // Evita múltiplos cliques

            try
            {
                await Task.Run(async () =>
                {
                    // Envia comandos iniciais para preparar o motor
                    EnviarComandoSerial("M#");

                    string comando = $"T{distancia_pulsos1.ToString(CultureInfo.InvariantCulture)};" +
                                     $"{velocidade_pulsos1.ToString(CultureInfo.InvariantCulture)};" +
                                     $"{direcao1};H#";

                    EnviarComandoSerial(comando);

                    Console.WriteLine($"Comando Enviado: {comando}");

                    // Se já estava ligado, envia comando para parar
                    if (ligarMotor_vertical)
                    {
                        EnviarComandoSerial("n#");
                        Console.WriteLine("Comando Enviado: n# (Parar motor)");
                    }
                });

                // Atualiza a interface (thread principal)
                this.Invoke((Action)(() =>
                {
                    if (ligarMotor_vertical)
                    {
                        btnLigarVertical.Text = "Ligar";
                        btnLigarVertical.BackColor = Color.Gainsboro;
                        ligarMotor_vertical = false;
                        on_energizar_vertical = false;
                        MessageBox.Show("O motor vertical parou.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btnLigarVertical.Text = "Ligado";
                        btnLigarVertical.BackColor = Color.Green;
                        ligarMotor_vertical = true;
                        on_energizar_vertical = true;
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar comando: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLigarVertical.Enabled = true;
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
                    EnviarComandoSerial("M#"); // Seleciona motor vertical
                    EnviarComandoSerial("A#"); // Liga ENABLE do Driver

                    btnEnergizarVertical.Text = "Energizado";
                    btnEnergizarVertical.BackColor = Color.Green;
                    on_energizar_vertical = false;
                }
                else
                {
                    if (ligarMotor_vertical)
                    {
                        MessageBox.Show("Desligue o motor vertical antes de desenergizá-lo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    EnviarComandoSerial("a#"); // Desliga ENABLE do Driver

                    btnEnergizarVertical.Text = "Desenergizado";
                    btnEnergizarVertical.BackColor = Color.Gainsboro;
                    on_energizar_vertical = true;
                }
            }
            catch
            {
                richTextBox_Arduino2.AppendText("Algum valor está faltando. Tente novamente!\r\n\r\n");
            }
        }

        // Método para envio de comandos pela porta serial com tratamento de erros
        private void EnviarComandoSerial(string comando)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                MessageBox.Show("A porta serial não está aberta. Verifique a conexão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _serialPort.Write(comando);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso negado à porta serial. Verifique se o dispositivo está conectado corretamente ou se a porta já está em uso.",
                                "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("A operação não pôde ser completada. Verifique se a porta serial está configurada corretamente e tente novamente.",
                                "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Falha de comunicação com a porta serial. Certifique-se de que o dispositivo está conectado corretamente.",
                                "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao enviar comando: {ex.Message}",
                                "Erro Desconhecido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button_parar_vertical_Click(object sender, EventArgs e)
        {
            if (!ligarMotor_vertical)
            {
                MessageBox.Show("O motor já está parado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                button_parar_vertical.Enabled = false; // Desativa o botão enquanto executa o comando

                await Task.Run(() =>
                {
                    // Enviar comando para parar o motor
                    _serialPort.Write("n#");
                    Console.WriteLine("Comando Enviado: n#");
                });

                // Atualiza a UI na thread principal
                this.Invoke((Action)(() =>
                {
                    ligarMotor_vertical = false;
                    btnLigarVertical.Text = "Ligar";
                    btnLigarVertical.BackColor = Color.Gainsboro;

                    MessageBox.Show("O motor foi parado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
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
            finally
            {
                button_parar_vertical.Enabled = true; // Reativa o botão após a execução
            }
        }

        private async void button_parar_horizontal_Click(object sender, EventArgs e)
        {
            if (!ligarMotor_horizontal)
            {
                MessageBox.Show("O motor já está parado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                button_parar_horizontal.Enabled = false; // Desativa o botão enquanto executa o comando

                await Task.Run(() =>
                {
                    // Enviar comando para parar o motor
                    _serialPort.Write("n#");
                    Console.WriteLine("Comando Enviado: n#");
                });

                // Atualiza a UI na thread principal
                this.Invoke((Action)(() =>
                {
                    ligarMotor_horizontal = false;
                    btnLigarHorizontal.Text = "Ligar";
                    btnLigarHorizontal.BackColor = Color.Gainsboro;

                    MessageBox.Show("O motor foi parado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
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
            finally
            {
                button_parar_horizontal.Enabled = true; // Reativa o botão após a execução
            }
        }

        private async void btnLigarHorizontal_Click(object sender, EventArgs e)
        {
            if (btnDirecaoHorizontalBaixo.Checked)
            {
                direcao2 = "B";
            }
            else if (btnDireicaoHorizontallCima.Checked)
            {
                direcao2 = "C";
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma direção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se os valores são válidos
            if (!VerificarTextoValido(richTextBox5) || !VerificarTextoValido(richTextBox6))
            {
                MessageBox.Show("Por favor, insira valores válidos para distância e velocidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLigarHorizontal.Enabled = false; // Evita múltiplos cliques

            try
            {
                await Task.Run(async () =>
                {
                    // Envia comandos iniciais para preparar o motor
                    EnviarComandoSerial("R#");

                    string comando = $"T{distancia_pulsos2.ToString(CultureInfo.InvariantCulture)};" +
                                     $"{velocidade_pulsos2.ToString(CultureInfo.InvariantCulture)};" +
                                     $"{direcao2};H#";

                    EnviarComandoSerial(comando);

                    Console.WriteLine($"Comando Enviado: {comando}");

                    // Se já estava ligado, envia comando para parar
                    if (ligarMotor_horizontal)
                    {
                        EnviarComandoSerial("n#");
                        Console.WriteLine("Comando Enviado: n# (Parar motor)");
                    }
                });

                // Atualiza a interface (thread principal)
                this.Invoke((Action)(() =>
                {
                    if (ligarMotor_horizontal)
                    {
                        btnLigarHorizontal.Text = "Ligar";
                        btnLigarHorizontal.BackColor = Color.Gainsboro;
                        ligarMotor_horizontal = false;
                        on_energizar_horizontal = false;
                        MessageBox.Show("O motor horizontal parou.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btnLigarHorizontal.Text = "Ligado";
                        btnLigarHorizontal.BackColor = Color.Green;
                        ligarMotor_horizontal = true;
                        on_energizar_horizontal = true;
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar comando: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLigarHorizontal.Enabled = true;
            }
        }

        private void btnEnergizarHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                if (on_energizar_horizontal)
                {
                    EnviarComandoSerial("R#"); // Seleciona motor vertical
                    EnviarComandoSerial("A#"); // Liga ENABLE do Driver

                    btnEnergizarHorizontal.Text = "Energizado";
                    btnEnergizarHorizontal.BackColor = Color.Green;
                    on_energizar_horizontal = false;
                }
                else
                {
                    if (ligarMotor_horizontal)
                    {
                        MessageBox.Show("Desligue o motor vertical antes de desenergizá-lo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    EnviarComandoSerial("a#"); // Desliga ENABLE do Driver

                    btnEnergizarHorizontal.Text = "Desenergizado";
                    btnEnergizarHorizontal.BackColor = Color.Gainsboro;
                    on_energizar_horizontal = true;
                }
            }
            catch
            {
                richTextBox_Arduino2.AppendText("Algum valor está faltando. Tente novamente!\r\n\r\n");
            }
        }

        private void btnDirecaoHorizontalBaixo_CheckedChanged(object sender, EventArgs e)
        {

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

