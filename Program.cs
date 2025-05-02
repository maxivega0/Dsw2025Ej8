using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var titulares1 = new string[] { "Juan Pérez" };
            var titulares2 = new string[] { "Ana Gómez" };

            var caja1 = new CajaDeAhorro("CA001", 1000m, titulares1) { TasaDeInteres = 0.05m };
            var caja2 = new CajaDeAhorro("CA002", 500m, titulares2) { TasaDeInteres = 0.03m };

            var cc1 = new CuentaCorriente("CC001", 2000m, titulares1) { LimiteDeDescubierto = 500m, Comision = 0.01m };
            var cc2 = new CuentaCorriente("CC002", 300m, titulares2) { LimiteDeDescubierto = 300m, Comision = 0.02m };

            try
            {
                caja1.Depositar(200m);
                caja1.Retirar(100m);
                caja1.AplicarIntereses();
                cc1.Depositar(1000m);
                cc1.Retirar(2500m);
            }
            catch (SaldoInsuficienteException)
            {
                Console.WriteLine($"Saldo insuficiente en {cc1.Numero}");
            }

            try
            {
                caja2.Retirar(400m);
                caja2.AplicarIntereses();
                cc2.Retirar(700m);
            }
            catch (SaldoInsuficienteException saldoInsuficiente)
            {
                Console.WriteLine($"{saldoInsuficiente.Message} ({caja2.Numero})");

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
                    Saldo = cuenta.Saldo
                };

                Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }
            Console.ReadLine();

        }
    }
}
