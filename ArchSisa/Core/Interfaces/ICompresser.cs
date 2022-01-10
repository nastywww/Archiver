using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface ICompresser
    {
        byte[] Compress(byte[] dataToShare);
        byte[][] CompressFile(byte[] dataToCompress);

    }
}
