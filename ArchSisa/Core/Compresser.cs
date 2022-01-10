using System;
using System.Buffers;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Compresser: ICompresser
    {
        public byte[] Compress(byte[] dataToCompress)
        {
            var data = new byte[255];
            var mStream = new MemoryStream(data);
            using var compressor = new DeflateStream(mStream, CompressionMode.Compress);
            compressor.Write(dataToCompress);

            return mStream.ToArray();
        }

        public byte[][] CompressFile(byte[] dataToSplit)
        {
            const int take = 100;
            var arraySize = (int)Math.Ceiling((float)dataToSplit.Length / take);
            var buffer = ArrayPool<byte[]>.Shared.Rent(arraySize);
            var skip = 0;

            for (var i = 0; i < arraySize; i++)
            {
                buffer[i] = dataToSplit.Skip(skip).Take(take).ToArray();
                skip += take;
            }

            return buffer.AsParallel()
                .AsOrdered()
                .Select(Compress)
                .ToArray();

        }
    }
}
