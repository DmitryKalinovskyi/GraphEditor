using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

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
                    if(fileStream == null)
                        throw new FileLoadException("Failed to load file");

                    var serializer = new DataContractSerializer(typeof(T));
                    
                    object? readedObject = serializer.ReadObject(fileStream);

                    if (readedObject == null)
                        throw new Exception("Serializer can't read object from filestream.");

                    return (T)readedObject ?? throw new Exception("Failed to convert readed object to " + typeof(T).Name);
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
