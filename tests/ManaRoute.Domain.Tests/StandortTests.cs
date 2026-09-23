

using Shouldly;

namespace ManaRoute.Domain.Tests
{
    public class StandortTests
    {
       



        [Fact]
        public void TryErstellen_mit_gueltiger_Plz_liefert_Erfolg()
        {
            // Arrange
            var plz = "51143";
            var ort = "Köln";

            // Act
            var ergebnis = Standort.TryErstellen(plz, ort);

            // Assert
            var erfolg = ergebnis.ShouldBeOfType<StandortErgebnis.Erfolg>();
            erfolg.Standort.Plz.ShouldBe("51143");
            erfolg.Standort.Ort.ShouldBe("Köln");
        }


        [Theory]
        [InlineData("123")]
        [InlineData("123456")]
        [InlineData("1234 AB")]
        [InlineData("12a45")]
        public void TryErstellen_mit_ungueltiger_Plz_liefert_Fehler(string plz)
        {
            var ergebnis = Standort.TryErstellen(plz, "Köln");

            var fehler = ergebnis.ShouldBeOfType<StandortErgebnis.Fehler>();
            fehler.Nachricht.ShouldContain(plz);
        }


        [Fact]
        public void TryErstellen_mit_leerer_Plz_liefert_Fehler()
        {
            // Arrange
            var plz = ""; // Leere PLZ
            var ort = "Köln";
            // Act
            var ergebnis = Standort.TryErstellen(plz, ort);
            // Assert
            var fehler = ergebnis.ShouldBeOfType<StandortErgebnis.Fehler>();
            fehler.Nachricht.ShouldContain("Plz");

        }

        [Fact]
        public void TryErstellen_mit_leerem_Ort_liefert_Fehler()
        {
            // Arrange
            var plz = "51143";
            var ort = ""; // Leerer Ort
            // Act
            var ergebnis = Standort.TryErstellen(plz, ort);
            // Assert
            var fehler = ergebnis.ShouldBeOfType<StandortErgebnis.Fehler>();
            fehler.Nachricht.ShouldContain("Ort");


        }

        [Fact]
        public void Zwei_Standorte_mit_gleichen_Werten_sind_gleich()
        {
            // Arrange & Act
            var a = Standort.TryErstellen("51143", "Köln").ShouldBeOfType<StandortErgebnis.Erfolg>().Standort;
            var b = Standort.TryErstellen("51143", "Köln").ShouldBeOfType<StandortErgebnis.Erfolg>().Standort;

            // Assert
            a.ShouldBe(b);
            a.ShouldNotBeSameAs(b);
            a.GetHashCode().ShouldBe(b.GetHashCode());


        }

        [Fact]
        public void Zwei_Standorte_mit_verschiedenen_Werten_sind_ungleich()
        {
            var koeln = Standort.TryErstellen("51143", "Köln").ShouldBeOfType<StandortErgebnis.Erfolg>().Standort;
            var dortmund = Standort.TryErstellen("44145", "Dortmund").ShouldBeOfType<StandortErgebnis.Erfolg>().Standort;

            koeln.ShouldNotBe(dortmund);
        }



    }

}
