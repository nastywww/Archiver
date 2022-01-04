using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Compresser: ICompresser
    {
        public async Task CompressFile(string fileInput, string fileOutput)
        {
            await using var originalFileStream = File.Open(fileInput, FileMode.Open);
            await using var compressedFileStream = File.Create(fileOutput);
            await using var compressor = new DeflateStream(compressedFileStream, CompressionMode.Compress);
            await originalFileStream.CopyToAsync(compressor);
            Console.WriteLine("Compressing finished!");
        }
    }
}
