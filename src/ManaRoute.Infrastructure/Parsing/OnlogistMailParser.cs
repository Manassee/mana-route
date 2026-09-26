
using ManaRoute.Application.Abstractions;
using ManaRoute.Domain;
using System.Text.RegularExpressions;
namespace ManaRoute.Infrastructure.Parsing
{
    public sealed partial class OnlogistMailParser : IAuftragsmailParser
    {

        [GeneratedRegex(@"^Benachrichtigung: Interessanter Auftrag \(ID-# (?<id>\d+)\) von (?<auftraggeber>.+)$")]
        private static partial Regex BetreffMuster();

        public ParseErgebnis Parse(EingehendeMail mail)
        {
            var treffer = BetreffMuster().Match(mail.Betreff);

            if (!treffer.Success)
                return new ParseErgebnis.KeineAuftragsmail();

            var id = treffer.Groups["id"].Value;                      // "2565560"
            var auftraggeber = treffer.Groups["auftraggeber"].Value;  // "finn GmbH"
            throw new NotImplementedException("Auftragsmail-Parsing folgt");
        }
    }
}
