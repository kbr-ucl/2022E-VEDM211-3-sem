namespace Services
{
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
}