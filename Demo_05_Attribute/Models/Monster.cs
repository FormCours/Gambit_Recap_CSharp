using Demo_05_Attribute.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_05_Attribute.Models
{
    [ActionDemo]
    [ActionDemo]
    [ActionDemo]
    public class Monster : Character
    {
        public override void Hit(Character character)
        {
            base.Hit(character);
            base.Hit(character);
        }
    }
}
