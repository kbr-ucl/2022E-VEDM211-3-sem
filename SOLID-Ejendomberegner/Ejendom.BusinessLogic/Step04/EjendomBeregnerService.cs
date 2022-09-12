// ReSharper disable All
namespace Ejendom.BusinessLogic.Step04;

// Step 4.
// Clean up af "EjendomBeregnerService" , således den ikke kender filnavnet
// Inversion of control - "Du skal kun være afhængig af et interface"
// Endeligt gøres metoderne i EjendomBeregnerService "Explicit" for at gennemtvinge IoC.

public interface IEjendomBeregnerService
{
    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    /// </summary>
    /// <returns></returns>
    public double BeregnKvadratmeter();
}

public class EjendomBeregnerService : IEjendomBeregnerService
{
    private readonly IEjendomRepository _ejendomRepository;

    public EjendomBeregnerService(IEjendomRepository ejendomRepository)
    {
        _ejendomRepository = ejendomRepository;
    }

    double IEjendomBeregnerService.BeregnKvadratmeter()
    {
        var kvadratmeter = 0.0;

        foreach (var lejemaal in _ejendomRepository.ReadEjendoms())
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
    public IEnumerable<EjendomEntity> ReadEjendoms();
}

public class EjendomRepository : IEjendomRepository
{
    private readonly string _lejemaalDataFilename;

    public EjendomRepository(string lejemaalDataFilename)
    {
        _lejemaalDataFilename = lejemaalDataFilename;
    }

    IEnumerable<EjendomEntity> IEjendomRepository.ReadEjendoms()
    {
        var lejemaalene = File.ReadAllLines(_lejemaalDataFilename);

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