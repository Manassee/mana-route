

namespace ManaRoute.Domain
{
    public abstract record ParseErgebnis
    {
        public sealed record Erfolg(Auftrag Auftrag) : ParseErgebnis;
        public sealed record KeineAuftragsmail : ParseErgebnis;
        public sealed record Unlesbar(string Grund) : ParseErgebnis;

        private ParseErgebnis()
        {
        }
    }
}
