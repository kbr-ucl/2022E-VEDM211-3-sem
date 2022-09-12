# 2022E-VEDM211-3-sem
## BmiWebApplication
Indeholder
- BMI beregner 101
- [Validating User Input in Razor Pages](https://www.learnrazorpages.com/razor-pages/validation)
- Unittest demo (UnitTest101)
- SOLID-Ejendomberegner



### SOLID-Ejendomberegner

Formålet er at gøre "EjendomBeregnerService" testbar og robust.

Refactoreringen Indeholder sammen kode i mange steps

- Step 1 - Udflyt fil indlæsning
- Step 2 - Inversion of control - "Du skal kun være afhængig af et interface"
- Step 3 - Unittest af "EjendomBeregnerService" er nu en let sag med et Mock objekt
- Step 4 - Clean up af "EjendomBeregnerService" , således den ikke kender filnavnet
- Step 5 - Brug af Moq til at lave test Mock objekter
