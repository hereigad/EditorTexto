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
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
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
    }
}
