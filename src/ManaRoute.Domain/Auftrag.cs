

namespace ManaRoute.Domain
{
    public sealed record Auftrag(

        string OnlogistId,
        string Auftraggeber,
        Standort Abholort,
        Standort Zielort,
        DateTime? AbholungAb,
        DateTime? LieferungBis,
        decimal? Preis,
        DateTimeOffset Eingegangen
       );
}
