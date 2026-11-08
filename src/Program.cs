using System;
using System.Text;
using AlgorithmsSuite.Algorithms;
using AlgorithmsSuite.Simulation;
using AlgorithmsSuite.Concurrency;
using AlgorithmsSuite.Business;

namespace AlgorithmsSuite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (args.Length > 0)
            {
                RunModule(args[0].ToLower());
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================================================");
                Console.WriteLine("  C# ALGORITHMS & COMPUTATIONAL SIMULATION SUITE");
                Console.WriteLine("========================================================================");
                Console.WriteLine("  1. A* Pfadsuche (Grid mit Hindernissen)");
                Console.WriteLine("  2. Dijkstra-Algorithmus (Gewichteter Graph)");
                Console.WriteLine("  3. Physikalische Simulation (Wurfparabel & Luftwiderstand)");
                Console.WriteLine("  4. Zellulaerer Automat (Conways Game of Life)");
                Console.WriteLine("  5. Nebenlaeufigkeit (Kreuzungssimulation mit SemaphoreSlim)");
                Console.WriteLine("  6. Bestandsmanagement (Diskrete Nachbestelllogik)");
                Console.WriteLine("  0. Beenden");
                Console.WriteLine("========================================================================");
                Console.Write("Auswahl treffen [0-6]: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1": AStarPathfinding.Run(); break;
                    case "2": DijkstraGraph.Run(); break;
                    case "3": ProjectileMotion.Run(); break;
                    case "4": CellularAutomaton.Run(); break;
                    case "5": IntersectionSimulator.Run(); break;
                    case "6": InventoryController.Run(); break;
                    default:
                        Console.WriteLine("Ungueltige Auswahl.");
                        break;
                }

                Console.WriteLine("\nTaste druecken, um zum Menue zurueckzukehren...");
                Console.ReadKey();
            }
        }

        private static void RunModule(string moduleName)
        {
            switch (moduleName)
            {
                case "astar": AStarPathfinding.Run(); break;
                case "dijkstra": DijkstraGraph.Run(); break;
                case "physics": ProjectileMotion.Run(); break;
                case "life": CellularAutomaton.Run(); break;
                case "concurrency": IntersectionSimulator.Run(); break;
                case "inventory": InventoryController.Run(); break;
                default:
                    Console.WriteLine($"Unbekanntes Modul: {moduleName}");
                    break;
            }
        }
    }
}
