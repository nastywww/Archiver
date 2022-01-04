using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface ICompresser
    {
        Task CompressFile(string fileInput, string fileOutput);
    }
}
