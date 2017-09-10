using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

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
            app.EnterText("originalSentence", "You will learn how to speak like me someday. Oh wait.");
            app.Tap("translateButton");
        }
    }
}

