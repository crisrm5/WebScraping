using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capapresentacion
{
    class Monitores
    {
        private Process[] monitorEjecutandose = new Process[] { };
        private string[] ruta = new string[] { };

        public Monitores()
        {
        }

        public Monitores(Process monitorEjecutandose, string ruta)
        {

            this.MonitorEjecutandose.Append<Process>(monitorEjecutandose);
            this.Ruta.Append<String>(ruta);
        }


        public Process[] MonitorEjecutandose { get => monitorEjecutandose; set => monitorEjecutandose = value; }
        public string[] Ruta { get => ruta; set => ruta = value; }
    }
}
