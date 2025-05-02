using Dsw2025Ej8.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; init; }
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares){}
    public override void Depositar( decimal monto)
    {
        ValidarCuenta();
        ValidarMonto(monto);
        monto -= monto * Comision;
        Saldo += monto;
    }

    public override void Retirar(decimal monto)
    {
        ValidarCuenta();
        ValidarMonto(monto);
        if (Saldo - monto >= -LimiteDeDescubierto)
        {
            Saldo -= monto;
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
        else
        {
            Estado = Estado.Suspendida;
            throw new SaldoInsuficienteException();
        }
    }
}
