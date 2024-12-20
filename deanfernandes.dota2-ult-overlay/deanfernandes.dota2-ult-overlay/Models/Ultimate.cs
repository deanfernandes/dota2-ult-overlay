using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deanfernandes.dota2_ult_overlay.Models
{
    class Ultimate
    {
        public string Name { get; set; }
        public int CooldownDurationSeconds { get; set; }
        public UltimateTimer Timer { get; set; }

        public Ultimate(string name, int cooldownDurationSeconds)
        {
            Name = name;
            CooldownDurationSeconds = cooldownDurationSeconds;
            Timer = new UltimateTimer(CooldownDurationSeconds);
        }
    }
}
