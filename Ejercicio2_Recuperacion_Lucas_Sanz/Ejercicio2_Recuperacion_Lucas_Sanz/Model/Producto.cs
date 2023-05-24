﻿using Ejercicio2_Recuperacion_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ejercicio2_Recuperacion_Lucas_Sanz.Model
{
    public class Producto
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string coste { get; set; }
        public string precio { get; set; }
        public string observaciones { get; set; }
        public ManageProducto manager = new ManageProducto();

        public Producto(string codigo, string descripcion, string coste, string precio, string observaciones)
        {
            coste = coste.Replace(",", ".");
            precio = precio.Replace(",", ".");

            this.codigo = codigo;
            this.descripcion = descripcion;
            this.coste = coste;
            this.precio = precio;
            this.observaciones = observaciones;
        }

        public void insertarProducto()
        {
            manager.insertarProducto(this);
        }
        public void eliminarProducto()
        {
            manager.eliminarProducto(this);
        }
        public void modificarProducto()
        {
            manager.modificarProducto(this);
        }
    }
}