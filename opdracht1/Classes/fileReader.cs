using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class FileReader
    {
        Dictionary<int, List<UserPreferences>> users;

        public void ReadFile()
        {
            FileStream readFile = new FileStream("../../userItem.data", FileMode.Open);
            StreamReader sr = new StreamReader(readFile);
            List<UserPreferences> userItem = new List<UserPreferences>();
            String currentLine;

            // read data in line by line
            while ((currentLine = sr.ReadLine()) != null)
            {
                var temp = currentLine.Split(',');
                int userID = int.Parse(temp[0]);
                int article = int.Parse(temp[1]);
                double rating = double.Parse(temp[2]);

                List<UserPreferences> userRatings;
                if (!users.TryGetValue(userID, out userRatings))
                {
                    users.Add(userID, new List<UserPreferences>());
                }
                else
                {
                    users[userID].Add(new UserPreferences { UserId = userID, Article = article, Rating = rating });
                }
            }

            Console.WriteLine(users[0]);
           

            Console.ReadKey();
            sr.Close();
        }

        public void FileToDictionary()
        {
            // Met dictionary altijd testen of de key bestaat. Met iDictionary hoeft dat niet.
            Dictionary<int, string> userRatingData = new Dictionary<int, string>();
        }
    }
}
