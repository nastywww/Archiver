using System;
using System.IO;
using ArchSisa.Core.Enum;
using ArchSisa.Core.Interfaces;
using ArchSisa.Core.Models;

namespace ArchSisa.Core
{
    public class ArgumentParser: IArgumentParser
    {
        public Arg ParsArguments(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("The arguments are not available!");
                return null;
            }
            if ((!args[0].Equals("zip") || !args[0].Equals("unzip")) && !File.Exists(args[1]))
            {
                Console.WriteLine("The arguments are not valid!");
                return null;
            }

            Commands command =  args[0].Equals("zip") ? Commands.Zip : Commands.Unzip;
            var fileInput = args[1];
            string fileOutput;

            if (args.Length == 3)
            {
                fileOutput = args[2];
            }
            else if(command == Commands.Zip)
            {
                var fileInfo = new FileInfo(fileInput);
                var fileName = fileInfo.FullName;
                fileOutput = $"{fileName}.zip";
            }
            else
            {
                var fileInfo = new FileInfo(fileInput);
                var fileName = fileInfo.FullName.Replace(".zip", "");
                fileOutput = fileName;
            }

            return new Arg(command, fileInput, fileOutput);
        }
    }
}
