using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attacks___Defenses.Utils
{
    internal class ThreatUtils
    {
        public static int CalculateSeverity(Threat threat)
        {
            int targetValue;

            switch (threat.Target)
            {
                case "Web Server":
                    targetValue = 10;
                    break;
                case "Database":
                    targetValue = 15;
                    break;
                case "User Credentials":
                    targetValue = 20;
                    break;
                default:
                    targetValue = 5;
                    break;
            }
            return (threat.Volume * threat.Sophistication) + targetValue;
        }

        public static void HandleDefense(Threat threat, BSTree bSTree)
        {
            Thread.Sleep(4000);
            Console.WriteLine("\n" + "--- start threat ---" + "\n");

            var severity = CalculateSeverity(threat);

            if (severity < (BSTreeUtils.FindMin(bSTree.Root).Value.MinSeverity))
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored!");
                return;
            }
            var defenseNode = bSTree.SeekingProtections(bSTree.Root, severity);

            if (defenseNode == null)
            {
                Console.WriteLine("No suitable defence was found. Brace for impact!");
                return;
            }
            else
            {
                defenseNode.Value.Defenses.ForEach(d =>
                {
                    Console.WriteLine(d);
                    Thread.Sleep(2000);
                });
            }
            Console.WriteLine("\n" + "--- end threat ---" + "\n");
        }
    }
}
