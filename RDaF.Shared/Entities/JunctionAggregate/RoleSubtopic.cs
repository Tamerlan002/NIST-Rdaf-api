using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.RoleAggregate;
using RDaF.Shared.Entities.TopicAggregate;

namespace RDaF.Shared.Entities.JunctionAggregate
{
    public class RoleSubtopic : Entity
    {
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public Subtopic Subtopic { get; set; }
        public int SubtopicId { get; set; }
    }
}
