﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Services
{
    public class YodaTranslationService : IYodaTranslationService
    {
        public string TranslateSentence(string sentence)
        {
            return sentence + " translated sentence";
        }
    }
}
