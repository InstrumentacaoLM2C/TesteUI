using System;
// SerialPortManager.cs
using System.IO.Ports;

namespace TesteUI // Certifique-se de que o namespace corresponde ao seu projeto
{
    public static class SerialPortManager
    {
        public static SerialPort SerialPort { get; set; } // Propriedade estática
    }
}