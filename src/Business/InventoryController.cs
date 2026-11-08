using System;

namespace AlgorithmsSuite.Business
{
    public class InventoryController
    {
        public int CurrentStock { get; set; }
        public int MaxStock { get; set; }
        public int MinStock { get; set; }
        public int ReorderQuantity { get; set; }

        public InventoryController(int currentStock, int maxStock, int minStock, int reorderQuantity)
        {
            CurrentStock = currentStock;
            MaxStock = maxStock;
            MinStock = minStock;
            ReorderQuantity = reorderQuantity;
        }

        public void OrderStock()
        {
            int required = MaxStock - CurrentStock;
            if (required > ReorderQuantity)
            {
                Console.WriteLine($"Bestellung ausgeloest: {required} Einheiten nachbestellt.");
                CurrentStock += required;
            }
            else
            {
                Console.WriteLine("Keine Nachbestellung erforderlich (Bestand ausreichend).");
            }
        }

        public void DisplayStock()
        {
            Console.WriteLine($"Aktueller Bestand: {CurrentStock} | Min: {MinStock} | Max: {MaxStock} | Meldebestand: {ReorderQuantity}");
        }

        public static void Run()
        {
            Console.WriteLine("--- Diskrete Bestandsfuehrungslogik ---");
            InventoryController inv = new InventoryController(50, 100, 20, 30);
            inv.DisplayStock();
            inv.OrderStock();
            inv.DisplayStock();
        }
    }
}
