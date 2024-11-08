//Importamos las librerias alv, sino como pinches va a funcionar 
using System; //Proporciona tipos básicos y funcionalidades comunes de .NET. le decimos que use lo basico para funcionar
using System.Diagnostics; //Permite ejecutar y controlar otros procesos. es decir que pueda ejecutar los sabrosisimos .exe
using System.Runtime.InteropServices; //Permite llamar a funciones externas de Windows. Ya los puede ejecutar pero tambien debe poder llamarlos sino como pinches los va a brir alv
using System.Windows.Forms; //esta mmda es para decirle que utilice ventanitas nada mas, creo equisde

namespace EmbedApplications //aqui le decimos que inicie un espacio que se llamara "embebedapplication" es decir como se llamara nuestro verguleo programita
{
    public partial class Form1 : Form //Aqui esta pdjada hereda de Form, es decir que pueda hcer programitas asi bien sexis
    {
        [DllImport("user32.dll")] //Aqui le damos permisos o le decimos que pueda interactuar con el resto de windows
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent); //aqui declaramos que nuestro programa lomo plateado pueda incrustar una ventana dentro de tora, como incrustaba a.. aaa T_T ya nada, olvidalo T^T

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); //Aqui le decimos al prgramita que nos deje cambiar el tamaño de las ventanas con el mouse. para que este tan grande o pequeña como lo prefieras bb

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOSIZE = 0x0001;

        public Form1() //Constructor de la clase Form1, que se ejecuta al crear el formulario. Llama a InitializeComponent() para configurar el diseño y luego a InitializeUI() para configurar los botones.
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI() //desde aqui comienza la magia aqui inicamos la interfaz y ordenamos los botones alv
        {
            // Crear un FlowLayoutPanel para organizar los botones en una columna
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown, // Los botones se alinean de arriba hacia abajo, ni modo que de abajo hacia arriba, piensale papi, ponte vgas
                WrapContents = false, // Evitar que los botones se vayan a la siguiente columna, porque los muy desgraciados se ponen uno al ladito del otro, hay que agarrarlos
                AutoSize = true, // Hacer que el panel ajuste su tamaño automáticamente
                AutoSizeMode = AutoSizeMode.GrowAndShrink, // Asegura que el panel se ajuste al tamaño de los botones
                Padding = new Padding(10), // Añadir margen a los bordes del panel
                Height = 300, // Limitar la altura del panel para evitar que los botones se desborden
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, // Anclar al contenedor superior
                Location = new System.Drawing.Point((ClientSize.Width - 200) / 2, 20) // Centrado horizontalmente
            };

            // Crear los botones
            CreateNotepadButton(panel);   // Crear el botón para el Bloc de Notas
            CreateCalculatorButton(panel); // Crear el botón para la Calculadora
            CreateProgram2Form(panel);        // Crear el botón abrir notepad++
            CreateRunButton(panel);        // Crear el botón para "Ejecutar"
            CreateProgram1Form(panel);   // Crear el botón para abrir el program everything
            CreateProgram3Form(panel);   // Crear el botón para abrir el program everything

            // En InitializeUI, se llama a CreateCalculatorButton, un método que se encarga de crear y configurar el botón de la calculadora. Este botón será parte del FlowLayoutPanel, lo que organiza todos los botones en una columna dentro del formulario.

            Controls.Add(panel); // Añadir el FlowLayoutPanel al formulario
        }

        private void CreateNotepadButton(FlowLayoutPanel panel)
        {
            Button openNotepadButton = new Button
            {
                Text = "Abrir Bloc de Notas",
                Width = 180, // Ancho de los botones
                Height = 40, // Altura de los botones
                Margin = new Padding(10) // Separación entre los botones
            };

            openNotepadButton.Click += OpenNotepadButton_Click;
            panel.Controls.Add(openNotepadButton); // Añadir el botón al panel
        }

        private void CreateCalculatorButton(FlowLayoutPanel panel)
        {
            Button openCalculatorButton = new Button //Aqui le decimso que nos cree un pinche bonto bien sabroso ALV que rico
            {
                Text = "Abrir Calculadora",
                Width = 180, //añadir un ancho al boton (Como te gustan xd)
                Height = 40, //Añadir un alto al boton
                Margin = new Padding(10) //Añadimos un espacio entre los botones
            };

            openCalculatorButton.Click += OpenCalculatorButton_Click; //Añadir evento, el segundo parametro es el nombre del archivo .cs, es decir que le diga al pendejo programa que abra el archivo .cs donde esta la pinche perra y sabrosa logica alv
            panel.Controls.Add(openCalculatorButton); //Esta parte es la que "pinta" el boton en el formulari principal, porque solo se creo y el programa todo pendejo necesita que le digamos que lo mueste (No querra que hagamos una corrida manual tambien alv que ya haga su chamba el lenguaje todo meco)
        }

        private void CreateProgram2Form(FlowLayoutPanel panel)
        {
            Button openCMDButton = new Button
            {
                Text = "Abrir Notepad++",
                Width = 180,
                Height = 40,
                Margin = new Padding(10)
            };

            openCMDButton.Click += OpenCMDButton_Click;
            panel.Controls.Add(openCMDButton);
        }

        private void CreateRunButton(FlowLayoutPanel panel)
        {
            Button openRunButton = new Button
            {
                Text = "Ejecutar",
                Width = 180,
                Height = 40,
                Margin = new Padding(10)
            };

            openRunButton.Click += OpenRunButton_Click;
            panel.Controls.Add(openRunButton);
        }

        private void CreateProgram1Form(FlowLayoutPanel panel)
        {
            Button openExplorerButton = new Button
            {
                Text = "Abrir Everything",
                Width = 180,
                Height = 40,
                Margin = new Padding(10)
            };

            openExplorerButton.Click += OpenProgram1Form_Click;
            panel.Controls.Add(openExplorerButton);
        }

        private void CreateProgram3Form(FlowLayoutPanel panel)
        {
            Button openExplorerButton = new Button
            {
                Text = "Abrir CMD",
                Width = 180,
                Height = 40,
                Margin = new Padding(10)
            };

            openExplorerButton.Click += OpenProgram3Form_Click;
            panel.Controls.Add(openExplorerButton);
        }

        private void OpenNotepadButton_Click(object sender, EventArgs e)
        {
            NotepadForm notepadForm = new NotepadForm();
            notepadForm.Show();
        }

        private void OpenCalculatorButton_Click(object sender, EventArgs e) //Metodo que se ejecuta cuando el usuario hace click en el boton de la calculadora
        {
            // Se crea una nueva instancia de CalculatorForm (CalculatorForm calculatorForm = new CalculatorForm();), que es el formulario encargado de embeber la aplicación de calculadora externa.
            CalculatorForm calculatorForm = new CalculatorForm();

            //Se llama a calculatorForm.Show(); para mostrar el formulario CalculatorForm como una nueva ventana "CalculatorForm" es el archivo.cs
            calculatorForm.Show();
        }

        private void OpenCMDButton_Click(object sender, EventArgs e)
        {
            Program2Form program2Form = new Program2Form();
            program2Form.Show();
        }

        private void OpenRunButton_Click(object sender, EventArgs e)
        {
            RunForm runForm = new RunForm();
            runForm.Show();
        }

        private void OpenProgram1Form_Click(object sender, EventArgs e)
        {
            Program1Form program1Form = new Program1Form(); // Crear el formulario de Program1
            program1Form.Show(); // Mostrar el formulario
        }
        private void OpenProgram3Form_Click(object sender, EventArgs e)
        {
            Program3Form program3Form = new Program3Form(); // Crear el formulario de Program1
            program3Form.Show(); // Mostrar el formulario
        }
    }
}
