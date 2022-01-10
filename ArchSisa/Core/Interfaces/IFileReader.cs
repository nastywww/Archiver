using ArchSisa.Core.Enum;

namespace ArchSisa.Core.Interfaces
{
    public interface IFileReader
    {
        public byte[] ReadFileForZip(string fileInput);
        public byte[][] ReadFileForUnzip(string fileInput);

    }
}
