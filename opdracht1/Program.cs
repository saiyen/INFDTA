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
            SelectFile selectFile = new SelectFile();
            selectFile.selectDataSet();
        }
    }
}
