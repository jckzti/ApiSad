using System;
using System.Threading.Tasks;

namespace ApiSad.Interface
{
    public interface ITerritorio
    {
        Decimal PreverTemperaturaAsync(DateTime data);

    }
}
