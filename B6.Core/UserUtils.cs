using System.Net;
using System.Net.Http;

namespace B6.Core
{
    public static class UserUtils
    {
        public static string UserInfo(int age)
        {
            return new WebClient().DownloadString("https://github.com/kogoia/resume/blob/master/README.md");
        }
    }
}