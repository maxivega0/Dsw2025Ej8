using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Titulares = titulares;
        Estado = Estado.Activa;
    }

    public virtual void Depositar(decimal monto)
    {
        ValidarCuenta();
        ValidarMonto(monto);
        Saldo += monto;
    }
    public virtual void Retirar(decimal monto)
    {
        ValidarCuenta();
        ValidarMonto(monto);
        if (Saldo - monto < 0)
        {
            throw new SaldoInsuficienteException();
        }
        else
        {
            Saldo -= monto;
        }
    }
    protected void ValidarMonto(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValidoException();
        }
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActivaException(Estado);
        }
    }

    protected void ValidarCuenta()
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActivaException(Estado);
        }
    }

}
