using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Constants
{
    public class YodaTranslationServiceConstant
    {
        //Key to be used when calling Yoda Speak API. Required
        public const string MASHUPKEY = "t9Yaye7t1GmshzKaI32jRX9fGAjlp1sDUhhjsnjlH07LYiFf1P";
        //API Endpoint
        public const string APIENDPOINT = "https://yoda.p.mashape.com/yoda";
        public const string ERROR_SERVICE_UNAVAILABLE = "Yoda Speak API Response: Service Unavailable";
        public const string ERROR_NOTFOUND = "Yoda Speak API Response: Not Found";
    }
}
