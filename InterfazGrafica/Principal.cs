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

        private void ToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            ToolStripMenuItem aux = (ToolStripMenuItem)sender;
            this.toolStripStatusLabel1.Text = aux.Text;
        }

        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Ejemplo";
        }
    }
}
