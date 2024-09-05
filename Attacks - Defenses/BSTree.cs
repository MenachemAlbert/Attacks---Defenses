using Attacks___Defenses.Utils;
using System;
using System.Collections.Generic;

namespace Attacks___Defenses
{
    internal class BSTree
    {
        public DefenceStrategyNode Root { get; set; } = null;

        public void Insert(Defens defens)
        {
            var node = new DefenceStrategyNode(defens);
            Root = BSTreeUtils.InsertRec(Root, node);
        }

        public List<DefenceStrategyNode> InOrderTraversal() => BSTreeUtils.InOrderTraversalHelper(Root);

        public List<(DefenceStrategyNode Node, int Depth)> PreOrderTraversal() => BSTreeUtils.PreOrderTraversalHelper(Root);

        public void Remove(int value)
        {
            Root = BSTreeUtils.RemoveRecursive(Root, value);
        }

        public DefenceStrategyNode SeekingProtections(DefenceStrategyNode node, int severity)
        {
            if (node == null) return default;

            if (node.NumInRange(severity)) return node;

            var leftResult = SeekingProtections(node.Left, severity);
            if (leftResult != null)
                return leftResult;

            return SeekingProtections(node.Right, severity);
        }
    }
}
