using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; init; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }

    protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }

    protected void ValidarOperacion(decimal monto) 
    {
        if (monto <= 0) 
        {
            throw new MontoNoValidoException();
        }
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActivaException(Estado);
        }
        if (Saldo - monto < 0 )
        {
            throw new SaldoInsuficienteException();
        }
    }

    public virtual void Depositar(decimal monto)
    {      
            Saldo += monto;
    }
    public virtual void Retirar(decimal monto)
    {
      
            Saldo -= monto;
       
    }
    
}
