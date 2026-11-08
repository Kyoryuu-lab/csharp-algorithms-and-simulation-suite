using System;
using System.Collections.Generic;

namespace AlgorithmsSuite.Algorithms
{
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        public bool IsWall { get; set; }
        public Node Parent { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F => G + H;

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            IsWall = false;
            Parent = null;
            G = 0;
            H = 0;
        }
    }

    public class AStarPathfinding
    {
        public static void Run()
        {
            Console.WriteLine("--- A* Wegsuche auf 2D-Gitter ---");
            int[,] map = {
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 0, 0}
            };

            AStarPathfinding solver = new AStarPathfinding(map, 0, 0, 4, 4);
            List<Node> path = solver.FindPath();

            if (path != null)
            {
                Console.WriteLine("Gefundener optimaler Pfad (Start -> Ziel):");
                foreach (Node node in path)
                {
                    Console.WriteLine($"  -> ({node.X}, {node.Y})");
                }
            }
            else
            {
                Console.WriteLine("Kein zulaessiger Pfad gefunden.");
            }
        }

        private readonly Node[,] grid;
        private readonly List<Node> openSet = new List<Node>();
        private readonly HashSet<Node> closedSet = new HashSet<Node>();
        private readonly Node startNode;
        private readonly Node endNode;
        private readonly int sizeX;
        private readonly int sizeY;

        public AStarPathfinding(int[,] map, int startX, int startY, int endX, int endY)
        {
            sizeX = map.GetLength(0);
            sizeY = map.GetLength(1);
            grid = new Node[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    grid[x, y] = new Node(x, y) { IsWall = map[x, y] == 1 };
                }
            }

            startNode = grid[startX, startY];
            endNode = grid[endX, endY];
        }

        public List<Node> FindPath()
        {
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node current = GetLowestFNode(openSet);

                if (current == endNode)
                    return ConstructPath(current);

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (Node neighbor in GetNeighbors(current))
                {
                    if (closedSet.Contains(neighbor) || neighbor.IsWall)
                        continue;

                    int tentativeG = current.G + 1;

                    if (!openSet.Contains(neighbor) || tentativeG < neighbor.G)
                    {
                        neighbor.Parent = current;
                        neighbor.G = tentativeG;
                        neighbor.H = Math.Abs(neighbor.X - endNode.X) + Math.Abs(neighbor.Y - endNode.Y);

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }
            return null;
        }

        private Node GetLowestFNode(List<Node> list)
        {
            Node best = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].F < best.F) best = list[i];
            }
            return best;
        }

        private IEnumerable<Node> GetNeighbors(Node node)
        {
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                int nx = node.X + dx[i];
                int ny = node.Y + dy[i];

                if (nx >= 0 && nx < sizeX && ny >= 0 && ny < sizeY)
                    yield return grid[nx, ny];
            }
        }

        private List<Node> ConstructPath(Node target)
        {
            List<Node> path = new List<Node>();
            Node curr = target;
            while (curr != null)
            {
                path.Add(curr);
                curr = curr.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}
