using Xamarin.UITest;

namespace YodaSpeakSampleDemo.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(@"../../../YodaSpeakSampleDemo/YodaSpeakSampleDemo.Android/bin/Debug/YodaSpeakSampleDemo.Android-Signed.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

