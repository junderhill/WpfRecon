using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfRecon.Scans;
using WpfRecon.Models;

namespace WpfRecon.ViewModels
{
    class ResultPageVM
    {
        private Task scan;

        private readonly NMapScan NmapScan;

        public event EventHandler<string> ScanOutputChanged;
        
        void HandleOutputFromScan(object sender, string data)
        {
            ScanOutput(data);
        }

        public ResultPageVM()
        {
            NmapScan = new NMapScan();
        }

        public async Task StartScan()
        {
            if(State.SuccessfulPing)
            {
                NmapScan.ScanOutput += HandleOutputFromScan;
                scan = NmapScan.RunScan(State.IPAddress);
                return scan;
            }
        }
        
        public string ScanOutput()
        {
            if (scan != null)
            {
                return _scanOutput;
            }
            return "Ping unsuccessful";
        }
    }
}

   
