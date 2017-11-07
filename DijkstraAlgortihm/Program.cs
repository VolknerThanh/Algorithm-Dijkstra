using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DijkstraAlgortihm
{
    class Program
    {
        public static LinkedList<Tuple<int, int>>[] ds;
        public static int n;
        public static int xp;
        public static int kt;
        public static bool[] visited;
        public static Queue<int> q;
        public static int[] dist;
        public static int[] pre;
        public static bool[] label;

        public static void Input()
        {
            StreamReader sr = new StreamReader("graph.inp");
            string[] chuoi = sr.ReadLine().Trim().Split(' ');
            n = int.Parse(chuoi[0]);
            xp = int.Parse(chuoi[1]);
            kt = int.Parse(chuoi[2]);
            dist = new int[n];
            pre = new int[n];
            label = new bool[n];
            ds = new LinkedList<Tuple<int, int>>[n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Trim().Split(' ');
                ds[i] = new LinkedList<Tuple<int, int>>();
                /* cach 1 */
                for (int j = 0; j < s.Count(); j++)
                {
                    ds[i].AddLast(new Tuple<int, int>(int.Parse(s[j]), int.Parse(s[j + 1])));
                    j++;
                }
                #region cach 2
                //for (int j = 0; j < s.Count() / 2; j++)
                //{
                //    ds[i].AddLast(new Tuple<int, int>(int.Parse(s[2*j]), int.Parse(s[2*j + 1])));
                //}
                #endregion
            }
            sr.Close();
        }
        public static void Output()
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var item in ds[i])
                    Console.Write(item.Item1 + " " + item.Item2 + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void DFS(int x)
        {
            if (visited[x]) return;
            visited[x] = true;
            q.Enqueue(x);
            foreach (var item in ds[x])
            {
                DFS(item.Item1 - 1);
            }
        }
        public static void PrintDFS()
        {
            Console.Write(">> DFS list: ");
            while (q.Count() != 0)
                Console.Write(q.Dequeue() + 1 + " ");
            Console.WriteLine();
        }

        public static void SetInfiniteAllDistElement()
        {
            for (int i = 0; i < n; i++)
            {
                pre[i] = -1;
                dist[i] = int.MaxValue;
            }
        }
        public static void Solve()
        {
            DFS(xp - 1);
            PrintDFS();
            if (visited[kt - 1] == false)
                Console.WriteLine("No road from {0} to {1}!", xp, kt);
            else
            {
                Dijkstra();
                ShortestRoad(kt - 1);
            }
            Console.WriteLine();
        }
        public static int Min()
        {
            int min = -1;
            for(int i = 0; i < n ; i++)
            {
                if(min == -1)
                {
                    if (label[i] == true)
                        continue;
                    else
                        min = i;
                }
                if (dist[i] < dist[min] && label[i] == false)
                    min = i;
            }
            return min;
        }
        public static void Dijkstra()
        {
            SetInfiniteAllDistElement();
            dist[xp - 1] = 0;
            int start = -1;
            while (label[kt - 1] == false)
            {
                start = Min() + 1;
                foreach (var item in ds[start - 1])
                {
                    if (label[item.Item1 - 1] == false)
                    {
                        if (dist[item.Item1 - 1] > dist[start - 1] + item.Item2)
                        {
                            dist[item.Item1 - 1] = dist[start - 1] + item.Item2;
                            pre[item.Item1 - 1] = start - 1;
                        }
                    }

                }
                label[Min()] = true;
            }
        }
        public static void ShortestRoad(int finish)
        {
            Console.Write("Shortest road are [" + dist[finish] + "] with this road : ");
            Stack<int> road = new Stack<int>();
            while (true)
            {
                road.Push(finish + 1);
                if (pre[finish] == -1)
                    break;
                finish = pre[finish];
            }
            while(road.Count != 0)
                Console.Write(road.Pop() + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Input();
            Output();
            q = new Queue<int>();
            visited = new bool[n];
            Solve();
        }
    }
}
