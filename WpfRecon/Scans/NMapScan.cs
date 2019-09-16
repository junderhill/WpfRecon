using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfRecon.Scans
{
    public class NMapScan : IDisposable
    {
        public event EventHandler<string> ScanOutput;
        private Process myProcess;

        public async Task RunScan(string IpAddress)
        {
            try
            {
                myProcess = new Process();
                    myProcess.StartInfo.UseShellExecute = false;
                    //this will use the nmap external tool that is stored in the External Tools folder
                    myProcess.StartInfo.WorkingDirectory = "ExternalTools/";
                    //Running the nmap tool 
                    myProcess.StartInfo.FileName = "nmap.exe";
                    //Running the options
                    var sb = new StringBuilder();
                    // show version option
                    sb.Append("-sV ");
                    // running the 
                    sb.Append("-A ");
                    sb.Append("-sC ");
                    sb.Append(IpAddress);
                    myProcess.StartInfo.Arguments = sb.ToString();
                    
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.StartInfo.RedirectStandardError = true;

                    myProcess.OutputDataReceived += Process_OutputDataReceived;

                    // myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    myProcess.BeginOutputReadLine();
                    myProcess.BeginErrorReadLine();
                    myProcess.WaitForExit(); // Even waiting for exit here.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        void Process_OutputDataReceived(object sender, DataReceivedArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                ScanOutput(e.Data);
            }
        }

        public void Dispose()
        {
            myProcess.Dispose();
        }
    }

    public class NmapEventHandler
    {
    }
}
