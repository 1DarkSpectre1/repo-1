using System;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode { Value = 10 };
            tree.AddItem(12);
            tree.AddItem(8);
            tree.AddItem(9);
            tree.AddItem(14);
            tree.AddItem(11);
            tree.AddItem(18);
            tree.AddItem(16);
            tree.AddItem(5);
            tree.AddItem(6);
            tree.AddItem(3);
            tree.AddItem(24);
            tree.AddItem(33);
            tree.AddItem(21);
            tree.AddItem(23);
            
            tree.PrintTree(tree, 1 ,1);
            Console.ReadLine();
            Console.Clear();
            tree.RemoveItem(14);
            tree.PrintTree(tree, 1, 1);
        }

    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
        public TreeNode GetRoot()
        {
            TreeNode tmp = this;
            while (tmp.Parent!=null)
            {
                tmp = tmp.Parent;
            }
            return tmp;
        }
        public  void AddItem(int value)
        {
            TreeNode tmp = this;
            while (tmp != null)
            {
                if (value < tmp.Value)
                {
                    if (tmp.LeftChild == null)
                    {
                        tmp.LeftChild = new TreeNode { Value = value, Parent = tmp };
                        return;
                    }
                    else
                    {
                        tmp = tmp.LeftChild;
                    }
                }
                else
                {
                    if (tmp.RightChild == null)
                    {
                        tmp.RightChild = new TreeNode { Value = value, Parent = tmp };
                        return;
                    }
                    else
                    {
                        tmp = tmp.RightChild;
                    }
                }
            }
        }
        public TreeNode findRightElement(TreeNode el)
        {
            while (el.RightChild != null)
            {
                el = el.RightChild;
            }
            if (el.LeftChild==null)
            {
                return el;
            }
            return findRightElement(el);
        }
        public TreeNode findLeftElement(TreeNode el)
        {
            while (el.LeftChild != null)
            {
                el = el.LeftChild;
            }
            if (el.RightChild == null)
            {
                return el;
            }
            return findLeftElement(el);
        }
        public void ReplaceParent(TreeNode target, TreeNode replace)
        {
            if (target.Parent.LeftChild == target)
            {
                target.Parent.LeftChild = replace;
                return;
            }
            else
            {
                target.Parent.RightChild = replace;
                return;
            }
        }
        public void RemoveItem(int value)
        {
            TreeNode tmp = GetNodeByValue(value);
            TreeNode replacetmp = null;
            if (tmp==null)
            {
                return;
            }

            if (tmp.LeftChild == null)
            {
                ReplaceParent(tmp, tmp.RightChild);
                return;
            }
            if (tmp.RightChild == null)
            {
                ReplaceParent(tmp, tmp.LeftChild);
                return;
            }
            replacetmp = findLeftElement(tmp.RightChild);
            ReplaceParent(replacetmp, null);
            ReplaceParent(tmp, replacetmp);
            replacetmp.LeftChild = tmp.LeftChild;
            replacetmp.RightChild = tmp.RightChild;
        }
        public  int PrintTree(TreeNode node, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(node.Value);

            var loc = y;

            if (node.RightChild != null)
            {
                Console.SetCursorPosition(x + 2, y);
                Console.Write("--");
                y = PrintTree(node.RightChild, x + 4, y);
            }

            if (node.LeftChild != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(x, loc + 1);
                    Console.Write(" |");
                    loc++;
                }
                y = PrintTree(node.LeftChild, x, y + 2);
            }

            return y;
        }
        public TreeNode GetNodeByValue(int value)
        {
            TreeNode tmp = this;
            while (tmp!=null)
            {
                if (tmp.Value==value)
                {
                    return tmp;
                }
                if (value < tmp.Value)
                {
                    tmp = tmp.LeftChild;
                }
                else
                {
                    tmp = tmp.RightChild;
                }
            }
            Console.WriteLine("Значение отсутствует  ", value);
            return null;

        }

    }
    
    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

}
