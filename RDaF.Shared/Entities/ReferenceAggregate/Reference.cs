using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;

namespace RDaF.Shared.Entities.ReferenceAggregate
{
    public class Reference : Entity
    {
        public string PublType { get; set; }
        public string Authors { get; set; }
        public string Title { get; set; }
        public string SourceTitle { get; set; }
        public string ISBN { get; set; }
        public string ISSN { get; set; }
        public string DOI { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string Pages { get; set; }
        public string Issue { get; set; }
        public string JournalAbbr { get; set; }
        public string Publisher { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string Editor { get; set; }
        public string Edition { get; set; }
        public string ConferenceName { get; set; }
        public string Version { get; set; }
        public string Code { get; set; }
        public string ACSCitation { get; set; }
        public string ChicagoCitation { get; set; }
        public string APACitation { get; set; }
        public string HarvardCitation { get; set; }
        public bool StatusFlag { get; set; }
        public string Squib { get; set; }
        public string PublicationTypes { get; set; }
        public string PublYear { get; set; }
        public string Volume { get; set; }
        public string DbKey { get; set; }
        public string Language { get; set; }
    }
}
