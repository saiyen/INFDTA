using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class FileReader
    {
        Dictionary<int, List<UserPreferences>> users = new Dictionary<int, List<UserPreferences>>();

        public void ReadFile()
        {
            FileStream readFile = new FileStream( "../../userItem.data", FileMode.Open);
            StreamReader sr = new StreamReader(readFile);
            List<UserPreferences> userItem = new List<UserPreferences>();
            String currentLine;

            // read data in line by line
            while ((currentLine = sr.ReadLine()) != null) {

                var temp = currentLine.Split(',');
                int userID = int.Parse(temp[0]);
                int article = int.Parse(temp[1]);
                double rating = double.Parse(temp[2]);

                List<UserPreferences> userRatings;
                if (!users.TryGetValue(userID, out userRatings))
                {
                    users.Add(userID, new List<UserPreferences>());
                }
                    users[userID].Add(new UserPreferences { UserId = userID, Article = article, Rating = rating });
            }
    
            for(int i = 1; i <= users.Count; i++)
            {
                for (int j = 0; j < users[i].Count; j++)
                {
                    Console.WriteLine(users[i][j].UserId + ", " + users[i][j].Article + ", " + users[i][j].Rating);
                }
            }

            Console.ReadKey();

            sr.Close();
        }
    }
}
