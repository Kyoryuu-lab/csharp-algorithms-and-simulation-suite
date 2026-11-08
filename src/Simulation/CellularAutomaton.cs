using System;
using System.Threading;

namespace AlgorithmsSuite.Simulation
{
    public static class CellularAutomaton
    {
        public static void Run()
        {
            Console.WriteLine("--- Zellulaerer Automat: Conways Game of Life ---");
            int rows = 10;
            int cols = 10;
            bool[,] grid = new bool[rows, cols];
            Random rnd = new Random();

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    grid[r, c] = rnd.Next(2) == 0;

            for (int gen = 0; gen < 10; gen++)
            {
                Console.WriteLine($"\n--- Generation {gen + 1} von 10 ---");
                PrintGrid(grid);

                bool[,] nextGrid = new bool[rows, cols];
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int neighbors = CountNeighbors(grid, r, c);
                        nextGrid[r, c] = grid[r, c] ? (neighbors == 2 || neighbors == 3) : (neighbors == 3);
                    }
                }

                grid = nextGrid;
                Thread.Sleep(200);
            }
        }

        private static int CountNeighbors(bool[,] grid, int r, int c)
        {
            int count = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;
                    int nr = r + dr;
                    int nc = c + dc;
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr, nc])
                        count++;
                }
            }
            return count;
        }

        private static void PrintGrid(bool[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(grid[r, c] ? "■ " : "□ ");
                }
                Console.WriteLine();
            }
        }
    }
}
