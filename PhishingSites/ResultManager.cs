using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhishingSites
{
    public class ResultManager
    {
        private readonly string fakeDomainDir = Environment.CurrentDirectory + "\\PhishingDomains";

        public void PrintResult(List<string> fakeDomainList)
        {
            StringBuilder sb = new StringBuilder();
            int count = fakeDomainList.Count;

            for (int i = 0; i < count; i++)
            {
                if (i == 0) sb.Append(fakeDomainList[i]).Append("\r\n");
                else sb.Append("\t").Append(fakeDomainList[i]).Append("\r\n");
            }

            Console.ResetColor();
            Console.Write(sb.ToString());
        }

        public void WriteResult(List<List<string>> fakeDomainList, string filename)
        {
            if (!Directory.Exists(fakeDomainDir)) Directory.CreateDirectory(fakeDomainDir);
            string fileFullName = fakeDomainDir + "\\" + filename;
            FileStream fs = new FileStream(fileFullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            int line = 0;

            try
            {
                foreach (List<string> sList in fakeDomainList)
                {
                    int count = sList.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (i == 0) sb.Append(sList[i]).Append("\r\n");
                        else sb.Append("\t").Append(sList[i]).Append("\r\n");
                        line++;
                    }

                    if (line >= 5000)
                    {
                        sw.Write(sb.ToString());
                        line = 0;
                        sb = new StringBuilder();
                    }
                }

                if (line > 0) sw.Write(sb.ToString());
            }
            finally
            {
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
