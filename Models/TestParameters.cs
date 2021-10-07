using System;

namespace Task2SteamTests.Models
{
    [Serializable]
    public class TestParameters
    {
        public string GameTitle { get; set; }
        public int QuantityToCheckSorting { get; set; }
    }
}
