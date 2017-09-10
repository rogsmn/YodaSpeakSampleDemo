using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Services
{
    public class YodaTranslationService : IYodaTranslationService
    {
        private readonly HttpClient HttpClient;
        private const string APIEndpoint = "https://yoda.p.mashape.com/yoda";
        private const string MashupKey = "t9Yaye7t1GmshzKaI32jRX9fGAjlp1sDUhhjsnjlH07LYiFf1P";

        public YodaTranslationService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Add("X-Mashape-Key", MashupKey);
            HttpClient.DefaultRequestHeaders.Add("Accept", "text/plain");
        }


        public async Task<string> TranslateSentenceAsync(string sentence)
        {
            var url = APIEndpoint + "?sentence=" + sentence;
            string translatedSentence = "";
            try
            {
                HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
                //translatedSentence = await HttpClient.GetStringAsync(url);
                switch (responseMessage.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        translatedSentence = await responseMessage.Content.ReadAsStringAsync();
                        break;
                    case System.Net.HttpStatusCode.ServiceUnavailable:
                        translatedSentence = "Yoda Speak API Response: Service Unavailable";
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        translatedSentence = "Yoda Speak API Response: Not Found";
                        break;
                }
                Debug.WriteLine(translatedSentence + " is the translated sentence");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
            return translatedSentence;
        }
    }
}
