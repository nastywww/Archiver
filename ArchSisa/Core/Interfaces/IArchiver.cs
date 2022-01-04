using System.Threading.Tasks;

namespace ArchSisa.Core.Interfaces
{
    public interface IArchiver
    {
        public Task Archive(string[] args);
    }
}
