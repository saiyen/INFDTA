using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class Pearson : IRecommender
    {
        private Dictionary<int, List<UserPreferences>> userDataset;
        public Pearson(Dictionary<int, List<UserPreferences>> userDataset)
        {
            this.userDataset = userDataset;
        }

        public double Calculate(int user1)
        {
            double sumAndMultiplyAll = 0;
            double sumUser1 = 0;
            double sumUser2 = 0;
            double sumSquareUser1 = 0;
            double sumSquareUser2 = 0;
            int count = 0;

            foreach (var ratingUserX in userDataset.Where(x => x.Key == user1))
            {
                foreach (var itemX in ratingUserX.Value)
                {
                    int currentItemX = itemX.Article;
                    double currentRatingX = itemX.Rating;

                    foreach (var ratingUserY in userDataset.Where(x => x.Key != ratingUserX.Key))
                    {
                        foreach (var itemY in ratingUserY.Value)
                        {
                            int currentItemY = itemY.Article;
                            double currentRatingY = itemY.Rating;

                            if (currentItemX == currentItemY)
                            {
                                sumAndMultiplyAll += currentRatingX * currentRatingY;
                                sumUser1 += currentRatingX;
                                sumUser2 += currentRatingY;
                                sumSquareUser1 += Math.Pow(currentRatingX, 2);
                                sumSquareUser2 += Math.Pow(currentRatingY, 2);
                                count += 1;
                            }
                        }
                    }
                }
            }

            double upperHalf = sumAndMultiplyAll - ((sumUser1 * sumUser2) / count);
            double bottomUser1Square = sumSquareUser1 - (Math.Pow(sumUser1, 2) / count);
            double bottomUser2Square = sumSquareUser2 - (Math.Pow(sumUser2, 2) / count);
            double bottomHalf = Math.Sqrt((bottomUser1Square * bottomUser2Square));

            double result = upperHalf / bottomHalf;
            //Console.WriteLine(result);
            return result;
          
            //throw new NotImplementedException();
        }
    }
}
