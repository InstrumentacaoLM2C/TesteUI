using System;
using System.Windows.Forms;

namespace TesteUI
{
    public partial class Form2_BiDirecional : Form
    {
        public Form2_BiDirecional()
        {
            InitializeComponent();
        }

        private void btnEnviarDados_Click(object sender, EventArgs e)
        {
            if (SerialPortManager.SerialPort != null && SerialPortManager.SerialPort.IsOpen)
            {
                SerialPortManager.SerialPort.Write("Dados do Form2"); // Exemplo de envio de dados
            }
        }
        private void Form2_BiDirecional_Load(object sender, System.EventArgs e)
        {

        }
    }
}
