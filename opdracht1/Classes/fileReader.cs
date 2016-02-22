using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class fileReader
    {
        // Met dictionary altijd testen of de key bestaat. Met iDictionary hoeft dat niet.
        Dictionary<int, string> userRatingData = new Dictionary<int, string>();

        public void ReadFile()
        {
            FileStream readFile = new FileStream("../../userItem.data", FileMode.Open);
            StreamReader sr = new StreamReader(readFile);
            String line;

            // read data in line by line
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }

            Console.ReadKey();
            sr.Close();
        }
    }
}
