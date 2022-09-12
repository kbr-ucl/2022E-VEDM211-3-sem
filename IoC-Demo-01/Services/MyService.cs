using Helpers;

namespace Services
{
    public class MyService
    {
        public void DoService()
        {
            var helper = new MyHelper();
            helper.DoHelp();
        }
    }
}