using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Lab3OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                using (StreamReader sr = new StreamReader("/Users/paulshaburov/Documents/Lab3OOP/Lab3OOP/NewFile1.txt")) 
                {
                    string line;
                    ParseFile p1 = new ParseFile();
                    while ((line = sr.ReadLine()) != null) 
                    {
                        
                        p1.getAnalysis(line);
                        //Console.WriteLine(line);
                    }
                    p1.getList();
                    p1.searchListInt("[ADC_DEV]", "BufferLenSeconds", "double" );
                    //p1.searchListInt("[COMMON]", "DiskCachePath", "int");
                    p1.searchListInt("[LEGACY_XML]", "ListenTcp", "double" );
                  
                }
            }
            catch (Exception e) 
            {
                //Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}