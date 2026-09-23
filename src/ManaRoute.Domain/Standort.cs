
namespace ManaRoute.Domain
{
    public sealed record Standort
    {
        public string Plz { get; }
        public string Ort { get; }

        private Standort(string plz, string ort)
        {
            Plz = plz;
            Ort = ort;
        }

        public static StandortErgebnis TryErstellen(string? plz, string? ort)
        {
            if (string.IsNullOrWhiteSpace(plz))
                return new StandortErgebnis.Fehler("PLZ fehlt.");

            if (string.IsNullOrWhiteSpace(ort))
                return new StandortErgebnis.Fehler("Ort fehlt.");

            if (!(plz.Length == 5 && plz.All(char.IsAsciiDigit)))
               return new StandortErgebnis.Fehler($"PLZ hat unerwartetes Format: '{plz}'");

            return new StandortErgebnis.Erfolg(new Standort(plz, ort));
        }

    }
}
