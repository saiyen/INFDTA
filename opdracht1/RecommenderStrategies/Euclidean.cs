using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class Euclidean : IRecommender
    {
        private Dictionary<int, List<UserPreferences>> userDataset;
        public Euclidean(Dictionary<int, List<UserPreferences>> userDataset)
        {
            this.userDataset = userDataset;
        }
        public double Calculate(int user1)
        {
            double result = 0;
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
                                //calculation
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
