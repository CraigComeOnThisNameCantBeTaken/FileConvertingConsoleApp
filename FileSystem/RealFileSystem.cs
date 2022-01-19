namespace FileSystem
{
    internal class RealFileSystem : IFileSystem
    {
        public bool Exists(string path) =>
            File.Exists(path);


        public Stream OpenRead(string path)
            => File.OpenRead(path);
    }
}