using ArchSisa.Core.Enum;

namespace ArchSisa.Core.Interfaces
{
    public interface IFileWriter
    {
        public void WriteFile(string fileOutput, byte[][] bytesToWrite, Commands command);
    }
}
