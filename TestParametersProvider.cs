using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Task2SteamTests.Models;
using System;

namespace Task2SteamTests
{
    public static class TestParametersProvider
    {
        private static readonly string parametersFilename = "parameterssettings.json";
        public static IEnumerable<TestParameters> GetParameters()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration/", parametersFilename);
            string temp = File.ReadAllText(path);
            List<TestParameters> parametersList = JsonSerializer.Deserialize<List<TestParameters>>(JsonSerializer.Deserialize<JsonElement>(temp).GetProperty("TestParameters").ToString());

            for (int i = 0; i < parametersList.Count; i++)
            {
                yield return parametersList[i];
            }
        }
    }
}
