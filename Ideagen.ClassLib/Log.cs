using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Ideagen.ClassLib
{
    public class Log
    {
        /// <summary>
        /// Displays number of files grouped by day 
        /// </summary>
        /// <param name="rootPath">Root path containing files</param>
        /// <returns>Formatted string with summary of files grouped by day. Empty string if exception occured.</returns>
        public string DisplayFileCount(string rootPath)
        {
            FileInfo fileInfo = null;
            List<FileInfo> rawFileInfos = new List<FileInfo>();
            DateTime minDate;
            DateTime maxDate;
            string output = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(rootPath))
                {
                    foreach (string filePath in Directory.GetFiles(rootPath))
                    {
                        fileInfo = new FileInfo(filePath);
                        //Console.WriteLine("fileInfo: " + filePath + ", " + fileInfo.CreationTime.Date.ToString("yyyy-MM-dd"));
                        rawFileInfos.Add(fileInfo);
                    }

                    //Get min and max date range
                    minDate = rawFileInfos.Select(i => i.CreationTime.Date).Min(i => i.Date);
                    maxDate = rawFileInfos.Select(i => i.CreationTime.Date).Max(i => i.Date);

                    //Loop through the date range
                    while (minDate <= maxDate)
                    {
                        //Console.WriteLine(distinctDate.Date);
                        var filteredFiles = rawFileInfos.Select(i => i.CreationTime.Date).Where(i => i.Date == minDate);
                        //Console.WriteLine(minDate.Date.ToString("yyyy-MM-dd") + ": " + filteredFiles.Count() + " file" + (filteredFiles.Count() > 1 ? "s" : ""));
                        output += minDate.Date.ToString("yyyy-MM-dd") + ": " + filteredFiles.Count() + " file" + (filteredFiles.Count() > 1 ? "s" : "") + "\n";

                        minDate = minDate.AddDays(1);
                    }

                }
            }
            catch (Exception ex) {
                Console.WriteLine("Exception: " + ex.StackTrace);
                output = string.Empty;
            }
            
            return output.Trim();
        }
    }
}
