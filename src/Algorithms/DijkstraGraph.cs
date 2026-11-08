using System;

namespace AlgorithmsSuite.Algorithms
{
    public static class DijkstraGraph
    {
        public static void Run()
        {
            Console.WriteLine("--- Dijkstra-Algorithmus (Kuerzeste Pfade ab Startknoten 0) ---");
            int[,] graph = {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };

            CalculateShortestPaths(graph, 0);
        }

        public static void CalculateShortestPaths(int[,] graph, int source)
        {
            int vertices = graph.GetLength(0);
            int[] dist = new int[vertices];
            bool[] visited = new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            dist[source] = 0;

            for (int count = 0; count < vertices - 1; count++)
            {
                int u = MinDistance(dist, visited, vertices);
                if (u == -1) break;
                visited[u] = true;

                for (int v = 0; v < vertices; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue &&
                        dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }

            Console.WriteLine("Knoten \t Kuerzeste Distanz ab Quelle");
            for (int i = 0; i < vertices; i++)
            {
                string dStr = dist[i] == int.MaxValue ? "unendlich" : dist[i].ToString();
                Console.WriteLine($"  {i} \t {dStr}");
            }
        }

        private static int MinDistance(int[] dist, bool[] visited, int vertices)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < vertices; v++)
            {
                if (!visited[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
