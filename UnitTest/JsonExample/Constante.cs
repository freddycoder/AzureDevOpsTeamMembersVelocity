using System;
using System.IO;

namespace UnitTest
{
    public static class Constante
    {
        public const string organization = "fabrikam";
        public const string teamProject = "MyFirstProject";

        public static readonly string ExampleFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonExample");
    }
}
