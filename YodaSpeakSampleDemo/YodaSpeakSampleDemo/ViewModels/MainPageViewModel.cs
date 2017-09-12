using System;
using YodaSpeakSampleDemo.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using YodaSpeakSampleDemo.Constants;

namespace YodaSpeakSampleDemo.ViewModels
{
    /// <summary>
    /// MainPageViewModel class derives from ViewModelBase class
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private string originalSentence, translatedSentence;
        private bool canFetchNewSentence;

        private readonly IYodaTranslationService yodaTranslationService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel()
        {
            yodaTranslationService = new YodaTranslationService();
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
            get { return originalSentence; }
            set { SetProperty(ref originalSentence, value); }
        }
        /// <summary>
        /// Stores the result of api response from yoda speak api
        /// </summary>
        public string TranslatedSentence
        {
            get { return translatedSentence; }
            set { SetProperty(ref translatedSentence, value); }
        }

        //Callback method called when Translate Sentence button is clicked
        private async void ExecuteTranslateSentence(object sender)
        {            
            Debug.WriteLine("Sentence to translate: " + OriginalSentence);
            try
            {
                CanFetchNewSentence = false;
                TranslatedSentence = await yodaTranslationService.TranslateSentenceAsync(OriginalSentence);
            }
            catch(Exception ex)
            {
                TranslatedSentence = MainPageConstant.TRANSLATE_ERROR;
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
            get { return canFetchNewSentence; }
            set { SetProperty(ref canFetchNewSentence, value); }
        }
    }
}
