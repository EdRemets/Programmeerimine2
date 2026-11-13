using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;

        public LocalFileClient(string filesRoot)
        {
            _filesRoot = filesRoot;
        }

        public async Task Save(string fileName, string fileStore, Stream inputStream)
        {
            var folderPath = Path.Combine(_filesRoot, fileStore);
            var filePath = GetFilePath(fileName, fileStore);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await inputStream.CopyToAsync(fileStream);
        }

        public Task<Stream> Get(string fileName, string fileStore)
        {
            var filePath = GetFilePath(fileName, fileStore);

            if (!File.Exists(filePath))
            {
                return Task.FromResult<Stream>(null);
            }

            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return Task.FromResult(stream);
        }

        public Task<bool> Delete(string fileName, string fileStore)
        {
            var filePath = GetFilePath(fileName, fileStore);

            if (!File.Exists(filePath))
            {
                return Task.FromResult(false);
            }

            File.Delete(filePath);
            return Task.FromResult(true);
        }

        public Task<IList<string>> List(string fileStore)
        {
            var folderPath = Path.Combine(_filesRoot, fileStore);

            if (!Directory.Exists(folderPath))
            {
                return Task.FromResult<IList<string>>(new List<string>());
            }

            IList<string> files = Directory.GetFiles(folderPath)
                .Select(Path.GetFileName)
                .ToList();

            return Task.FromResult(files);
        }

        private string GetFilePath(string fileName, string fileStore)
        {
            // GetFileName eemaldab ..\..\
            var safeFileName = Path.GetFileName(fileName);
            return Path.Combine(_filesRoot, fileStore, safeFileName);
        }
    }
}
