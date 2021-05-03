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
    public partial class Altas : Form
    {
  
        public Altas()
        {
            InitializeComponent();
        }
        public bool ValidarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("hay campos vacios");

                return false;


            }
            else

            {

                return true;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro que desea cancelar ?", "Se producira el cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
                Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcanegocio = new MarcaNegocio();

            try
            {
                bool campos;
                campos = ValidarCampos();
                Marca aux = new Marca();
                 aux.Nombre = txtNombre.Text;
                if (campos!=false)
                {
                    marcanegocio.agregar(aux);
                    MessageBox.Show("agregado sin problema");
                }
               


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
        }
    }
}
