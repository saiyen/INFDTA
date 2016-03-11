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
        Dictionary<int, Dictionary<int, UserPreferences>> users = new Dictionary<int, Dictionary<int, UserPreferences>>();

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


                Dictionary<int, UserPreferences> userRatings;
                if (!users.TryGetValue(userID, out userRatings))
                {
                    users.Add(userID, new Dictionary<int, UserPreferences>());
                }
                
                users[userID].Add(userID, new UserPreferences { UserId = 1, Article = 100, Rating = 3.0 });

            }

            
            Console.WriteLine(users[0].Keys);
           

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
