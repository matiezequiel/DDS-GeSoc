﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual.Egresos
{
    static class GeneradorDeLogs
    {
        public static BitacoraDeOperaciones bitacora;

        static public void agregarLogABitacora(string log)
        {
            bitacora.logs.Add(new Log(log, DateTime.UtcNow));
        }
    }
}