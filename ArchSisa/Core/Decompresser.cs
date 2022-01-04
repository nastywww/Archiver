using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Decompresser: IDecompresser
    {
        public async Task DecompressFile(string fileInput, string fileOutput)
        {
            await using var compressedFileStream = File.Open(fileInput, FileMode.Open);
            await using var outputFileStream = File.Create(fileOutput);
            await using var decompressor = new DeflateStream(compressedFileStream, CompressionMode.Decompress);
            await decompressor.CopyToAsync(outputFileStream);
            Console.WriteLine("Decompressing finished!");
        }
    }
}
