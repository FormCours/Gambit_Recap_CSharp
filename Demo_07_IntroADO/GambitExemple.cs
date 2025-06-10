using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_07_IntroADO
{
    internal class GambitExemple
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string? Desc { get; set; }
        public required bool IsActive { get; set; }
    }
}
