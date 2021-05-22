using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumPractice
{
    public sealed class ConfigurationHelper
    {
        public string Browser { get; }
        public bool IsHeadless { get; }
        public bool IsSeleniumGrid { get; }
        public string GridHubUri { get; }



        private ConfigurationHelper()
        {
            try
            {
                var configurationData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "../../../../appsettings.json");
                dynamic data = JObject.Parse(configurationData);

                //NOTICE
                //Add assign value here
                Browser = data.Browser;
                IsHeadless = data.IsHeadless;
                IsSeleniumGrid = data.IsSeleniumGrid;
                GridHubUri = data.GridHubUri;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get the configuration data from configuration file. \n" + e);
            }
        }

        //    2. Thread Safety Singleton

        //Explanation of the following code:
        //This implementation is thread-safe.
        //In the following code, the thread is locked on a shared object and checks whether an instance has been created or not.
        //This takes care of the memory barrier issue and ensures that only one thread will create an instance.
        //For example: Since only one thread can be in that part of the code at a time, by the time the second thread enters it, the first thread will have created the instance, so the expression will evaluate to false.
        //The biggest problem with this is performance; performance suffers since a lock is required every time an instance is requested.
        private static readonly object padlock = new object();

        private static ConfigurationHelper instance = null;

        public static ConfigurationHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ConfigurationHelper();
                        }
                    }
                }
                return instance;
            }
        }
    }
}