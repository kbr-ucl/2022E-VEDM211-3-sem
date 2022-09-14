# 2022E-VEDM211-3-sem
## BmiWebApplication
Indeholder
- BMI beregner 101
- [Validating User Input in Razor Pages](https://www.learnrazorpages.com/razor-pages/validation)
- Unittest demo (UnitTest101)
- SOLID-Ejendomberegner
- IoC-Demo-01
- IoC-Demo-02
- Beregner-IoCdemo



### SOLID-Ejendomberegner

Formålet er at gøre "EjendomBeregnerService" testbar og robust.

Refactoreringen Indeholder sammen kode i mange steps

- Step 1 - Udflyt fil indlæsning
- Step 2 - Inversion of control - "Du skal kun være afhængig af et interface"
- Step 3 - Unittest af "EjendomBeregnerService" er nu en let sag med et Mock objekt
- Step 4 - Clean up af "EjendomBeregnerService" , således den ikke kender filnavnet
- Step 5 - Brug af Moq til at lave test Mock objekter



### IoC-Demo-01 og IoC-Demo-02
IoC Demo 01 er "klassisk" kode med en tæt kobling, hvor Service projektet kender Helper projektet. Bemærk en hårde kobling med "new" der danner en direkte dependency (new is glue).

```c#
public class MyService
{
    public void DoService()
    {
        var helper = new MyHelper();
        helper.DoHelp();
    }
}
```



IoC Demo 02 viser inversion of control, hvor Service projektet IKKE kender Helper projektet. Her er det Helper projektet der kender Service projektet. Herudover er Helper objektet "injected" i Service constructoren (hvorved der opstår en aggregate)

```c#
public class MyService
{
    private readonly IMyHelper _helper;

    public MyService(IMyHelper helper)
    {
        _helper = helper;
    }
    public void DoService()
    {
        _helper.DoHelp();
    }
}
```


### Beregner-IoCdemo
Et meget simpelt eksempel med constructor injection af en beregner sevice i en Razor Page


### CleanDemo1
Eksempel på en Clean Architecture struktur, hvor hver feature er placeret i sit eget "Onion"