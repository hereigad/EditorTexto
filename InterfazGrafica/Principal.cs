using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica
{
    public partial class Principal : Form {
        private int contadorHijos;

        public Principal() {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e) {
            Editor hijo = new Editor();
            contadorHijos++;
            hijo.Text = "Documento " + contadorHijos.ToString();
            hijo.MdiParent = this;
            this.ActivateMdiChild(hijo);
            this.toolStripStatusLabel2.Text = hijo.Text;
            hijo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void Principal_MdiChildActivate(object sender, EventArgs e) {
            if(this.ActiveMdiChild != null) {
                this.toolStripStatusLabel2.Text = this.ActiveMdiChild.Text;
            }
        }

        private void ToolStripMenuItem_MouseHover(object sender, EventArgs e) {
            ToolStripMenuItem aux = (ToolStripMenuItem)sender;
            this.toolStripStatusLabel1.Text = aux.Text;
        }

        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e) {
            this.toolStripStatusLabel1.Text = "Ejemplo";
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Title = "Seleccione archivo a abrir";
            abrir.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";
            DialogResult resultado = abrir.ShowDialog();
            if(resultado == DialogResult.OK) {
                Editor hijo = new Editor(abrir.FileName, abrir.FileName);
                contadorHijos++;
                hijo.MdiParent = this;
                this.ActivateMdiChild(hijo);
                this.toolStripStatusLabel2.Text = hijo.Text;
                hijo.Show();
            }
        }

        private void toolStripButton_copiar_Click(object sender, EventArgs e) {
            RichTextBox child = (RichTextBox) this.ActiveMdiChild.Controls[1];
            child.Copy();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            RichTextBox child = (RichTextBox) this.ActiveMdiChild.Controls[1];
            child.Cut();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            RichTextBox child = (RichTextBox) this.ActiveMdiChild.Controls[1];
            child.Paste();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            RichTextBox child = (RichTextBox) this.ActiveMdiChild.Controls[1];
            child.Undo();
        }
    }
}
