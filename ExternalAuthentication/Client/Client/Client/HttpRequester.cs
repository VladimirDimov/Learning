namespace Client
{
    using System.Net;

    class HttpRequester
    {
        public string Post(string address)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Token", "asd");
                var result = client.DownloadString(address);

                return result;
            }
        }
    }
}
