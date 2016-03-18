using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1.Classes
{
    class Pearson : IRecommender
    {
        public double Calculate(Dictionary<int, List<UserPreferences>> userDataset)
        {
            double multiplyAndAddAll = 0;

            foreach (var ratingUserX in userDataset.Where(x => x.Key == 7))
            {
                foreach (var ratingUserY in userDataset.Where(x => x.Key != ratingUserX.Key))
                {
                    if(ratingUserX.Value.Select(x => x.Article) == ratingUserY.Value.Select(y => y.Article))
                    {
                        multiplyAndAddAll += ratingUserX.Value.Where(x => x.Rating) * ratingUserX.Value.Where(y => y.Rating);
                    }
                }
            }



            throw new NotImplementedException();
        }
    }
}
