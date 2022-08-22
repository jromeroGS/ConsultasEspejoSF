using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cliente
    {
        string codigoCliente;
        string nombre;

        public Cliente(string codigoCliente, string nombre)
        {
            this.codigoCliente = codigoCliente;
            this.nombre = nombre;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.codigoCliente);
            sb.AppendLine(this.nombre);
            return sb.ToString();
        }

      
        public string Codigo
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }

    }
}

