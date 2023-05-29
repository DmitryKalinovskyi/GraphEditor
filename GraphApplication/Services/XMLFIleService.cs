using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GraphApplication.Services
{
    public class XMLFileService<T> : IFileService<T> where T : class
    {
        public T Open(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    return (T)serializer.ReadObject(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to deserialize the XML file", ex);
            }
        }

        public void Save(string filePath, T data)
        {
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    var settings = new XmlWriterSettings()
                    {
                        Indent = true
                    };
                    using (var xmlWriter = XmlWriter.Create(fileStream, settings))
                    {
                        var serializer = new DataContractSerializer(typeof(T));
                        serializer.WriteObject(xmlWriter, data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to serialize the data to XML file", ex);
            }
        }
    }
}
