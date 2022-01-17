using System;
using System.Buffers;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Compresser : ICompresser
    {
        public byte[] Compress(byte[] dataToCompress)
        {
            var data = new byte[2 * Constants.Constants.BytesBufferSize];
            var mStream = new MemoryStream(data);
            mStream.SetLength(0);
            using var compressor = new DeflateStream(mStream, CompressionMode.Compress);
            compressor.Write(dataToCompress);
            compressor.Flush();
            Console.WriteLine("compress");
            return mStream.ToArray();
        }

        public byte[][] CompressFile(byte[] dataToSplit)
        {
            const int take = Constants.Constants.BytesBufferSize;
            var arraySize = (int)Math.Ceiling((float)dataToSplit.Length / take);
            var buffer = new byte[arraySize][];
            var skip = 0;

            for (var i = 0; i < arraySize; i++)
            {
                buffer[i] = dataToSplit.Skip(skip).Take(take).ToArray();
                skip += take;
            }

            Console.WriteLine($"array size: {arraySize}");
            return buffer.AsParallel()
                .AsOrdered()
                .Select(Compress)
                .ToArray();
        }
    }
}
