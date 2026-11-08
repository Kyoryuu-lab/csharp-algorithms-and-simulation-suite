using System;
using System.Threading;

namespace AlgorithmsSuite.Concurrency
{
    public static class IntersectionSimulator
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private static int carsWaiting = 0;

        public static void Run()
        {
            Console.WriteLine("--- Nebenlaeufige Kreuzungssimulation (Petri-Netz-Modell) ---");
            Thread[] carThreads = new Thread[10];
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int dir = rand.Next(4);
                int carId = i + 1;
                carThreads[i] = new Thread(() => CarProcedure(carId, dir));
                carThreads[i].Start();
            }

            foreach (Thread t in carThreads)
            {
                t.Join();
            }

            Console.WriteLine("[+] Alle Fahrzeuge haben die Kreuzung passiert.");
        }

        private static void CarProcedure(int carId, int direction)
        {
            Console.WriteLine($"Fahrzeug #{carId} naehert sich aus Richtung {direction}.");

            semaphore.Wait();
            carsWaiting++;

            if (carsWaiting > 1)
            {
                Console.WriteLine($"  -> Fahrzeug #{carId} muss kurz warten...");
            }

            Console.WriteLine($"  [*] Fahrzeug #{carId} (Richtung {direction}) ueberquert die Kreuzung.");
            Thread.Sleep(300);
            Console.WriteLine($"  [v] Fahrzeug #{carId} hat die Kreuzung verlassen.");

            carsWaiting--;
            semaphore.Release();
        }
    }
}
