using Demo_05_Attribute.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_05_Attribute.Models
{
    [CharacterName("Gambit"), ActionDemo]
    public class Hero : Character
    {
    }
}
