using Attacks___Defenses;
using Attacks___Defenses.Utils;
using System.Text.Json;

class Program
{
     async static Task Main()
    {
        List<Defens> defenceStrategyNodes = await JsonService.ReadFromJsonAsync<List<Defens>>("defenceStrategiesBalanced.json");

        BSTree bSTree = new BSTree();

        defenceStrategyNodes.ForEach(defens => bSTree.Insert(defens));

        BSTreeUtils.PrintTree(bSTree);

        List<Threat> threats = await JsonService.ReadFromJsonAsync<List<Threat>>("threats.json");

        threats.ForEach(thr => ThreatUtils.HandleDefense(thr , bSTree));
    }
  
}

