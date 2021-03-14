using System;
using System.Collections.Generic;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node { Value = 1 ,Edges=new List<Edge>()};

            node.Add(2, 5);
            node.Add(3, 7);
            node.Add(4, 8);
            node.Edges[1].Node.Edges.Add(new Edge { Weight = 4, Node = node.Edges[0].Node });
            node.Edges[0].Node.Edges.Add(new Edge { Weight = 4, Node = node.Edges[2].Node });
            node.Edges[0].Node.Add(5,4);
            node.Edges[0].Node.Add(6, 4);
            node.Edges[1].Node.Edges.Add(new Edge { Weight = 4, Node = node.Edges[2].Node });
            node.Edges[0].Node.Edges.Add(new Edge { Weight = 4, Node = node.Edges[1].Node });
            node.Edges[2].Node.Add(7, 4);
            node.Edges[1].Node.Add(8, 4);
            node.Edges[1].Node.Add(9, 4);
            node.BFS();
        //Результат обхода в ширину 
        //Шаг:0 значение:1
        //Шаг: 1 значение: 2
        //Шаг: 2 значение: 3
        //Шаг: 3 значение: 4
        //Шаг: 4 значение: 5
        //Шаг: 5 значение: 6
        //Шаг: 6 значение: 8
        //Шаг: 7 значение: 9
        //Шаг: 8 значение: 7

            Console.ReadLine();
            node.DFS();
            //Результат обхода в глубину 
            //Шаг: 0 значение: 1
            //Шаг: 1 значение: 4
            //Шаг: 2 значение: 7
            //Шаг: 3 значение: 3
            //Шаг: 4 значение: 9
            //Шаг: 5 значение: 8
            //Шаг: 6 значение: 2
            //Шаг: 7 значение: 6
            //Шаг: 8 значение: 5
            Console.ReadLine();
            Node node1 = new Node { Value = 1, Edges = new List<Edge>() };
            node1.Add(2, 5);
            node1.Add(3, 7);
            node1.Add(4, 8);
            node1.Edges[0].Node.Add(5, 4);
            node1.Edges[0].Node.Add(6, 4);
            node1.Edges[1].Node.Add(8, 4);
            node1.Edges[1].Node.Add(9, 4);
            node1.Edges[0].Node.Edges[0].Node.Add(10, 4);
            node1.Edges[0].Node.Edges[0].Node.Add(11, 4);
            node1.Edges[1].Node.Edges[0].Node.Add(12, 4);
            node1.Edges[1].Node.Edges[0].Node.Add(13, 4);
            node1.BFS();
            //Результат обхода в ширину
            //Шаг: 0 значение: 1
            //Шаг: 1 значение: 2
            //Шаг: 2 значение: 3
            //Шаг: 3 значение: 4
            //Шаг: 4 значение: 5
            //Шаг: 5 значение: 6
            //Шаг: 6 значение: 8
            //Шаг: 7 значение: 9
            //Шаг: 8 значение: 10
            //Шаг: 9 значение: 11
            //Шаг: 10 значение: 12
            //Шаг: 11 значение: 13
            Console.ReadLine();
            node1.DFS();
            //Результат обхода в глубину
            //Шаг: 0 значение: 1
            //Шаг: 1 значение: 4
            //Шаг: 2 значение: 3
            //Шаг: 3 значение: 9
            //Шаг: 4 значение: 8
            //Шаг: 5 значение: 13
            //Шаг: 6 значение: 12
            //Шаг: 7 значение: 2
            //Шаг: 8 значение: 6
            //Шаг: 9 значение: 5
            //Шаг: 10 значение: 11
            //Шаг: 11 значение: 10
            Console.ReadLine();
        }

    }
    public class Edge //Ребро
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается
    }
    public class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи
        public void Add(int value, int weinght)//добавление новой вершины параметры:1.Значение вершины 2.Длина до вершины
        {
            var newNode = new Node()
            {
                Value = value,
                Edges = new List<Edge>()
            };
            Edges.Add(new Edge { Weight = weinght, Node = newNode });
        }

        public void BFS()
        {
            var queue = new Queue<Node>();
            var hashSet = new HashSet<Node>();
            queue.Enqueue(this);
            hashSet.Add(this);
            int step = 0;
            while (queue.Count != 0)
            {
                Node Node = queue.Dequeue();
                
                foreach (var item in Node.Edges)
                {
                    if (!hashSet.Contains(item.Node))
                    {
                        queue.Enqueue(item.Node);
                        hashSet.Add(item.Node);
                    }
                }
                Console.WriteLine($"Шаг:{step} значение:{Node.Value}");
                step++;
            }
        }
        public void DFS()
        {
            var stack = new Stack<Node>();
            stack.Push(this);
            var hashSet = new HashSet<Node>(); 
            hashSet.Add(this);
            int step = 0;
            while (stack.Count != 0)
            {
                Node Node = stack.Pop();

                foreach (var item in Node.Edges)
                {
                    if (!hashSet.Contains(item.Node))
                    {
                        stack.Push(item.Node);
                        hashSet.Add(item.Node);
                    }
                }
                Console.WriteLine($"Шаг:{step} значение:{Node.Value}");
                step++;
            }
        }
        public override bool Equals(object obj)
        {
            var node = obj as Node;

            if (node == null)
                return false;

            return Value == node.Value && Edges == node.Edges;
        }

        public override int GetHashCode()
        {
            int valueHashCode = Value.GetHashCode();
            int EdgesHashCode = Edges?.GetHashCode() ?? 0;
            return valueHashCode ^ EdgesHashCode;
        }
    }

    

}
