using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DP.APIClient
{
    public static class HttpClientFactory
    {
        public static HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }
    }
}
