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
            TranslateSentenceCommand = new Command(execute: ExecuteTranslateSentence, canExecute: CanExecuteTranslateSentence);
            TranslatedSentence = "-";
            OriginalSentence = String.Empty;
        }

        private bool CanExecuteTranslateSentence(object arg)
        {
            return OriginalSentence.Length > 0;
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

        private async void ExecuteTranslateSentence(object sender)
        {
            //TranslateSentenceCommand.CanExecute(false);
            Debug.WriteLine("Sentence to be translated is " + OriginalSentence);
            try
            {
                TranslatedSentence = await _yodaTranslationService.TranslateSentenceAsync(OriginalSentence);
            }
            catch(Exception ex)
            {
                TranslatedSentence = "Failed to translate sentence";
            }            
        }

        public ICommand TranslateSentenceCommand { private set; get; }
    }
}
