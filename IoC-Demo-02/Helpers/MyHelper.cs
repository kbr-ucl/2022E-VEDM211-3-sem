using Services;

namespace Helpers
{
    public class MyHelper : IMyHelper
    {
        void IMyHelper.DoHelp()
        {
            throw new NotImplementedException("Du har kaldt 'DoHelp'");
        }
    }
}