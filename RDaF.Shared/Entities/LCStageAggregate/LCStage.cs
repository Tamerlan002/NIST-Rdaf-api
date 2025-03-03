using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;

namespace RDaF.Shared.Entities.LCStageAggregate
{
    public class LCStage : Entity
    {
        public string LifeCycleStage { get; }
        public string LifeCycleStageDefinition { get; }
        public bool StatusFlag { get; }
        public bool HasTopics { get; }
        public string LinkName { get; }
    }
}
