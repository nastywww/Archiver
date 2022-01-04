using ArchSisa.Core.Models;

namespace ArchSisa.Core.Interfaces
{
    public interface IArgumentParser
    {
        public Arg ParsArguments(string[] args);
    }
}
