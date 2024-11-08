using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmbedApplications
{
    public partial class CalculatorForm : Form //Permite que funcione como una ventana de aplicacion
    {// DECLARACION DE FUNCIONES DE LA API DE WINDOWS
        [DllImport("user32.dll")]
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent); //Le decimos que esta ventana sera la ventana padre

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); //Esto es para hubicar la ventana hija dentro de un punto especifico dentro de la ventana padre

        private const int SWP_NOZORDER = 0x0004; //Evita que la ventana cambie en la pila de ventanas
        private const int SWP_NOSIZE = 0x0001; //Indicar que la ventana mantendra un tamaño específico

        public CalculatorForm() //Creamos la clase 
        {
            InitializeComponent(); //COnfiguramos el forumario
            StartCalculator(); // Llamar al método para iniciar el .exe
        }

        private void StartCalculator() //Inicio del método
        {
            // Iniciar la Calculadora
            Process calculatorProcess = new Process(); //Instanciamos el process para inciar el proceso del .exe
            calculatorProcess.StartInfo.FileName = @"D:\Descargas\preccalc-32bit\preccalc.exe"; //Definimos el path
            calculatorProcess.Start(); //Arrancamos el .exe
            calculatorProcess.WaitForInputIdle(); // Esperar a que la ventana esté lista

            // Obtener el manejador de la ventana de la Calculadora
            IntPtr calculatorHandle = calculatorProcess.MainWindowHandle;

            // Establecer la ventana principal como la ventana padre
            SetParent(calculatorHandle, this.Handle);

            // Mover la Calculadora a la esquina superior izquierda
            SetWindowPos(calculatorHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CalculatorForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600); // Tamaño del formulario
            this.Name = "CalculatorForm";
            this.Text = "Calculadora Embebida"; // Título del formulario
            this.ResumeLayout(false);
        }
    }
}
