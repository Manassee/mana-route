

namespace ManaRoute.Domain
{
    public sealed record EingehendeMail(
        
        string Betreff,
        string TextBody,
        DateTimeOffset Empfangen
    );
}
