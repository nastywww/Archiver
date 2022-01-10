using System;
using System.IO;
using System.Linq;
using ArchSisa.Core.Enum;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class FileWriter: IFileWriter
    {
        public void WriteFile(string fileOutput, byte[][] bytesToWrite, Commands command)
        {
            if (command == Commands.Zip)
            {
                using var writer = new BinaryWriter(File.Open(fileOutput, FileMode.OpenOrCreate));

                foreach (var arrayByte in bytesToWrite)
                {
                    writer.Write(arrayByte.Length);
                    writer.Write(arrayByte);
                }
                Console.WriteLine("WriteFile is completed zip!");
                return;
            }

            File.WriteAllBytes(fileOutput, bytesToWrite.SelectMany(s => s).ToArray());
            Console.WriteLine("WriteFile is completed unzip!");
        }
    }
}
