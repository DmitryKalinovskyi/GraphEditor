using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Services
{
    class XMLFIleService<T> : IFileService<T> where T : class
    {
        public T Open()
        {
            throw new NotImplementedException();
        }

        public void Save(T data)
        {
            throw new NotImplementedException();
        }
    }
}
