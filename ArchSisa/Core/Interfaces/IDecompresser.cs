using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface IDecompresser
    {
        Task DecompressFile(string fileInput, string fileOutput);
    }
}
