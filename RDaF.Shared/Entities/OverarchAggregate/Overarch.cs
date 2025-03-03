using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.JunctionAggregate;

namespace RDaF.Shared.Entities.OverarchAggregate
{
    public class Overarch : Entity
    {
        public string OverarchingTheme { get; set; }
        public string OTNarrative { get; set; }
        public bool StatusFlag { get; set; }
        public string ShortDescription { get; set; }
        public List<OverarchSubtopic> OverarchSubtopics { get; set; }

    }
}
