using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
            validar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void validar()
        {
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtUrlImagen.Text == "") btnAceptar.Enabled = false;
            else btnAceptar.Enabled = true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
