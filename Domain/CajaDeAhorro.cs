using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria
{
    public CajaDeAhorro(string numero, decimal saldo, TipoCuenta tipo, string[] titulares) : base (numero, saldo, titulares){
        TasaDeInteres = 0.02m; // 2% de interés 
    }
    public void Depositar(decimal monto)
    {
        ValidarOperacion(monto);
        Saldo += monto;
    }
}
