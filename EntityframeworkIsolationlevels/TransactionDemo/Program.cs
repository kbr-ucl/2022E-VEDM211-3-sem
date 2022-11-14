// See https://aka.ms/new-console-template for more information
using TransactionExecuter;

Console.WriteLine("Hello, World!");
// Add-Migration CreateDatabase
// Update-Database
var demo = new TransactionDemo();
var created = demo.SetupDatabase();
demo.Phantoms();
demo.ShowBooks();
var deleted = demo.TearDownDatabase();
Console.WriteLine($"Created: {created}. Deleted: {deleted}");
Console.WriteLine("==============================================");

var created2 = demo.SetupDatabase();
demo.PhantomsFixed();
demo.ShowBooks();
var deleted2 = demo.TearDownDatabase();

Console.WriteLine($"Created: {created2}. Deleted: {deleted2}");
Console.WriteLine("Press any key to exit ");
Console.ReadKey();