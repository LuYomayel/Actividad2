using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm
{
    class Producto
    {
        //Código de artículo.
        //Nombre.
        //Descripción.
        //Marca(seleccionable de una lista desplegable).
        //Categoría(seleccionable de una lista desplegable.
        //Imagen.
        //Precio.
        public string CodigoArt { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public decimal Precio { get; set; }


    }
}
