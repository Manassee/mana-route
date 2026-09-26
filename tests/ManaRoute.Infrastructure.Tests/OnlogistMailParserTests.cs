using ManaRoute.Application.Abstractions;
using ManaRoute.Domain;
using ManaRoute.Infrastructure.Parsing;
using Shouldly;

namespace ManaRoute.Infrastructure.Tests
{
    public class OnlogistMailParserTests
    {
        private readonly OnlogistMailParser _parser = new();

        [Fact]
        public void Mail_ohne_passenden_Betreff_ist_keine_Auftragsmail()
        {
            var mail = new EingehendeMail(
                Betreff: "Ihre Rechnung für September",
                TextBody: "Sehr geehrter Kunde, anbei Ihre Rechnung.",
                Empfangen: DateTimeOffset.Now);

            var ergebnis = _parser.Parse(mail);

            ergebnis.ShouldBeOfType<ParseErgebnis.KeineAuftragsmail>();
        }
    }
}
