using System.Collections.Generic;
using UnityEngine;

namespace Undertale
{
    public abstract class Monster : MonoBehaviour
    {
        public int Health;
        public int Damage;
        public int Defence;
        
        public List<Attack> Attacks;
        public List<BattleAction> BattleActions;
        public int MaxProgressBattle = 3;

        public bool IsCanSpared => _progressBattle >= MaxProgressBattle;
        private int _progressBattle;
    }
}