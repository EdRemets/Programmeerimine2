using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {

        public static void Generate(ApplicationDbContext context)
        {
            if (!context.Workers.Any()) {
                SeedWorkers(context);
            }

            if (!context.Cars.Any()) {
                SeedCars(context);
            }

            if (!context.OperationTypes.Any()) {
                SeedOperationTypes(context);
            }

            if (!context.Operations.Any()) {
                SeedOperations(context);
            }
        }

        private static void SeedWorkers(ApplicationDbContext context)
        {
            var workers = new List<Worker>
            {
                new Worker { name = "Mari Tamm", isAdmin = true },
                new Worker { name = "Jaan Saar", isAdmin = false },
                new Worker { name = "Kati Sepp", isAdmin = false },
                new Worker { name = "Peeter Mägi", isAdmin = false },
                new Worker { name = "Liis Kask", isAdmin = false },
                new Worker { name = "Andres Rebane", isAdmin = false },
                new Worker { name = "Kadri Pärn", isAdmin = false },
                new Worker { name = "Margus Lepik", isAdmin = true },
                new Worker { name = "Anu Koppel", isAdmin = false },
                new Worker { name = "Tarmo Kuusk", isAdmin = false },
                new Worker { name = "Piret Karu", isAdmin = false },
                new Worker { name = "Urmas Oja", isAdmin = false },
                new Worker { name = "Triin Kivi", isAdmin = false },
                new Worker { name = "Indrek Mets", isAdmin = false },
                new Worker { name = "Helen Vaher", isAdmin = false },
                new Worker { name = "Siim Kõiv", isAdmin = true },
                new Worker { name = "Kristi Lill", isAdmin = false },
                new Worker { name = "Raivo Teder", isAdmin = false },
                new Worker { name = "Eve Põder", isAdmin = false },
                new Worker { name = "Madis Laur", isAdmin = false },
                new Worker { name = "Merle Luik", isAdmin = false },
                new Worker { name = "Ain Raudsepp", isAdmin = false },
                new Worker { name = "Riina Org", isAdmin = false },
                new Worker { name = "Kalev Paju", isAdmin = false },
                new Worker { name = "Maarja Jõgi", isAdmin = false },
                new Worker { name = "Ott Nurm", isAdmin = false },
                new Worker { name = "Tiina Aas", isAdmin = false },
                new Worker { name = "Mart Kangur", isAdmin = false },
                new Worker { name = "Katrin Lõhmus", isAdmin = false },
                new Worker { name = "Priit Toom", isAdmin = false },
                new Worker { name = "Sirje Hunt", isAdmin = false },
                new Worker { name = "Erik Soosaar", isAdmin = false },
                new Worker { name = "Reet Kukk", isAdmin = false },
                new Worker { name = "Rasmus Unt", isAdmin = false },
                new Worker { name = "Karin Mölder", isAdmin = false },
                new Worker { name = "Taavi Vool", isAdmin = false },
            };
            context.Workers.AddRange(workers);
            context.SaveChanges();
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            var cars = new List<Car>

            {
                new Car { manufacturer = "Volkswagen", model = "Passat", licensePlate = "123 BKT" },
                new Car { manufacturer = "Audi", model = "A6", licensePlate = "456 MNR" },
                new Car { manufacturer = "BMW", model = "530d", licensePlate = "789 TLA" },
                new Car { manufacturer = "Toyota", model = "Avensis", licensePlate = "101 GHP" },
                new Car { manufacturer = "Skoda", model = "Octavia", licensePlate = "202 KRS" },
                new Car { manufacturer = "Ford", model = "Focus", licensePlate = "303 VLM" },
                new Car { manufacturer = "Volvo", model = "XC90", licensePlate = "404 BPT" },
                new Car { manufacturer = "Mercedes-Benz", model = "E220", licensePlate = "505 NHK" },
                new Car { manufacturer = "Honda", model = "Civic", licensePlate = "606 RSA" },
                new Car { manufacturer = "Kia", model = "Ceed", licensePlate = "707 LTM" },
                new Car { manufacturer = "Hyundai", model = "i30", licensePlate = "808 HKV" },
                new Car { manufacturer = "Nissan", model = "Qashqai", licensePlate = "909 PKE" },
                new Car { manufacturer = "Peugeot", model = "508", licensePlate = "111 MTS" },
                new Car { manufacturer = "Renault", model = "Megane", licensePlate = "222 BRL" },
                new Car { manufacturer = "Subaru", model = "Outback", licensePlate = "333 SKN" },
                new Car { manufacturer = "Mazda", model = "6", licensePlate = "444 TPR" },
                new Car { manufacturer = "Seat", model = "Leon", licensePlate = "555 ALK" },
                new Car { manufacturer = "Opel", model = "Insignia", licensePlate = "616 VKR" },
                new Car { manufacturer = "Toyota", model = "RAV4", licensePlate = "777 HRT" },
                new Car { manufacturer = "BMW", model = "320i", licensePlate = "888 KMP" },
                new Car { manufacturer = "Audi", model = "Q5", licensePlate = "999 LNS" },
                new Car { manufacturer = "Volkswagen", model = "Golf", licensePlate = "124 PTA" },
                new Car { manufacturer = "Skoda", model = "Superb", licensePlate = "235 GRK" },
                new Car { manufacturer = "Volvo", model = "V60", licensePlate = "346 MLV" },
                new Car { manufacturer = "Ford", model = "Mondeo", licensePlate = "457 SRT" },
                new Car { manufacturer = "Lexus", model = "RX450h", licensePlate = "568 KTB" },
                new Car { manufacturer = "Porsche", model = "Cayenne", licensePlate = "679 BHN" },
                new Car { manufacturer = "Land Rover", model = "Discovery", licensePlate = "780 RPL" },
                new Car { manufacturer = "Jeep", model = "Grand Cherokee", licensePlate = "891 TKS" },
                new Car { manufacturer = "Alfa Romeo", model = "Giulia", licensePlate = "902 LKA" },
                new Car { manufacturer = "Jaguar", model = "XF", licensePlate = "135 HMB" },
                new Car { manufacturer = "Citroen", model = "C4", licensePlate = "246 NRV" },
                new Car { manufacturer = "Mitsubishi", model = "Outlander", licensePlate = "357 PLT" },
                new Car { manufacturer = "Suzuki", model = "Vitara", licensePlate = "468 KRT" },
                new Car { manufacturer = "Tesla", model = "Model 3", licensePlate = "579 TRV" },
                new Car { manufacturer = "Tesla", model = "Model X", licensePlate = "680 BLM" }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void SeedOperationTypes(ApplicationDbContext context)
        {
            var operationTypes = new List<OperationType>
            {
                new OperationType { name = "Car wash" },
                new OperationType { name = "Tire change" },
                new OperationType { name = "Engine repair" },
                new OperationType { name = "Maintenance" },
                new OperationType { name = "Car relocation" },
                new OperationType { name = "Oil change" },
                new OperationType { name = "Diagnostics" },
                new OperationType { name = "Technical inspection" },
            };
            context.OperationTypes.AddRange(operationTypes);
            context.SaveChanges();
        }

        // ok well this most obviously was made by ai im not that smart to do this
        private static void SeedOperations(ApplicationDbContext context)
        {
            var cars = context.Cars.ToList();
            var workers = context.Workers.ToList();
            var types = context.OperationTypes.ToList();

            var operations = new List<Operation>();

            for (int i = 0; i < 20; i++)
            {
                operations.Add(new Operation
                {
                    date = DateTime.Now.AddDays(-i),
                    status = (Status)(i % 3),
                    cost = 25m + i * 10m,
                    car = cars[i % cars.Count],
                    worker = workers[i % workers.Count],
                    operationType = types[i % types.Count]
                });
            }

            context.Operations.AddRange(operations);
            context.SaveChanges();
        }
    }
}
