namespace IoCdemo1
{
    public interface IBeregner
    {
        int Add(int a, int b);
    }


    public class Beregner : IBeregner
    {
        int IBeregner.Add(int a, int b)
         {
             return a + b;
        }
    }
}
