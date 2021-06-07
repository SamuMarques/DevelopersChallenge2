using DevelopersChallenge.Nibo.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevelopersChallenge.Nibo
{
    public static class Util
    {
        public static ArchiveDTO Deserialize(string xml)
        {
            using StringReader stringReader = new StringReader(xml);
            var serializer = new XmlSerializerFactory().CreateSerializer(typeof(ArchiveDTO));
            return (ArchiveDTO)serializer.Deserialize(stringReader);
        }
    }
}
