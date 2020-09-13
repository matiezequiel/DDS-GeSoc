﻿using System;
using TP_Anual.Egresos;
using TP_Anual.Administrador_Inicio_Sesion;
using Quartz;
using TP_Anual.Organizaciones;

namespace TP_Anual
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BaseDeDatos())
            {

                Item item1 = new Item();
                item1.valor = 20000;
                item1.descripcion = "Galaxy 8";
                context.items.Add(item1);
                context.SaveChanges();

                EntidadJuridica entidad = new EntidadJuridica();
                Console.WriteLine($"Categoria: {entidad.tipoOrganizacion.categoria}");

                DocumentoComercial doc = new DocumentoComercial();
                doc.tipo = "ticket";

                Egreso egreso = new Egreso();
                egreso.fecha = DateTime.Today;
                egreso.cantPresupuestos = 2;
                egreso.documentoComercial = doc;
                egreso.medioDePago = new MedioDePago("tarjeta", "debito");
                egreso.bandejaDeMensajes = new BandejaDeMensajes("Grupo 5");
                egreso.criterioDeSeleccion = new MenorValor();

                Proveedor proveedor1 = new Proveedor();
                //proveedor1.CUIT = 20305006501;
                proveedor1.razon_social = "razon1";
                Proveedor proveedor2 = new Proveedor();
                //proveedor2.CUIT = 20305006502;
                proveedor2.razon_social = "razon2";


                Item item2 = new Item();
                item2.valor = 25000;
                item2.descripcion = "Galaxy 9";
                Item item3 = new Item();
                item3.valor = 35000;
                item3.descripcion = "Galaxy 10";
                Item item4 = new Item();
                item4.valor = 42000;
                item4.descripcion = "Galaxy 10 Plus";

                Presupuesto presupuesto1 = new Presupuesto();
                presupuesto1.documentoComercial = doc;
                presupuesto1.proveedor = proveedor1;
                Presupuesto presupuesto2 = new Presupuesto();
                presupuesto2.documentoComercial = doc;
                presupuesto2.proveedor = proveedor2;

                presupuesto1.agregar_item(item1);
                presupuesto1.agregar_item(item2);

                presupuesto2.agregar_item(item3);
                presupuesto2.agregar_item(item4);

                egreso.agregarPresupuesto(presupuesto1);
                egreso.agregarPresupuesto(presupuesto2);
                egreso.elegirPresupuesto(presupuesto1);

                InterfazInicioDeSesion interfaz = new InterfazInicioDeSesion();
                string usuarioActual;

                Console.WriteLine("Ingresar usuario: ");
                usuarioActual = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine("1. Validar Compra // 2. Ver validacion // 3. Fin");
                    var eleccion = Console.ReadLine();

                    if (eleccion == "1")
                        ValidadorDeEgreso.egresoValido(egreso);

                    if (eleccion == "2")
                        egreso.bandejaDeMensajes.mostrarMensajes(usuarioActual);

                    if (eleccion == "3")
                        break;

                }

            }
            

            /*
            void jobValidadorEgreso(Scheduler sched)
            {
                JobDataMap jobData = new JobDataMap();
                jobData.Add("egreso", egreso);

                IJobDetail jobValidadorEgreso = JobBuilder.Create<JobValidadorEgresos>()
                    .WithIdentity("trabajoValidacionEgreso", "grupoValidacionEgreso")
                    .UsingJobData(jobData)
                    .Build();

                ITrigger triggerValidadorEgreso = TriggerBuilder.Create()
                    .WithIdentity("tiempoValidacionEgreso", "grupoValidacionEgreso")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                    .Build();

                sched.agregarTarea(jobValidadorEgreso, triggerValidadorEgreso);


            }

            */
            //Console.WriteLine(egreso.valorTotal);

            //BandejaDeMensajes.mostrarMensajes();

            //usuarioActual = interfaz.inicioDeSesion();
            //Console.WriteLine(usuarioActual);
            //con ese usuario, el validador se fija si es el usuario que puede ver la compra

        }
    }
}
