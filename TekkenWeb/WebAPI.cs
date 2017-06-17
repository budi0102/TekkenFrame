using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace TekkenWeb
{
    public class WebAPI
    {
        public HttpClient Client { get; set; }

        public WebAPI()
        {
            Client = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            Uri uri = new Uri(url);
            return await Client.GetStringAsync(uri);
        }

    }
}
