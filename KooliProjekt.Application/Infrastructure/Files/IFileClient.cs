using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public interface IFileClient
    {
        Task Save(string fileName, string fileStore, Stream inputStream);
        Task<Stream> Get(string fileName, string fileStore);
        Task<bool> Delete(string fileName, string fileStore);
        Task<IList<string>> List(string fileStore);
    }
}
