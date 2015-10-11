using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth
{
    class FileManager
    {
        private FileInfo[] files;
        public void listFiles()
        {
            string currentPathDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(currentPathDirectory);
            files = dirInfo.GetFiles();
            int i = -1;
            foreach (FileInfo f in files)
            {
                Console.WriteLine(++i + ". " + f.Name);
            }
        }

        public String getFilePath(int fileIndex)
        {
            if (inRangeIndex(fileIndex))
            {
                return files[fileIndex].FullName;
            }
            
            return null;
        }

        private bool inRangeIndex(int index)
        {
            bool correctRange = (index >= 0 && index < files.Length);
            if (!correctRange)
            {
                Console.WriteLine("Incorrect index range");
            }
            return correctRange;
        }

    }
}
