using System;
using Framework.Utility;
using NUnit.Framework.Interfaces;
using NUnit.Engine;
using NUnit.Engine.Extensibility;

namespace Framework.Errors
{
    /// <summary>
    /// This will manage all failures in the test. It will will keep listening till the test end in case an error occurs.
    /// </summary>
    [Extension(Description = "Test Reporter Extension" /*, EngineVersion = "3.12"*/)]
    [ExtensionProperty("FileExtension", ".nunit")]  // So I don´t load lots of assemblies.
    public class Listeners : ITestEventListener
    {
        private readonly string _path2 = ".//screens/";
        private readonly string _path = @"C:\Users\ffanelli\Desktop\Screenshots\";


        public void OnTestEvent(string report)
        {
            Base.GetScreenShot(report, _path);
        }
    }
}
