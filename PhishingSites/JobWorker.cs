using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhishingSites
{
    public class JobWorker
    {
        private readonly Usage usage = new Usage();
        private readonly Engine engine = new Engine();
        private readonly ResultManager resultManager = new ResultManager();

        public void ReadDomainFromArgument(string domain)
        {
            try
            {
                List<string> fakeDomainList = engine.PhishingDomainGenerateAlgorithm(domain);
                if (fakeDomainList != null) resultManager.PrintResult(fakeDomainList);
                else usage.PrintMsg("[WARN] <" + domain + "> is invalid or no phishing domain generated.", "[WARN]");
            }
            catch (Exception ex)
            {
                usage.PrintMsg("[ERRO] " + ex.Message, "[ERRO]");
            }
        }

        public void ReadDomainFromFile(string fileFullName)
        {
            FileStream fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            try
            {
                usage.PrintMsg("[INFO] Start generating phishing domains.", "[INFO]");
                List<List<string>> dList2 = new List<List<string>>();
                string s = string.Empty;
                uint num = 0;

                while ((s = sr.ReadLine()) != null)
                {
                    List<string> fakeDomainList = engine.PhishingDomainGenerateAlgorithm(s);
                    if (fakeDomainList != null) dList2.Add(fakeDomainList);
                    else usage.PrintMsg("[WARN] <" + s + "> is invalid or no phishing domain generated.", "[WARN]");
                    num++;
                    int count = dList2.Count;

                    if (count >= 5000)
                    {
                        resultManager.WriteResult(dList2, DateTime.Now.ToString("yyyyMMddHHmmss") + "_phishing_domains.csv");
                        usage.PrintMsg("[INFO] " + num.ToString() + " domains have been processed.", "[INFO]");
                        dList2.Clear();
                        dList2.TrimExcess();
                        dList2 = new List<List<string>>();
                    }
                }

                if (dList2.Count > 0)
                {
                    resultManager.WriteResult(dList2, DateTime.Now.ToString("yyyyMMddHHmmss") + "_phishing_domains.csv");
                    usage.PrintMsg("[INFO] " + num.ToString() + " domains have been processed.", "[INFO]");
                }

                usage.PrintMsg("[INFO] Generating phishing domains completed.", "[INFO]");
            }
            catch (Exception ex)
            {
                usage.PrintMsg("[ERRO] " + ex.Message, "[ERRO]");
            }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
