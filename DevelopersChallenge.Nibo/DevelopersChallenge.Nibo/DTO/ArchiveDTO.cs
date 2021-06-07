using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevelopersChallenge.Nibo.DTO
{
    [XmlRoot("BANKTRANLIST")]
    public class ArchiveDTO
    {
        [XmlElement("DTSTART")]
        public string StartDate { get; set; }
        [XmlElement("DTEND")]
        public string FinalDate { get; set; }
        [XmlElement("STMTTRN")]
        public List<TransactionDTO> Transactions { get; set; }
    }
}
