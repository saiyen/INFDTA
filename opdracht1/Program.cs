using opdracht1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, List<UserPreferences>> dataSet;
            SelectFile selectFile = new SelectFile();
            selectFile.selectDataSet();//

            FileReader newFile = new FileReader();
            dataSet = newFile.selectBigDataset();

            Console.WriteLine("------ Pearson ------");
            Pearson pearsonTest = new Pearson(dataSet);
            for (int i = 1; i < dataSet.Count; i++)
            {
                Console.WriteLine("user: " + i + " | vs the rest!: " + pearsonTest.Calculate(i));
            }

            Console.WriteLine("------ Euclidean ------");
            Euclidean euclideanTest = new Euclidean(dataSet);
            for (int i = 1; i < dataSet.Count; i++)
            {
                Console.WriteLine(euclideanTest.Calculate(i));
            }

            Console.WriteLine("------ Cosine ------");
            Cosine cosineTest = new Cosine(dataSet);
            for (int i = 1; i < dataSet.Count; i++)
            {
                Console.WriteLine(cosineTest.Calculate(i));
            }

            Console.WriteLine("Oopsiepoepsie");
            Console.ReadKey();
        }
    }
}
