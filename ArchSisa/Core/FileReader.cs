using System.Collections.Generic;
using System.IO;
using ArchSisa.Core.Enum;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class FileReader: IFileReader
    {
        public byte[] ReadFileForZip(string fileInput)
        {
            return File.ReadAllBytes(fileInput);
        }

        public byte[][] ReadFileForUnzip(string fileInput)
        {
            using var reader = new BinaryReader(File.Open(fileInput, FileMode.Open));
            var array = new List<byte[]>();

            while (reader.PeekChar() != -1)
            {
                var length = reader.ReadInt32();
                var buffer = new byte[length];
                reader.Read(buffer, 0, length);
                array.Add(buffer);
            }

            return array.ToArray();
        }

    }
}
