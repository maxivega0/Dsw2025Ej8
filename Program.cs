using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var titulares1 = new string[] { "Juan Pérez" };
            var titulares2 = new string[] { "Ana Gómez" };

            var caja1 = new CajaDeAhorro("001", 1000m, titulares1) { TasaDeInteres = 0.05m };
            var caja2 = new CajaDeAhorro("002", 500m, titulares2) { TasaDeInteres = 0.03m };

            var cc1 = new CuentaCorriente("003", 2000m, titulares1) { LimiteDeDescubierto = 500m, Comision = 0.01m };
            var cc2 = new CuentaCorriente("004", 300m, titulares2) { LimiteDeDescubierto = 300m, Comision = 0.02m };

            OperacionBancaria(caja1.Numero, () => { caja1.Depositar(-200m); });
            OperacionBancaria(caja1.Numero, () => { caja1.Depositar(200m); caja1.Retirar(100m);caja1.AplicarIntereses(); });
            OperacionBancaria(caja2.Numero, () => { caja2.Retirar(400m); caja2.AplicarIntereses(); });
            OperacionBancaria(cc1.Numero, () => { cc1.Depositar(1000m); cc1.Retirar(2500m); });
            OperacionBancaria(cc2.Numero, () => { cc2.Retirar(700m); });

            void OperacionBancaria(string numeroCuenta, Action operacion)
            {
                try
                {
                    operacion();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n Error en la cuenta {numeroCuenta}: {ex.Message}");
                }
            }

            var cuentas = new List<CuentaBancaria> { caja1, caja2, cc1, cc2 };

            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n== Resumen de cuentas ==");

            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name.Equals("CajaDeAhorro") ? "Caja de Ahorro" : "Cuenta Corriente",
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado
                };

                Console.WriteLine($"Número: {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: {resumen.Saldo:C} | Estado {resumen.Estado}");
            }
            Console.ReadLine();

        }
    }
}
