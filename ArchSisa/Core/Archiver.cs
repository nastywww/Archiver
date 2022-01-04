using System;
using System.IO;
using System.Threading.Tasks;
using ArchSisa.Core.Enum;
using ArchSisa.Core.Interfaces;

namespace ArchSisa.Core
{
    public class Archiver: IArchiver
    {
        private readonly IArgumentParser _argumentParser;
        private readonly ICompresser _compresser;
        private readonly IDecompresser _decompresser;

        public Archiver(IArgumentParser argumentParser,
            ICompresser compresser,
            IDecompresser decompresser)
        {
            _argumentParser = argumentParser;
            _compresser = compresser;
            _decompresser = decompresser;
        }

        public async Task Archive(string[] args)
        {
            var arg = _argumentParser.ParsArguments(args);

            CreateFileToCompress();

            switch (arg.Command)
            {
                case Commands.Zip:
                    await _compresser.CompressFile(arg.FileInput, arg.FileOutput);
                    break;
                case Commands.Unzip:
                    await _decompresser.DecompressFile(arg.FileInput, arg.FileOutput);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            void CreateFileToCompress() => File.ReadAllBytesAsync(arg.FileInput);
        }
    }
}
