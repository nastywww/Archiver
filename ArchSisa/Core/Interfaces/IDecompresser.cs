using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface IDecompresser
    {
        byte[][] DecompressFile(IEnumerable<byte[]> dataToDecompress);
    }
}
