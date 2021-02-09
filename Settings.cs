using System.Configuration;
using Test.Framework.Extensions;

namespace Test.Framework

{
    public static class Settings
    {
        #region Fields

        private static double _defaultTimeout = 60000;
        private static double _defaultPauseTimeout = 2000;
 
        private static string _defaultLoginUrl = "https://www.google.com/";

        private static string _defaultUserName = "";
        private static string _defaultPassword = "";

        private static string _defaultBrowser = "";

        private static string _defaultScreenPath = "";

        #endregion Fields

        #region Constructor

        static Settings()
        {
            var appSettings = ConfigurationManager.AppSettings;

            Timeout = appSettings.GetSettingValue("timeout", double.Parse, _defaultTimeout);

            PauseTimeout = appSettings.GetSettingValue("pauseTimeout", double.Parse, _defaultPauseTimeout);
          
            LoginUrl = appSettings.GetSettingValue("loginUrlrdm", _defaultLoginUrl, true);

            UserName_Correct = appSettings.GetSettingValue("userName_Correct", _defaultUserName, true);    /////////////////// correct email and password
            Password_Correct = appSettings.GetSettingValue("password_Correct", _defaultPassword, true);     ////////////////

            UserName_wrong = appSettings.GetSettingValue("userName_wrong", _defaultUserName, true);    /////////////////// wrong email and password
            Password_wrong = appSettings.GetSettingValue("password_wrong", _defaultPassword, true);     ////////////////

            Browser_chrome = appSettings.GetSettingValue("br_chrome", _defaultBrowser, true);     //////////////// chrome
            Browser_firefox = appSettings.GetSettingValue("br_firefox", _defaultBrowser, true);     //////////////// firefox
            Browser_edge = appSettings.GetSettingValue("br_edge", _defaultBrowser, true);     //////////////// edge
            Browser_ie = appSettings.GetSettingValue("br_ie", _defaultBrowser, true);     //////////////// ie

            ScreenShot_path = appSettings.GetSettingValue("screenShot_path", _defaultScreenPath, true);
        }

        #endregion Constructor

        #region Properties

        public static double Timeout
        {
            get;

            private set;
        }

        public static double PauseTimeout
        {
            get;

            set;
        }

        public static string ScreenShot_path
        {
            get;

            private set;
        }

        public static string LoginUrl
        {
            get;

            private set;
        }

        public static string UserName_Correct
        {
            get;

            private set;
        }

        public static string Password_Correct
        {
            get;

            private set;
        }

        public static string UserName_wrong
        {
            get;

            private set;
        }

        public static string Password_wrong
        {
            get;

            private set;
        }

        public static string Browser_chrome
        {
            get;

            private set;
        }

        public static string Browser_firefox
        {
            get;

            private set;
        }

        public static string Browser_edge
        {
            get;

            private set;
        }

        public static string Browser_ie
        {
            get;

            private set;
        }
        #endregion Properties
    }
}
