﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class ProveedorDAO
    {
        public static ProveedorDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private ProveedorDAO() { }

        public static ProveedorDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new ProveedorDAO();
            }

            return instancia;
        }

        #region Funciones
        public Proveedor getProveedorById(int id)
        {
            using (var context = new BaseDeDatos())
            {
                return context.proveedores.Single(e => e.id_prov == id);
            }
        }

        public Proveedor getProveedorByCUIT(string CUIT)
        {
            using (var context = new BaseDeDatos())
            {
                return context.proveedores.SingleOrDefault(e => e.CUIT == CUIT);
            }
        }

        public List<Proveedor> getAllProveedor()
        {
            using (var context = new BaseDeDatos())
            {
                return context.proveedores.ToList<Proveedor>();
            }
        }

        public ProveedorDAO Add(Proveedor e)
        {
            using (var context = new BaseDeDatos())
            {
                context.proveedores.Add(e);
            }
            return this;
        }

        #endregion
    }
}