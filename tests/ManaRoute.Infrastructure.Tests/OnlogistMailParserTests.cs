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


        [Fact]
        public void BetreffZerlegen_mit_unpassendem_Betreff_liefert_null()
        {
            var daten = OnlogistMailParser.BetreffZerlegen("Ihre Rechnung für September");

            daten.ShouldBeNull();
        }



        [Fact]
        public void BetreffZerlegen_liefert_Id_und_Auftraggeber()
        {
            var betreff = "Benachrichtigung: Interessanter Auftrag (ID-# 2565560) von finn GmbH";

            var daten = OnlogistMailParser.BetreffZerlegen(betreff);

            daten.ShouldNotBeNull();
            daten.OnlogistId.ShouldBe("2565560");
            daten.Auftraggeber.ShouldBe("finn GmbH");
        }
    }
}
