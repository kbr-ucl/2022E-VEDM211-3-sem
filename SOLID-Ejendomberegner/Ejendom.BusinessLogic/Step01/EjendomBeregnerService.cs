// ReSharper disable All
namespace Ejendom.BusinessLogic.Step01;

// Step 1.
// Udflyt fil indlæsning. I forbindelse med udflytningen af indlæs bliver det klart, at det vil være en fordel,
// at introducere en model klasse til at indeholde ejendoms oplysningerne

public class EjendomBeregnerService
{
    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    /// </summary>
    /// <param name="lejemaalDataFilename"></param>
    /// <returns></returns>
    public double BeregnKvadratmeter(string lejemaalDataFilename)
    {
        var ejendomRepository = new EjendomRepository();
        var kvadratmeter = 0.0;


        foreach (var lejemaal in ejendomRepository.ReadEjendoms(lejemaalDataFilename))
        {

            kvadratmeter += lejemaal.Kvadratmeter;
        }

        return kvadratmeter;
    }
}


/// <summary>
///     Indlæs ejendommens lejelmål.
///     Lejemål er i en kommasepareret tekstfil. Formatet af filen er:
///     "lejlighednummer", "kvadratmeter", "antal rum"
///     lejlighednummer: int
///     kvadratmeter: double
///     antal rum: double
/// </summary>
public class EjendomRepository
{
    public IEnumerable<EjendomEntity> ReadEjendoms(string lejemaalDataFilename)
    {
        var lejemaalene = File.ReadAllLines(lejemaalDataFilename);

        foreach (var lejemaal in lejemaalene)
        {
            var lejemaalParts = lejemaal.Split(',');
            int.TryParse(RemoveQuotes(lejemaalParts[0]), out var lejlighednummer);
            double.TryParse(RemoveQuotes(lejemaalParts[1]), out var kvadratmeter);
            double.TryParse(RemoveQuotes(lejemaalParts[2]), out var antalRum);

            yield return new EjendomEntity
                {AntalRum = antalRum, Kvadratmeter = kvadratmeter, Lejlighednummer = lejlighednummer};
        }
    }

    private string RemoveQuotes(string lejemaalPart)
    {
        return lejemaalPart.Replace('"', ' ').Trim();
    }
}

public class EjendomEntity
{
    public int Lejlighednummer { get; set; }
    public double  Kvadratmeter { get; set; }
    public double  AntalRum { get; set; }
}