using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Services
{
    public interface IFileService<T> where T: class
    {
        public T Open(string filePath);

        public void Save(string filePath, T data);
    }
}
