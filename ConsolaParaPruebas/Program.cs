using ClassLibrary1;
using Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolaParaPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cliente unCliente = Controller.LeerPorId("'0063Z00000ou0YQQAY'");
                //Cliente unCliente = Controller.LeerPorId(Text1.Value);
                Console.WriteLine(unCliente.Mostrar());
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
        }
    }
}
