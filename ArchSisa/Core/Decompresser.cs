using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Decompresser: IDecompresser
    {
        public byte[] Decompress(byte[] dataToDecompress)
        {
            var data = new byte[Constants.Constants.BytesBufferSize * 2];
            var output = new MemoryStream(data);
            output.SetLength(0);

            var mStream = new MemoryStream(dataToDecompress);
            using var decompressor = new DeflateStream(mStream, CompressionMode.Decompress);
            decompressor.CopyTo(output);

            return output.ToArray();
        }

        public byte[][] DecompressFile(IEnumerable<byte[]> dataToDecompress)
        {
            return dataToDecompress.AsParallel()
                .AsOrdered()
                .Select(Decompress)
                .ToArray();
        }
    }
}
