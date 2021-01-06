using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ideagen.ClassLib;
using System;
using System.IO;
using System.Collections.Generic;
using Ideagen.ClassLib.Test;
using System.Diagnostics;

namespace Ideagen.ClassLib.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateException()
        {
            Log logComponent = new Log();
            string output = logComponent.DisplayFileCount("c:\\sdfsdf");
            Assert.AreEqual(string.Empty, output);
        }

        [TestMethod]
        public void ValidateStagedData()
        {
            string dummyFolderPath = Directory.GetCurrentDirectory() + "\\Dummy";
            DataGenerator generator = new DataGenerator();
            if (generator.CreateStagedLogFiles(dummyFolderPath))
            {
                Log logComponent = new Log();
                string output = logComponent.DisplayFileCount(dummyFolderPath);
                Assert.AreEqual("2019-01-01: 2 files\n2019-01-02: 2 files\n2019-01-03: 1 file\n2019-01-04: 0 file\n2019-01-05: 0 file\n2019-01-06: 1 file\n2019-01-07: 2 files", output);
            }
        }
    }
}
