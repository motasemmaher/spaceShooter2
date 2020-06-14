using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter_Aya
{
    public class Game
    {
        public string Name { set; get; }
        public int Score { set; get; }
        public int Coin { set; get; }
        public int Duration { set; get; }
        public DateTime Date { set; get; }
        public List<string> Steps { set; get; }
    }
}
