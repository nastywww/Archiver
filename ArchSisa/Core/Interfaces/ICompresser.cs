using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface ICompresser
    {
        byte[][] CompressFile(byte[] dataToCompress);

    }
}
