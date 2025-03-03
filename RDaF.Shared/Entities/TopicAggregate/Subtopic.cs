using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.JunctionAggregate;
using RDaF.Shared.Entities.RoleAggregate;

namespace RDaF.Shared.Entities.TopicAggregate
{
    public class Subtopic : Entity
    {
        public string SubtopicName { get; set; }
        public string SubtopicDefinition { get; set; }
        public bool StatusFlag { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
        public int SortOrder { get; set; }
        public List<RoleSubtopic> RoleSubtopics { get; set; }
        public List<OverarchSubtopic> OverarchSubtopics { get; set; }
    }
}
