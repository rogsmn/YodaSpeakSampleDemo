using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Services
{
    /// <summary>
    /// YodaTranslationService implements IYodaTranslationService
    /// </summary>
    public class YodaTranslationService : IYodaTranslationService
    {
        //Used for fetching data
        private readonly HttpClient HttpClient;
        //API Endpoint
        private const string APIEndpoint = "https://yoda.p.mashape.com/yoda";
        //Key to be used when calling Yoda Speak API. Required
        private const string MashupKey = "t9Yaye7t1GmshzKaI32jRX9fGAjlp1sDUhhjsnjlH07LYiFf1P";

        public YodaTranslationService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            //Below two attributes needs to be set as required by Yoda Speak API
            HttpClient.DefaultRequestHeaders.Add("X-Mashape-Key", MashupKey);
            HttpClient.DefaultRequestHeaders.Add("Accept", "text/plain");
        }

        /// <summary>
        /// Method used to translate actual sentence into Yoda specific words
        /// </summary>
        /// <param name="sentence">Sentence to be translated</param>
        /// <returns>Translated Sentence</returns>
        public async Task<string> TranslateSentenceAsync(string sentence)
        {
            var url = APIEndpoint + "?sentence=" + sentence;
            string translatedSentence = "";
            try
            {
                HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);                
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
