using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TradeMessageGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Invoked by a automation script
            if (args != null && args.Length > 0)
            {
                //GenerateTradeMessage(args);
                if (args[0] == "Generate")
                {
                    if (Directory.Exists(AppSettings.DirectoryName))
                    {
                        TradeMessage tMsg = new TradeMessage();
                        tMsg.GenerateCombination();
                    }
                    else
                    {
                        // MessageBox.Show("Invalid Command Line Argument.");
                    }
                }
            }
            else
            {
                //User wants to generate trades through UI
                //Application.Run(new MainUI());
                if (Directory.Exists(AppSettings.DirectoryName))
                {
                    TradeMessage tMsg = new TradeMessage();
                    tMsg.GenerateCombination();
                }
            }
        }

        public static void GenerateTradeMessage(string[] argsList)
        {
            var trademessages = new List<TradeMessage>();
            trademessages.Add(new TradeMessage());

            TradeMessage tMsg = new TradeMessage();
            //tMsg.fullNotional = 0;
        }
    }
}
