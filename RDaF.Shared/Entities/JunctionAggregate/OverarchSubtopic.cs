using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.OverarchAggregate;
using RDaF.Shared.Entities.TopicAggregate;

namespace RDaF.Shared.Entities.JunctionAggregate
{
    public class OverarchSubtopic : Entity
    {
        public Overarch Overarch { get; set; }
        public int OverarchId { get; set; }
        public Subtopic Subtopic { get; set; }
        public int SubtopicId { get; set; }
    }
}
