using System;
using System.Collections.Generic;
using System.IO;
using Casady.Lib.MutateConfigFile;

namespace Casady.Tools.ConfigDriver
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintTitleMessage();
            if (args.Length == 1) // by file
                foreach (var val in GetConfigValues(args[0]))
                    ChangeConfigOption(val);
            else if (args.Length == 3)
                ConfigChange.UpdateConfigFile(args[0], args[1], args[2]);
            else if (args.Length == 4)
                ConfigChange.UpdateConfigFile(args[0], args[1], args[2], args[3]);
            else
                PrintUsage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        private static void ChangeConfigOption(List<string> val)
        {
            if (val.Count == 4)
                ConfigChange.UpdateConfigFile(val[0], val[1], val[2], val[3]);
            else if (val.Count == 3)
                ConfigChange.UpdateConfigFile(val[0], val[1], val[2]);
            else
                Console.Write(new ArgumentException("Incorrect number of arguments passed"));
        }

        /// <summary>
        /// Gets the change list from the change file
        /// </summary>
        /// <param name="changeFile"></param>
        /// <returns></returns>
        public static List<List<string>> GetConfigValues(string changeFile)
        {
            if (!File.Exists(changeFile))
                Console.WriteLine(new FileNotFoundException("", changeFile));

            var ret = new List<List<string>>();
            var r = new StreamReader(changeFile);
            while (!r.EndOfStream)
            {
                var val = new List<string>();
                val.AddRange(r.ReadLine().Split('|'));
                ret.Add(val);
            }
            return ret;
        }

        /// <summary>
        /// Prints title befor changeing the xml config
        /// </summary>
        public static void PrintTitleMessage()
        {
            Console.WriteLine(@"ConfigDriver.exe is a tool for automating application configuration");
            Console.WriteLine(@"This program was written by Richard Casady for personal use only");
        }

        /// <summary>
        /// Print ConfigDriver.exe usage
        /// </summary>
        public static void PrintUsage()
        {
            const string sampleXml = "<ConfigDriver>\n  <SampleOne>Change one node value</SampleOne>\n  <SampleTwo>\n    <Attrib name=\"item1\" description=\"Change one specific attribute value\" />\n    <Attrib name=\"item2\" description=\"\" />\n  </SampleTwo>\n  <SampleThree>\n  </SampleThree>\n  <SampleThree name=\"SpecificNone\">Change one specific node value</SampleThree>\n</ConfigDriver>\n";
            const string changeFile = "..\\..\\sampleFile.xml|/ConfigDriver/SampleOne|Change one node value\n..\\..\\sampleFile.xml|/ConfigDriver/SampleTwo/Attrib[@name='item1']|description|Change one specific attribute value\n..\\..\\sampleFile.xml|/ConfigDriver/SampleThree[@name='SpecificNone']|Change one node value by name\n";
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("There are two mode of use: One is to pass the change vales at command line");
            Console.WriteLine("The second is to put a group of chnage values in a change file.");
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine(@"Sample usage mode one:");
            Console.WriteLine("ConfigDriver.exe \"..\\..\\sampleFile.xml\" \"/ConfigDriver/SampleOne\" \"Change one node value\"");
            Console.WriteLine("ConfigDriver.exe \"..\\..\\sampleFile.xml\" \"/ConfigDriver/SampleTwo/Attrib[@name='item1']\" \"description\" \"Change one specific attribute value\"");
            Console.WriteLine("ConfigDriver.exe \"..\\..\\sampleFile.xml\" \"/ConfigDriver/SampleThree[@name='SpecificNone']\" \"Change one node value by name\"");
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine(@"Sample usage Change File usage:");
            Console.WriteLine(@"ConfigDriver.exe C:\ChangeFile.txt");
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("File layout definition:");
            Console.WriteLine("To change a Single node value");
            Console.WriteLine("File Name Path | XPath Query | Node Value");
            Console.WriteLine("To change an attribute value");
            Console.WriteLine("File Name Path | XPath Query | Attribute Name | Attribute Value");
            Console.WriteLine("The parameters are \"|\" delimited");
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("Sample change file:");
            Console.Write(changeFile);
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("Sample resulting file:");
            Console.Write(sampleXml);
            Console.WriteLine("------------------------------------------------\n");
        }
    }
}
