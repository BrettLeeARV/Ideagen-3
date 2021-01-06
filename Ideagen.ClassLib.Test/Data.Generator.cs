using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Ideagen.ClassLib.Test
{
    public class DataGenerator
    {
        /// <summary>
        /// Creates Dummy log files for testing purposes
        /// </summary>
        /// <returns>True if successful. False otherwise</returns>
        public bool CreateStagedLogFiles(string rootPath)
        {
            List<LogFile> dummyLogFileInfos = new List<LogFile>();
            string dummyFolderPath = rootPath;

            dummyLogFileInfos.Add(new LogFile("log1234.log", new DateTime(2019, 1, 1, 13, 41, 21)));
            dummyLogFileInfos.Add(new LogFile("log2913.log", new DateTime(2019, 1, 1, 15, 12, 7)));
            dummyLogFileInfos.Add(new LogFile("log3192.log", new DateTime(2019, 1, 2, 1, 53, 49)));
            dummyLogFileInfos.Add(new LogFile("log3322.log", new DateTime(2019, 1, 2, 23, 30, 54)));
            dummyLogFileInfos.Add(new LogFile("log3561.log", new DateTime(2019, 1, 3, 8, 1, 3)));
            dummyLogFileInfos.Add(new LogFile("log5678.log", new DateTime(2019, 1, 6, 11, 27, 25)));
            dummyLogFileInfos.Add(new LogFile("log7890.log", new DateTime(2019, 1, 7, 3, 44, 55)));
            dummyLogFileInfos.Add(new LogFile("log8888.log", new DateTime(2019, 1, 7, 19, 36, 34)));

            if (Directory.Exists(dummyFolderPath))
                Directory.Delete(dummyFolderPath, true);

            Directory.CreateDirectory(dummyFolderPath);

            foreach(LogFile dummyLogFileInfo in dummyLogFileInfos)
            {
                string dummyLogFilePath = dummyFolderPath + "\\" + dummyLogFileInfo.FileName;
                // Create dummy file
                using (StreamWriter sw = File.CreateText(dummyLogFilePath)){}
                // Set custom CreatedDateTime
                File.SetCreationTime(dummyLogFilePath, dummyLogFileInfo.CreatedDateTime);
            }

            return true;
        }
    }

    public class LogFile
    {
        public string FileName {get; set;}
        public DateTime CreatedDateTime {get; set;}

        public LogFile(string fileName, DateTime createdDateTime)
        {
            FileName = fileName;
            CreatedDateTime = createdDateTime;
        }
    }
}