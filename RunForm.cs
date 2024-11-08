using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EmbedApplications
{
    public partial class RunForm : Form
    {
        public RunForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(12, 12);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(260, 20);
            this.textBoxCommand.TabIndex = 0;
            this.textBoxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyDown);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(197, 38);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Ejecutar";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // RunForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxCommand);
            this.Name = "RunForm";
            this.Text = "Ejecutar";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
        }

        private void textBoxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Permite ejecutar el comando con Enter
            {
                ExecuteCommand();
            }
        }

        private void ExecuteCommand()
        {
            string command = textBoxCommand.Text;
            if (!string.IsNullOrEmpty(command))
            {
                try
                {
                    Process.Start(command); // Ejecutar el comando ingresado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar el comando: " + ex.Message);
                }
            }
        }

        private TextBox textBoxCommand;
        private Button buttonRun;
    }
}
