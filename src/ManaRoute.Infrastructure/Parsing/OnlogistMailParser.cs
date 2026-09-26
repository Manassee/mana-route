
using ManaRoute.Application.Abstractions;
using ManaRoute.Domain;
using System.Text.RegularExpressions;
namespace ManaRoute.Infrastructure.Parsing
{
    public sealed partial class OnlogistMailParser : IAuftragsmailParser
    {
        [GeneratedRegex(@"^Benachrichtigung: Interessanter Auftrag \(ID-# (?<id>\d+)\) von (?<auftraggeber>.+)$")]
        private static partial Regex BetreffMuster();

        // Methode 1: zerlegt nur den Betreff
        internal static Betreffdaten? BetreffZerlegen(string betreff)
        {
            var treffer = BetreffMuster().Match(betreff);

            if (!treffer.Success)
                return null;

            return new Betreffdaten(
                treffer.Groups["id"].Value,
                treffer.Groups["auftraggeber"].Value);
        }

        // Methode 2: der eigentliche Einstiegspunkt
        public ParseErgebnis Parse(EingehendeMail mail)
        {
            var betreffdaten = BetreffZerlegen(mail.Betreff);

            if (betreffdaten is null)
                return new ParseErgebnis.KeineAuftragsmail();

            throw new NotImplementedException("Body-Parsing folgt");
        }
    }
}
