using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP4
{
    public class Nodo
    {
        public int Cuenta { get; set; }  
        public DateTime Fecha { get; set; }  
        public int TipoMovimiento { get; set; }  
        public int Importe { get; set; }  
        public int CodigoSucursal { get; set; }  
        public Nodo Siguiente { get; set; } 

        public Nodo()
        {
            Cuenta = 0;
            Fecha = DateTime.Now.Date;
            TipoMovimiento = 0;
            Importe = 0;
            CodigoSucursal = 0;
            Siguiente = null;
        }
    }
}
