using System;
using System.Collections.Generic;
using System.Linq;
using ArchSisa.Core;
using Xunit;

namespace Tests
{
    public class ArchiverIntegrationTests
    {
        [Fact]
        public void CompressingDecompressingTest()
        {
            var random = new Random();

            var dataToCompress = new byte[2_000_000_0];

            random.NextBytes(dataToCompress);

            var compressedData = Compress(dataToCompress);

            var decompressedBytes = Decompress(compressedData).SelectMany(s => s);

            Assert.Equal(dataToCompress, decompressedBytes);
        }

        [Fact]
        public void CompressingDecompressingTest1()
        {
            var random = new Random();

            var dataToCompress = new byte[2_000_000];

            random.NextBytes(dataToCompress);

            var compressedData = Compress1(dataToCompress);

            var decompressedBytes = Decompress1(compressedData);

            Assert.Equal(dataToCompress, decompressedBytes);
        }

        private static byte[] Compress1(byte[] dataToSplit)
        {
            var compressor = new Compresser();

            var compressedResult = compressor.Compress(dataToSplit);

            return compressedResult;
        }

        private static IEnumerable<byte> Decompress1(byte[] dataToDecompress)
        {
            var decompressor = new Decompresser();

            var decompressedBytes = decompressor.Decompress(dataToDecompress);

            return decompressedBytes;
        }

        private static byte[][] Compress(byte[] dataToSplit)
        {
            var compressor = new Compresser();

            var compressedResult = compressor.CompressFile(dataToSplit);

            return compressedResult;
        }

        private static byte[][] Decompress(IEnumerable<byte[]> dataToDecompress)
        {
            var decompressor = new Decompresser();

            var decompressedBytes = decompressor.DecompressFile(dataToDecompress);

            return decompressedBytes;
        }


    }
}
