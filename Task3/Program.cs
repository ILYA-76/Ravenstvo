using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Task3
{

    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Must be 2 args: path_input_file, path_to_check_files");
                Environment.Exit(1);
            }
            else
            {
                string pathToCheckFile = args[0];
                string pathToFliesForCheck = args[1];

                try
                {
                    string[] allLinesInFile = File.ReadAllLines(pathToCheckFile);
                    CheckHash(allLinesInFile, pathToFliesForCheck);
                }
                catch (FileNotFoundException)
                {
                    throw;
                }
            }
        }

        public static void CheckHash(string[] allLines, string pathToFliesForCheck)
        {
            foreach (var line in allLines)
            {
                string[] wordsInLine = line.Split(" ");
                string fileName = wordsInLine[0];
                string algorithm  = wordsInLine[1];
                string hash = wordsInLine[2];

                string filePath = Path.Combine(pathToFliesForCheck, fileName);
                string checksum = "";

                if (File.Exists(filePath) == false)
                {
                    Console.WriteLine($"{fileName} FILE NOT FOUND");
                }
                else 
                {    
                if (algorithm == "MD5")
                    {
                         checksum = ChecksumUtil.GetChecksum(HashingAlgoTypes.MD5, filePath);
                    }
                    else
                    {
                        if (algorithm == "SHA1")
                        {
                             checksum = ChecksumUtil.GetChecksum(HashingAlgoTypes.SHA1, filePath);
                        }
                        else
                        {
                            if (algorithm == "SHA256")
                            {
                                 checksum = ChecksumUtil.GetChecksum(HashingAlgoTypes.SHA256, filePath);
                            }
                            else
                            {
                                Console.WriteLine("Unexpected agorithm");
                            }
                        }
                    }

                    if (String.Compare(hash,checksum)==0)
                    {
                        Console.WriteLine($"{fileName} OK");
                    }
                    else
                    {
                        Console.WriteLine($"{fileName} FAIL");
                    }

                }

            }

        }
        
        public static class ChecksumUtil
        {
            public static string GetChecksum(HashingAlgoTypes hashingAlgoType, string filename)
            {
                using (var hasher = System.Security.Cryptography.HashAlgorithm.Create(hashingAlgoType.ToString()))
                {
                    using (var stream = System.IO.File.OpenRead(filename))
                    {
                        var hash = hasher.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "");
                    }
                }
            }

        }
        public enum HashingAlgoTypes
        {
            MD5,
            SHA1,
            SHA256,
        }

    }
}