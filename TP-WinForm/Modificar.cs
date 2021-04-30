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
    public partial class Modificar : Form
    {
        public string ID { get; set; }
        
        public Modificar()
        {
            InitializeComponent();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            try
            {
                producto.CodigoArt = txtCodigo.Text;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.UrlImagen = txtUrlImagen.Text;
                producto.Marca = (Marca)cboMarca.SelectedItem;
                producto.Categoria = (Categoria)cboCategoria.SelectedItem;
                producto.Precio = numPrecio.Value;
                productoNegocio.modificar(producto);
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
        public void cargarImagen(string img)
        {
            try
            {
                pbxProducto.Load(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Modificar_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = ID;
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            producto = productoNegocio.listarProducto(ID);
            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            txtUrlImagen.Text = producto.UrlImagen;
            numPrecio.Value = producto.Precio;
            cargarImagen(producto.UrlImagen);

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.Text = producto.Marca.Nombre;
                cboCategoria.DataSource = CategoriaNegocio.listar();
                cboCategoria.Text = producto.Categoria.Nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro que desea cancelar la modificacion del registro?", "Se producira el cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
                Close();
        }
    }
}
