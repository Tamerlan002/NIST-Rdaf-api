using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDaF.Shared.Constants
{
    public class RDaFSettings
    {
        public string ConnectionString { get; set; }
        public string DefaultConnection { get; set; }
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtExpireMinutes { get; set; }
    }
}
