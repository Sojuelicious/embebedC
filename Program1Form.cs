using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmbedApplications
{
    public partial class Program1Form : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOSIZE = 0x0001;

        public Program1Form()
        {
            InitializeComponent();
            StartExplorer();
        }

        private void StartExplorer()
        {
            // Iniciar el Explorador de Archivos
            Process explorerProcess = new Process();
            explorerProcess.StartInfo.FileName = @"C:\Program Files (x86)\Everything\Everything.exe"; // Ruta al explorador de Windows
            explorerProcess.Start();
            explorerProcess.WaitForInputIdle(); // Esperar a que el Explorador esté listo

            // Obtener el manejador de la ventana del Explorador
            IntPtr explorerHandle = explorerProcess.MainWindowHandle;

            // Establecer el formulario como padre
            SetParent(explorerHandle, this.Handle);

            // Mover la ventana del Explorador a la posición del formulario
            SetWindowPos(explorerHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program1Form
            // 
            this.ClientSize = new System.Drawing.Size(800, 600); // Tamaño del formulario
            this.Name = "Program1 Form";
            this.Text = "Programa Numero 1 embebido"; // Título del formulario
            this.ResumeLayout(false);
        }
    }
}
