

using ManaRoute.Domain;

namespace ManaRoute.Application.Abstractions
{
    public interface IAuftragsmailParser
    {
        ParseErgebnis Parse(EingehendeMail mail);
    }
}
