using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmbedApplications
{
    public partial class Program2Form : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOSIZE = 0x0001;

        public Program2Form()
        {
            InitializeComponent();
            StartCMD(); // Llamar al método para iniciar CMD
        }

        private void StartCMD()
        {
            // Iniciar el CMD (Símbolo del sistema)
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = @"C:\Program Files (x86)\Notepad++\notepad++.exe";
            cmdProcess.Start();
            cmdProcess.WaitForInputIdle(); // Esperar a que la ventana esté lista

            // Obtener el manejador de la ventana de CMD
            IntPtr cmdHandle = cmdProcess.MainWindowHandle;

            // Establecer la ventana principal como la ventana padre
            SetParent(cmdHandle, this.Handle);

            // Mover el CMD a la esquina superior izquierda
            SetWindowPos(cmdHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program2Form
            // 
            this.ClientSize = new System.Drawing.Size(800, 600); // Tamaño del formulario
            this.Name = "Program2Form";
            this.Text = "CMD Embebido"; // Título del formulario
            this.ResumeLayout(false);
        }
    }
}
