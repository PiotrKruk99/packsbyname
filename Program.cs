using System;
using System.IO;
using System.Collections.Generic;

namespace packsbyname
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                Environment.Exit(0);

            if (!File.Exists(args[0]))
                Environment.Exit(0);

            var sreader = new StreamReader(args[0]);
            List<string> lines = new List<string>();
            var fontColor = Console.ForegroundColor;

            while (!sreader.EndOfStream)
                lines.Add(sreader.ReadLine());

            for (var i = 0; i < lines.Count; i++)
                if ((lines[i].StartsWith("local/") || lines[i].StartsWith("aur/") || 
                    lines[i].StartsWith("multilib/") || lines[i].StartsWith("community/") || 
                    lines[i].StartsWith("extra/") || lines[i].StartsWith("core/")) && 
                    lines[i].Split('/')[1].Split(' ')[0].Contains(args[1]))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(lines[i].Split('/')[0] + "/");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(lines[i].Split('/')[1]);
                        Console.ForegroundColor = fontColor;
                        Console.WriteLine(lines[i + 1]);
                    }
        }
    }
}
