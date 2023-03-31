﻿using System;
using System.IO;
using System.Threading;

namespace DeleteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program compares two directories, and it will delete " +
                "files that exist in both directories from the path of files to delete.");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Path to files to possibly Delete...");
            string deleteDir = Console.ReadLine();
            //string deleteDir = @"C:\Delete\";
            Console.WriteLine("Path to files to Keep...");
            string keepDir = Console.ReadLine();
            Console.WriteLine("Delete if doesnt Exist (y/n) Default(n)");
            string doesntExistString = Console.ReadLine();
            bool doesntExist = false;
            if (doesntExistString.ToLower().Trim().Equals("y"))
            {
                doesntExist = true;
            }
            //string keepDir = @"C:\Keep\";

            string[] checkFiles = Directory.GetFiles(deleteDir, "*" ,SearchOption.AllDirectories);
            string[] doneFiles = Directory.GetFiles(keepDir, "*", SearchOption.AllDirectories);


            foreach (string s in checkFiles)
            {
                for (int i = 0; i < doneFiles.Length; i++)
                {
                    if (!doesntExist)
                    {
                        if (Path.GetFileNameWithoutExtension(doneFiles[i]) == Path.GetFileNameWithoutExtension(s))
                        {
                            Console.WriteLine("Found - " + doneFiles[i]);
                            Console.WriteLine("Deleting - " + s);
                            File.Delete(s);
                        }
                    }
                    else
                    {
                        if (Path.GetFileNameWithoutExtension(doneFiles[i]) != Path.GetFileNameWithoutExtension(s))
                        {
                            Console.WriteLine("Not Found - " + doneFiles[i]);
                            Console.WriteLine("Deleting - " + s);
                            File.Delete(s);
                        }
                    }
                }
            }
            Thread.Sleep(5000);
            Console.WriteLine("Cleanup Done...");
            Console.ReadLine();

        }
    }
}
