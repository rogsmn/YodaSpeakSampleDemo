﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Services
{
    public interface IYodaTranslationService
    {
        string TranslateSentence(string sentence);
    }
}