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
        public string LifeCycleStage { get; set; }
        public string LifeCycleStageDefinition { get; set;  }
        public bool StatusFlag { get; set;  }
        public bool HasTopics { get; set;  }
        public string LinkName { get; set;  }
    }
}
