using Dsw2025Ej8.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exceptions
{
    internal class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estado) : base($"No se puede operar con la cuenta {estado}") { }
    }
}
