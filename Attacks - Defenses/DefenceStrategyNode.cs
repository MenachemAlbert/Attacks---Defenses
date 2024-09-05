using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attacks___Defenses
{
    internal class DefenceStrategyNode
    {
        public Defens Value {  get; set; }
        public DefenceStrategyNode Left { get; set; }
        public DefenceStrategyNode Right { get; set; }

        public DefenceStrategyNode(Defens defens)
        {
            Value = defens;
            Left = null;
            Right = null;
        }

        public bool NumInRange(int num) => num >= Value.MinSeverity && num <= Value.MaxSeverity;

        public override string ToString()
        {
            var defenses = string.Join(", ", Value.Defenses);
            return $"MinSeverity: {Value.MinSeverity}, MaxSeverity: {Value.MaxSeverity} , Defenses: [{defenses}] \n";
        }

    }
}
