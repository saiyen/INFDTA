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

        StreamReader sr;
        char splitter;

        public void selectSmallDataset()
        {
            FileStream readSmall = new FileStream("../../userItem.data", FileMode.Open);
            sr = new StreamReader(readSmall);
            splitter = ','; 
            ReadFile();
        }

        public void selectBigDataset()
        {
            FileStream readBig = new FileStream("../../u.data", FileMode.Open);
            sr = new StreamReader(readBig);
            splitter =  '\t'; 
            ReadFile();
        }

        public void ReadFile()
        {
            List<UserPreferences> userItem = new List<UserPreferences>();
            String currentLine;
            
            // read data in line by line
            while ((currentLine = sr.ReadLine()) != null) {

                var temp = currentLine.Split(splitter);
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

            List<UserPreferences> storeAllUserPreferences = new List<UserPreferences>();

            for(int i = 1; i <= users.Count; i++)
            {
                for (int j = 0; j < users[i].Count; j++)
                {
                    storeAllUserPreferences.Add(new UserPreferences() { UserId = users[i][j].UserId, Article = users[i][j].Article, Rating = users[i][j].Rating});
                }
            }

            Console.WriteLine(storeAllUserPreferences.Select(x => x.UserId));

            Console.ReadKey();

            /*SelectFile selectFile = new SelectFile();
            selectFile.selectDataSet();*/

            sr.Close();
        }
    }
}
