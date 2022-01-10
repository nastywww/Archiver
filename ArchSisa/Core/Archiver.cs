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
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public Archiver(IArgumentParser argumentParser,
            ICompresser compresser,
            IDecompresser decompresser,
            IFileReader fileReader,
            IFileWriter fileWriter)
        {
            _argumentParser = argumentParser;
            _compresser = compresser;
            _decompresser = decompresser;
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public async Task Archive(string[] args)
        {
            var arg = _argumentParser.ParsArguments(args);

            switch (arg.Command)
            {
                case Commands.Zip:
                    var arrayBytes = _fileReader.ReadFileForZip(arg.FileInput);
                    var bytesToWrite = _compresser.CompressFile(arrayBytes);
                    _fileWriter.WriteFile(arg.FileOutput, bytesToWrite, arg.Command);
                    break;
                case Commands.Unzip:

                    await _decompresser.DecompressFile(arg.FileInput, arg.FileOutput);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
