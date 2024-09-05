using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attacks___Defenses.Utils
{    
        internal static class BSTreeUtils
        {
            public static DefenceStrategyNode InsertRec(DefenceStrategyNode root, DefenceStrategyNode node)
            {
                if (root == null)
                {
                    return node;
                }

                if (node.Value.MaxSeverity < root.Value.MinSeverity)
                {
                    root.Left = InsertRec(root.Left, node);
                }
                else if (node.Value.MinSeverity > root.Value.MaxSeverity)
                {
                    root.Right = InsertRec(root.Right, node);
                }

                return root;
            }

            public static List<DefenceStrategyNode> InOrderTraversalHelper(DefenceStrategyNode? node)
            {
                if (node == null)
                {
                    return new List<DefenceStrategyNode>();
                }

                var leftSubtreeList = InOrderTraversalHelper(node.Left);
                var currentNodeList = new List<DefenceStrategyNode> { node };
                var rightSubtreeList = InOrderTraversalHelper(node.Right);

                return leftSubtreeList.Concat(currentNodeList).Concat(rightSubtreeList).ToList();
            }

            public static List<(DefenceStrategyNode Node, int Depth)> PreOrderTraversalHelper(DefenceStrategyNode? node, int depth = 0)
            {
                if (node == null) { return new List<(DefenceStrategyNode Node, int Depth)>(); }

                var currentNodeList = new List<(DefenceStrategyNode Node, int Depth)>
            {
                (node, depth)
            };

                var leftSubtreeList = PreOrderTraversalHelper(node.Left, depth + 1);
                var rightSubtreeList = PreOrderTraversalHelper(node.Right, depth + 1);

                return currentNodeList.Concat(leftSubtreeList).Concat(rightSubtreeList).ToList();
            }

            public static DefenceStrategyNode? RemoveRecursive(DefenceStrategyNode? node, int severity)
            {
                if (node == null)
                {
                    return null;
                }

                if (severity < node.Value.MinSeverity)
                {
                    node.Left = RemoveRecursive(node.Left, severity);
                }
                else if (severity > node.Value.MaxSeverity)
                {
                    node.Right = RemoveRecursive(node.Right, severity);
                }
                else
                {
                    if (node.Left == null && node.Right == null)
                    {
                        return null;
                    }
                    else if (node.Left == null)
                    {
                        return node.Right;
                    }
                    else if (node.Right == null)
                    {
                        return node.Left;
                    }
                    else
                    {
                        DefenceStrategyNode minNode = FindMin(node.Right);
                        node.Value = minNode.Value;
                        node.Right = RemoveRecursive(node.Right, minNode.Value.MinSeverity);
                    }
                }
                return node;
            }
            
            public static DefenceStrategyNode FindMin(DefenceStrategyNode node)
            {
                while (node.Left != null) node = node.Left;
                return node;
            }
        }  
}
