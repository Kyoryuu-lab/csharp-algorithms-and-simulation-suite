using System;

namespace AlgorithmsSuite.Simulation
{
    public static class ProjectileMotion
    {
        public static void Run()
        {
            Console.WriteLine("--- Numerische Physiksimulation: Wurfparabel mit Luftwiderstand ---");
            double g = 9.81;    // Erdbeschleunigung (m/s^2)
            double m = 0.5;     // Masse (kg)
            double v0 = 20.0;   // Anfangsgeschwindigkeit (m/s)
            double dt = 0.01;   // Zeitschritt (s)
            double k = 0.1;     // Widerstandsbeiwert (kg/s)

            double t = 0.0;
            double x = 0.0;
            double y = 1.0;     // Starthöhe (m)
            double vx = v0;
            double vy = 0.0;

            int step = 0;
            while (y >= 0.0)
            {
                double fDragX = -k * vx;
                double fDragY = -k * vy;

                double ax = fDragX / m;
                double ay = (-m * g + fDragY) / m;

                vx += ax * dt;
                vy += ay * dt;
                x += vx * dt;
                y += vy * dt;
                t += dt;

                if (step++ % 10 == 0 || y < 0.0)
                {
                    Console.WriteLine($"t: {t:F2} s | Position: ({x:F2} m, {Math.Max(0.0, y):F2} m) | v: ({vx:F2}, {vy:F2}) m/s");
                }
            }

            Console.WriteLine($"\nBodenkontakt nach t = {t:F2} s bei Weite x = {x:F2} m.");
        }
    }
}
