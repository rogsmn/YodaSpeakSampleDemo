using System.Threading.Tasks;

namespace YodaSpeakSampleDemo.Services
{
    /// <summary>
    /// Interface defining methods to interact with Yoda Speak API
    /// </summary>
    public interface IYodaTranslationService
    {
        Task<string> TranslateSentenceAsync(string sentence);
        string GetTranslateSentenceUri(string sentence);
    }
}
