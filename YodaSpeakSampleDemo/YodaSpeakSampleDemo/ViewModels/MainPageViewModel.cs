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
    /// <summary>
    /// MainPageViewModel class derives from ViewModelBase class
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        string _originalSentence, _translatedSentence;
        bool _canFetchNewSentence;

        private readonly IYodaTranslationService _yodaTranslationService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel()
        {
            _yodaTranslationService = new YodaTranslationService();
            TranslateSentenceCommand = new Command(execute: ExecuteTranslateSentence, canExecute: CanExecuteTranslateSentence);
            TranslatedSentence = "-";
            OriginalSentence = String.Empty;
            CanFetchNewSentence = true;
        }

        //Callback method used to enable Translate Button
        private bool CanExecuteTranslateSentence(object arg)
        {
            return CanFetchNewSentence && OriginalSentence.Length > 0;
        }

        /// <summary>
        /// Stores actual sentence being entered by the user
        /// </summary>
        public string OriginalSentence
        {
            get { return _originalSentence; }
            set { SetProperty(ref _originalSentence, value); }
        }
        /// <summary>
        /// Stores the result of api response from yoda speak api
        /// </summary>
        public string TranslatedSentence
        {
            get { return _translatedSentence; }
            set { SetProperty(ref _translatedSentence, value); }
        }

        //Callback method called when Translate Sentence button is clicked
        private async void ExecuteTranslateSentence(object sender)
        {            
            Debug.WriteLine("Sentence to translate: " + OriginalSentence);
            try
            {
                CanFetchNewSentence = false;
                TranslatedSentence = await _yodaTranslationService.TranslateSentenceAsync(OriginalSentence);
            }
            catch(Exception ex)
            {
                TranslatedSentence = "Error: Failed to translate sentence";
            }
            finally
            {
                CanFetchNewSentence = true;
            }
        }

        public ICommand TranslateSentenceCommand { private set; get; }
        /// <summary>
        /// Used inside CanExccute method to check if Translate Sentence button should be enabled or not
        /// </summary>
        public bool CanFetchNewSentence
        {
            get { return _canFetchNewSentence; }
            set { SetProperty(ref _canFetchNewSentence, value); }
        }
    }
}
