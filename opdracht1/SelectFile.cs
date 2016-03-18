using opdracht1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1
{
    class SelectFile
    {
        public void selectDataSet()
        {
            Console.WriteLine("Kies gewenste dataset.\nVul a in voor klein.\nVul b in voor groot.\n");
            string smallFile = ("a");
            string bigFile = ("b");

            string userInput = Console.ReadLine();

            if (userInput == smallFile || userInput == bigFile)
            {
                if (userInput == smallFile)
                {
                    FileReader readSmall = new FileReader();
                    readSmall.selectSmallDataset();
                }

                else
                {
                    FileReader readBig = new FileReader();
                    readBig.selectBigDataset();
                }
            }

            else
            {
                Console.WriteLine("Kies uit A of B");
            }
            Console.ReadKey();
        }
    }
}
