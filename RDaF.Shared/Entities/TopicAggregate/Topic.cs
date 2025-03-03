using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.LCStageAggregate;

namespace RDaF.Shared.Entities.TopicAggregate
{
    public class Topic : Entity
    {
        public string TopicName { get; set; }
        public string Definition { get; set; }
        public bool StatusFlag { get; set; }
        public LCStage LCStage { get; set; }
        public int LCStageId { get; set; }
        public int SortOrder { get; set; }
    }
}
