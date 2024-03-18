namespace GraphApplication.Services
{
    public interface IFileService<T> where T: class
    {
        public T Open(string filePath);

        public void Save(string filePath, T data);
    }
}
