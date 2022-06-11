using System;
using System.IO;
using System.Threading;

namespace DeleteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string deleteDir = @"C:\Delete\";
            string keepDir = @"C:\Keep\";

            string[] checkFiles = Directory.GetFiles(deleteDir, "*" ,SearchOption.AllDirectories);
            string[] doneFiles = Directory.GetFiles(keepDir, "*", SearchOption.AllDirectories);


            foreach (string s in checkFiles)
            {
                for (int i = 0; i < doneFiles.Length; i++)
                {
                    if (Path.GetFileNameWithoutExtension(doneFiles[i]) == Path.GetFileNameWithoutExtension(s))
                    {
                        Console.WriteLine("Found - " + doneFiles[i]);
                        Console.WriteLine("Deleting - " + s);
                        File.Delete(s);
                    }
                }
            }
            Thread.Sleep(5000);
            Console.ReadLine();

        }
    }
}
