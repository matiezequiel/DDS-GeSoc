﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("presupuesto")]
    public class Presupuesto
    {
        [Key]
        [Column("id_presupuesto")]
        public int id_presupuesto { get; set; }

        [Column("id_documento_comercial")]
        public int id_documento_comercial { get; set; }
        public DocumentoComercial documentoComercial { get; set; }
        public List<ItemPorPresupuesto> itemsDePresupuesto { get; set; }

        [Column("id_prov")]
        public int id_prov { get; set; }
        public Proveedor proveedor { get; set; }
        
        [Column("valor_total")]
        public int valor_total { get; set; }

        
        //Agregado para ORM
        [Column("id_egreso")]
        public int id_egreso { get; set; }
        public Egreso egreso { get; set; }

     

        public Presupuesto()
        {
            itemsDePresupuesto = new List<ItemPorPresupuesto>();
        }

        public void calcular_total()
        {
            valor_total = itemsDePresupuesto.Sum(items => items.valor);
        }

        public void agregar_item(ItemPorPresupuesto Item)
        {
            itemsDePresupuesto.Add(Item);
            valor_total = itemsDePresupuesto.Sum(items => items.valor);
        }
    }
}
