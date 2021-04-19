using System.IO;

namespace PhishingSites
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            Usage usage = new Usage();
            int len = args.Length;

            if (len != 2)
            {
                usage.PrintMsg("[WARN] Args' length is invalid...", "[WARN]");
                usage.ShowUsage();
            }
            else
            {
                string mode = args[0];
                string s = args[1];

                if (mode == "-f")
                {
                    if (!File.Exists(s))
                    {
                        usage.PrintMsg("[WARN] The file <" + s + "> does not exists.", "[WARN]");
                        usage.ShowUsage();
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(s);

                        if (fi.Length == 0)
                        {
                            usage.PrintMsg("[WARN] The file <" + s + "> is empty.", "[WARN]");
                            usage.ShowUsage();
                        }
                        else new JobWorker().ReadDomainFromFile(s);
                    }
                }
                else if (mode == "-s")
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        usage.PrintMsg("[WARN] The domain <" + s + "> is invalid or empty.", "[WARN]");
                        usage.ShowUsage();
                    }
                    else new JobWorker().ReadDomainFromArgument(s);
                }
                else
                {
                    usage.PrintMsg("[WARN] The <mode> arg is invalid...", "[WARN]");
                    usage.ShowUsage();
                }
            }
        }
    }
}
