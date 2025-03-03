using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDaF.Shared.Entities.BaseEntity;
using RDaF.Shared.Entities.JunctionAggregate;

namespace RDaF.Shared.Entities.RoleAggregate
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public bool StatusFlag { get; set; }
        public string Description { get; set; }
        public List<RoleSubtopic> RoleSubtopics { get; set; }
    }
}
