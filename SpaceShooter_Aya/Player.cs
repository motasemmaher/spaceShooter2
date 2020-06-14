using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter_Aya
{
    public class Player
    {
        public string Name { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }

        public Image Character;

        public override string ToString()
        {
            return Name;
        }
    }
}
