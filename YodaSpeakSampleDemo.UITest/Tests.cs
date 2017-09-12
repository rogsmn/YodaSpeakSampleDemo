using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace YodaSpeakSampleDemo.UITest
{
    [TestFixture(Platform.Android)]    
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Test_Yoda_Speak_API_Sentence()
        {
            app.EnterText("originalSentence", "you will learn");
            app.Tap("translateButton");
            app.WaitFor(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                return true;
            });
            var expectedResult = "Learn, you will";
            var result = app.Query(c => c.Marked("tranlatedSentence")).FirstOrDefault().Text;
            Assert.AreEqual(expectedResult, result);
        }
    }
}

