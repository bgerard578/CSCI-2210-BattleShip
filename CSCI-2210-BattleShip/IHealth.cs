using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    internal interface IHealth
    {
        public int GetMaxHealth();
        public int GetCurrentHealth();
        public bool IsDead();
    }
}
