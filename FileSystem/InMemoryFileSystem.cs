using System.Collections.Concurrent;

namespace FileSystem
{
    public class InMemoryFileSystem : IFileSystem
    {
        private IDictionary<string, Stream> _data =
            new ConcurrentDictionary<string, Stream>();

        public void Add(string path, Stream stream)
        {
            _data.Add(path, stream);
        }

        public bool Exists(string path)
        {
            return _data.ContainsKey(path);
        }

        public Stream OpenRead(string path)
        {
            if(!_data.ContainsKey(path))
                throw new FileNotFoundException(path);

            return _data[path];
        }
    }
}
