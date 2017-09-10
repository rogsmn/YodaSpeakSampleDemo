using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaSpeakSampleDemo.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace YodaSpeakSampleDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        string _originalSentence, _translatedSentence;
        private readonly IYodaTranslationService _yodaTranslationService;

        public MainPageViewModel()
        {
            _yodaTranslationService = new YodaTranslationService();
            TranslateSentenceCommand = new Command(ExecuteTranslateSentence);
            TranslatedSentence = "-";
            OriginalSentence = "";
        }

        public string OriginalSentence
        {
            get { return _originalSentence; }
            set { SetProperty(ref _originalSentence, value); }
        }
        public string TranslatedSentence
        {
            get { return _translatedSentence; }
            set { SetProperty(ref _translatedSentence, value); }
        }

        private void ExecuteTranslateSentence(object sender)
        {
            Debug.WriteLine("Sentence to be translated is " + OriginalSentence);
            TranslatedSentence = _yodaTranslationService.TranslateSentence(OriginalSentence);
        }

        public ICommand TranslateSentenceCommand { private set; get; }
    }
}
