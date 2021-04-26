﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria from ARTICULOS as A inner join Marcas as M on M.ID = A.IdMarca inner join CATEGORIAS as C on C.Id = A.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.CodigoArt = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marca((string)datos.Lector["Marca"]);
                    aux.Categoria = new Categoria((string)datos.Lector["Categoria"]);

                    lista.Add(aux);
                }
                
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + nuevo.CodigoArt + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.UrlImagen + "', " + nuevo.Marca.Id + ", " + nuevo.Categoria.Id + "  ," + nuevo.Precio + ")";
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) " + valores);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //string valores = "values( '" + nuevo.CodigoArt + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.UrlImagen + "', " + nuevo.Marca.Id + ", " + nuevo.Categoria.Id + "  ," + nuevo.Precio + ")";
                datos.setearConsulta("update ARTICULOS set codigo = '" + nuevo.CodigoArt + "', nombre = '" + nuevo.Nombre + "',Descripcion = '" + nuevo.Descripcion + "', ImagenUrl = '" + nuevo.UrlImagen + "', precio = " + nuevo.Precio + ", idmarca = '" + nuevo.Marca.Id + "' , idcategoria = '" + nuevo.Categoria.Id + "' where codigo = '" + nuevo.CodigoArt + "'");

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Producto listarProducto(string ID)
        {
            Producto producto = new Producto();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria from ARTICULOS as A inner join Marcas as M on M.ID = A.IdMarca inner join CATEGORIAS as C on C.Id = A.IdCategoria where A.Codigo = '" + ID + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];
                    producto.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    producto.Marca = new Marca((string)datos.Lector["Marca"]);
                    producto.Categoria = new Categoria((string)datos.Lector["Categoria"]);

                    
                }

                return producto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void eliminar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("delete from Articulos where codigo = '" + nuevo.CodigoArt + "'");

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
