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
            CbxClave.Items.Add("Codigo");
            CbxClave.Items.Add("Nombre");
            CbxClave.Items.Add("Precio");
            CbxClave.SelectedIndex = 0;
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
                dgw.Columns["id"].Visible = false;
                dgw.Columns["UrlImagen"].Visible = false;
                dgw.Columns["Descripcion"].Visible = false;
                dgw.Columns["Categoria"].Visible = false;



                RecargarImg(listaProductos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarListafiltrada()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();


            try
            {
               

                listaProductos = productoNegocio.listarFiltrado(txtBuscar.Text.Trim(), CbxClave.SelectedItem.ToString(), CbxCriterio.SelectedItem.ToString());
                if (listaProductos.Count == 0)
                {
                    MessageBox.Show("No hay registros con ese filtro ");
                    cargarLista();
                    
                }
                else
                dgw.DataSource = listaProductos;

                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                dgw.Columns["id"].Visible = false;
                dgw.Columns["UrlImagen"].Visible = false;
                dgw.Columns["Descripcion"].Visible = false;
                dgw.Columns["Categoria"].Visible = false;




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

            Modificar modificar = new Modificar(seleccionado);
            modificar.ShowDialog();
            cargarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text !="")
                {
                    cargarListafiltrada();
                   
                }
                else
                    MessageBox.Show("El texto filtro no puede estar vacio");
                txtBuscar.BackColor = Color.Red;
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)dgw.CurrentRow.DataBoundItem;

            Detalle detalle = new Detalle();
            detalle.ID = seleccionado.CodigoArt;
            detalle.ShowDialog();
            cargarLista();
        }

        private void CbxClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbxCriterio.Items.Clear();
            if (CbxClave.SelectedItem.ToString() == "Precio")
            {
                CbxCriterio.Items.Add("Mayor a");
                CbxCriterio.Items.Add("Menor a");
                CbxCriterio.Items.Add("Igual a");
            }
            else
            {

                CbxCriterio.Items.Add("Comienza con");
                CbxCriterio.Items.Add("Contiene");
                CbxCriterio.Items.Add("Termina con");
            }
            CbxCriterio.SelectedIndex = 0;

        }

        

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender; // investigar
            if (tb.Text.Length == 0)
                tb.BackColor = Color.Red;
            else
                tb.BackColor = System.Drawing.SystemColors.Window;
        }
    }
}