using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevelopersChallenge.Nibo.DTO
{
    public class TransactionDTO
    {
        [XmlElement("TRNTYPE")]
        public string Type { get; set; }
        [XmlElement("DTPOSTED")]
        public string Date { get; set; }
        [XmlElement("TRNAMT")]
        public string Value { get; set; }
        [XmlElement("MEMO")]
        public string Description { get; set; }
    }
}
