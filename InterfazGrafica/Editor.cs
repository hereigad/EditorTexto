using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica {
    public partial class Editor : Form {
        public Editor() {
            InitializeComponent();
        }

        public Editor(string name, string path) {
            InitializeComponent();
            this.Text = name;
            this.richTextBox1.LoadFile(path, RichTextBoxStreamType.PlainText);
        }

        private void button1_Click(object sender, EventArgs e) {
            string mensaje = "Desea cerrar el documento?";
            string caption = "Cerrando";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult cerrar = MessageBox.Show(mensaje, caption, botones);
            if(cerrar == DialogResult.Yes) {
                this.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e) {
            if(System.IO.File.Exists(this.Text)) {
                this.richTextBox1.SaveFile(this.Text, RichTextBoxStreamType.PlainText);
                this.richTextBox1.Modified = false;
            } 
            else {
                this.guardarComoToolStripMenuItem.PerformClick();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Title = "Seleccione el archivo a guardar";
            guardar.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";
            DialogResult resultado = guardar.ShowDialog();
            if(resultado == DialogResult.OK) {
                this.richTextBox1.SaveFile(guardar.FileName, RichTextBoxStreamType.PlainText);
                this.richTextBox1.Modified = false;
            }
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            if(this.richTextBox1.Modified == true) {
                DialogResult cerrar = MessageBox.Show("¿Quieres cerrar sin guardar?", "Aviso", MessageBoxButtons.YesNo);
                if (cerrar == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }
    }
}
