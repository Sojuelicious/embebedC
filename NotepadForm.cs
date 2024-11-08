using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmbedApplications
{
    public partial class NotepadForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOSIZE = 0x0001;

        public NotepadForm()
        {
            InitializeComponent();
            StartNotepad(); // Llamar al método para iniciar el Bloc de Notas
        }

        private void StartNotepad()
        {
            // Iniciar el Bloc de Notas
            Process notepadProcess = new Process();
            notepadProcess.StartInfo.FileName = "notepad.exe";
            notepadProcess.Start();
            notepadProcess.WaitForInputIdle(); // Esperar a que la ventana esté lista

            // Obtener el manejador de la ventana del Bloc de Notas
            IntPtr notepadHandle = notepadProcess.MainWindowHandle;

            // Establecer la ventana principal como la ventana padre
            SetParent(notepadHandle, this.Handle);

            // Mover el Bloc de Notas a la esquina superior izquierda
            SetWindowPos(notepadHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NotepadForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600); // Tamaño del formulario
            this.Name = "NotepadForm";
            this.Text = "Bloc de Notas Embebido"; // Título del formulario
            this.ResumeLayout(false);
        }
    }
}
