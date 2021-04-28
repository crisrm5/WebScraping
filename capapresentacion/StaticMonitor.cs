using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capapresentacion
{
    public static class StaticMonitor
    {
        public static List<(Process, string)> monitor = new List<(Process, string)>();
        public static string rutaManual = "";
    }
}
