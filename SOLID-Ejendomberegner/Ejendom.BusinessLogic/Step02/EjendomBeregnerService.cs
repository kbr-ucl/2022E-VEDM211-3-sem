// ReSharper disable All
namespace Ejendom.BusinessLogic.Step02;

// Step 2.
// Inversion of control - "Du skal kun være afhængig af et interface"
// Samtidig flyttes dependencies til constructoren ("New is Glue" princippet)
// Endeligt gøres metoderne i EjendomRepository "Explicit" for at gennemtvinge IoC.

public class EjendomBeregnerService
{
    private readonly IEjendomRepository _ejendomRepository;

    public EjendomBeregnerService(IEjendomRepository ejendomRepository)
    {
        _ejendomRepository = ejendomRepository;
    }

    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    /// </summary>
    /// <param name="lejemaalDataFilename"></param>
    /// <returns></returns>
    public double BeregnKvadratmeter(string lejemaalDataFilename)
    {
        var kvadratmeter = 0.0;


        foreach (var lejemaal in _ejendomRepository.ReadEjendoms(lejemaalDataFilename))
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
public interface IEjendomRepository
{
    public IEnumerable<EjendomEntity> ReadEjendoms(string lejemaalDataFilename);
}

public class EjendomRepository : IEjendomRepository
{
    IEnumerable<EjendomEntity> IEjendomRepository.ReadEjendoms(string lejemaalDataFilename)
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