
namespace ManaRoute.Domain          
{
    public abstract record StandortErgebnis
    {
        public sealed record Erfolg(Standort Standort) : StandortErgebnis;
        public sealed record Fehler(string Nachricht) : StandortErgebnis;

        private StandortErgebnis()
        {
        }
    }
}
