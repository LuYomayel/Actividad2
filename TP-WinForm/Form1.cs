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

namespace Presentacion
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)dgw.CurrentRow.DataBoundItem;
            ProductoNegocio productoNegocio = new ProductoNegocio();
            productoNegocio.eliminar(seleccionado);
            MessageBox.Show("Eliminado correctamente.");
            cargarLista();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cargarLista()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                listaProductos = productoNegocio.listar();
                dgw.DataSource = listaProductos;

                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                dgw.Columns["UrlImagen"].Visible = false;


                RecargarImg(listaProductos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RecargarImg(string img)
        {
            
            try
            {
                pBox.Load(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            Producto seleccionado = (Producto)dgw.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.ShowDialog();
            cargarLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)dgw.CurrentRow.DataBoundItem;

            Modificar modificar = new Modificar();
            modificar.ID = seleccionado.CodigoArt;
            modificar.ShowDialog();
            cargarLista();
        }
    }
}
