using System;
using Ideagen.ClassLib;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Ideagen.ClassLib.Test;

namespace Ideagen.ClassLib.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator dummyDataGenerator = new DataGenerator();
            string dummyFolderPath = Directory.GetCurrentDirectory() + "\\Dummy";
            if (dummyDataGenerator.CreateStagedLogFiles(dummyFolderPath))
            {
                Log log = new Log();
                System.Console.WriteLine(log.DisplayFileCount(dummyFolderPath));
            }
        }
    }
}
