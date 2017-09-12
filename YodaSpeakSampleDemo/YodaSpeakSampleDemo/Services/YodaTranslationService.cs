using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YodaSpeakSampleDemo.Constants;

namespace YodaSpeakSampleDemo.Services
{
    /// <summary>
    /// YodaTranslationService implements IYodaTranslationService
    /// </summary>
    public class YodaTranslationService : IYodaTranslationService
    {        

        public YodaTranslationService()
        {            
        }

        public string GetTranslateSentenceUri(string sentence)
        {
            return YodaTranslationServiceConstant.APIENDPOINT + "?sentence=" + sentence;
        }

        /// <summary>
        /// Method used to translate actual sentence into Yoda specific words
        /// </summary>
        /// <param name="sentence">Sentence to be translated</param>
        /// <returns>Translated Sentence</returns>
        public async Task<string> TranslateSentenceAsync(string sentence)
        {
            var url = GetTranslateSentenceUri(sentence);
            string translatedSentence = "";
            try
            {
                using(var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-Mashape-Key", YodaTranslationServiceConstant.MASHUPKEY);
                    httpClient.DefaultRequestHeaders.Add("Accept", "text/plain");
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                    switch (responseMessage.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            translatedSentence = await responseMessage.Content.ReadAsStringAsync();
                            break;
                        case System.Net.HttpStatusCode.ServiceUnavailable:
                            translatedSentence = YodaTranslationServiceConstant.ERROR_SERVICE_UNAVAILABLE;
                            break;
                        case System.Net.HttpStatusCode.NotFound:
                            translatedSentence = YodaTranslationServiceConstant.ERROR_NOTFOUND;
                            break;
                    }
                    Debug.WriteLine(translatedSentence + " is the translated sentence");
                }                
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
