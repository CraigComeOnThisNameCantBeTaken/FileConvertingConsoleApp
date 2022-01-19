namespace FileSystem
{
    public interface IFileSystem
    {
        bool Exists(string path);
        Stream OpenRead(string path);
    }
}
