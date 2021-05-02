using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP_WinForm
{
    public partial class AltaCategoria : Form
    {
        public AltaCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro que desea cancelar ?", "Se producira el cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
                Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            CategoriaNegocio categorianegocio = new CategoriaNegocio();

            try
            {

                Categoria aux = new Categoria();
                aux.Nombre = txtNombre.Text;

                categorianegocio.agregar(aux);
                MessageBox.Show("agregado sin problema");


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
        }
    }
}
