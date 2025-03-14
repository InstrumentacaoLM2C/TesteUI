using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace TesteUI
{
    public partial class Form1 : Form
    {
        private Form2_BiDirecional form2;
        private Form3_Universal form3;


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

        public event EventHandler<string> OnDataReceived;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 


        }

        private void UpdateRichTextBox(string data)
        {
           
        }

        private void InitializeSerialPort()
        {

        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
        }


        public void SendData(string data)
        {
            if (serialPort1 != null && serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Write(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 115200;
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
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadExisting(); // Lê os dados recebidos

                // Atualiza a interface gráfica na thread principal
                this.Invoke(new Action(() => richTextBox3.AppendText(data)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar dados recebidos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click_3(object sender, EventArgs e)
        {
            try
            {
                if (button4.Text == "Conectar")
                {
                    //serialPort1.PortName = comboBox1.Text;
                    //serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();

                    string PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.BaudRate = 115200;
                    serialPort1.DtrEnable = true;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.ReadBufferSize = 4096;

                    serialPort1.DataReceived += serialPort1_DataReceived;

                    serialPort1.Open();
                    Timer1.Start();
                    SerialPortManager.SerialPort = serialPort1;
                    button4.Text = "Desconectar";

                }
                else
                {
                    Timer1.Stop();
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

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Lê os dados recebidos
                string indata = serialPort1.ReadExisting();

                // Notifica os outros formulários sobre os dados recebidos
                OnDataReceived?.Invoke(this, indata);

                // Atualiza a interface do usuário de forma segura
                this.Invoke(new Action(() => UpdateRichTextBox(indata)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            

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
           
        }

        private void richTextBox1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
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
            if (serialPort1 == null || !serialPort1.IsOpen)
            {
                MessageBox.Show("Por favor, conecte-se à porta serial antes de abrir o Modo Falhas.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe Form2_BiDirecional
            using (Form2_BiDirecional form2 = new Form2_BiDirecional(serialPort1))
            {
                form2.ShowDialog(); // Abre o Form2 como modal, garantindo que a execução aguarde
            }
        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            if (serialPort1 == null || !serialPort1.IsOpen)
            {
                MessageBox.Show("Por favor, conecte-se à porta serial antes de abrir o Modo Falhas.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                serialPort1.Write("m#"); // Envia o comando para trocar para motores simultâneos

                using (Form3_Universal form3 = new Form3_Universal(this.serialPort1))
                {
                    form3.ShowDialog(); // Exibe o Form3 de forma modal
                }
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


        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void Solta_motor_Click(object sender, EventArgs e)
        {

            serialPort1.Write("K#");
        }

        private void richTextBox_Arduino_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel_Falhas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
