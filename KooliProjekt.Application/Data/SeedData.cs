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
                new Worker { name = "Worker Name", isAdmin = true },
                new Worker { name = "Ih Aveto", isAdmin = false },
                new Worker { name = "Put Some", isAdmin = false },
                new Worker { name = "Ran Dom", isAdmin = false },
                new Worker { name = "Datain Here", isAdmin = false },
                new Worker { name = "Youk Now", isAdmin = false },
                new Worker { name = "What This", isAdmin = false },
                new Worker { name = "Isqu Ite", isAdmin = true },
                new Worker { name = "Bor Ing", isAdmin = false },
                new Worker { name = "Toc ome", isAdmin = false },
                new Worker { name = "Up Wit", isAdmin = false },
                new Worker { name = "Hsom Eran", isAdmin = false },
                new Worker { name = "Dom Data", isAdmin = false },
                new Worker { name = "Soo Ijus", isAdmin = false },
                new Worker { name = "Tam Typing", isAdmin = false },
                new Worker { name = "Outt His", isAdmin = true },
                new Worker { name = "Sen Tense", isAdmin = false },
                new Worker { name = "In Here", isAdmin = false },
                new Worker { name = "Okay Yeah", isAdmin = false },
                new Worker { name = "Icoul Dveju", isAdmin = false },
                new Worker { name = "Stlet Art", isAdmin = false },
                new Worker { name = "Ificial Intelligence", isAdmin = false },
                new Worker { name = "Dothi Sthing", isAdmin = false },
                new Worker { name = "Form EBut", isAdmin = false },
                new Worker { name = "Inst Eadi", isAdmin = false },
                new Worker { name = "Amju Stdo", isAdmin = false },
                new Worker { name = "Ingt His", isAdmin = false },
                new Worker { name = "Bull Shit", isAdmin = false },
                new Worker { name = "Comi Ngup", isAdmin = false },
                new Worker { name = "Wit Hstuf", isAdmin = false },
                new Worker { name = "Ftotyp Ethis", isAdmin = false },
                new Worker { name = "Out Like", isAdmin = false },
                new Worker { name = "YeaI Mtired", isAdmin = false },
                new Worker { name = "But Ithin", isAdmin = false },
                new Worker { name = "Kwere Basica", isAdmin = false },
                new Worker { name = "Lly Done", isAdmin = false },
            };
            context.Workers.AddRange(workers);
            context.SaveChanges();
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            var cars = new List<Car>

            {
                new Car { manufacturer = "Volkswagen", model = "Passat", licensePlate = "123 OKAY" },
                new Car { manufacturer = "Audi", model = "A6", licensePlate = "321 WITH" },
                new Car { manufacturer = "BMW", model = "530d", licensePlate = "789 CARS" },
                new Car { manufacturer = "Toyota", model = "Avensis", licensePlate = "101 IMGO" },
                new Car { manufacturer = "Skoda", model = "Octavia", licensePlate = "202 NNA" },
                new Car { manufacturer = "Ford", model = "Focus", licensePlate = "303 LET" },
                new Car { manufacturer = "Volvo", model = "XC90", licensePlate = "404 AI" },
                new Car { manufacturer = "Mercedes-Benz", model = "E220", licensePlate = "505 DOT" },
                new Car { manufacturer = "Honda", model = "Civic", licensePlate = "606 HIS" },
                new Car { manufacturer = "RUM", model = "TRX", licensePlate = "707 AND" },
                new Car { manufacturer = "Hyundai", model = "i30", licensePlate = "808 JUS" },
                new Car { manufacturer = "Nissan", model = "Qashqai", licensePlate = "909 TCH" },
                new Car { manufacturer = "Peugeot", model = "508", licensePlate = "111 ANG" },
                new Car { manufacturer = "Renault", model = "Megane", licensePlate = "222 ETH" },
                new Car { manufacturer = "Subaru", model = "Outback", licensePlate = "333 ELI" },
                new Car { manufacturer = "Mazda", model = "6", licensePlate = "444 CEN" },
                new Car { manufacturer = "Seat", model = "Leon", licensePlate = "555 SEP" },
                new Car { manufacturer = "Opel", model = "Insignia", licensePlate = "666 LAT" },
                new Car { manufacturer = "Toyota", model = "RAV4", licensePlate = "777 ESC" },
                new Car { manufacturer = "BMW", model = "320i", licensePlate = "888 UZI" },
                new Car { manufacturer = "Audi", model = "Q5", licensePlate = "999 DON" },
                new Car { manufacturer = "Volkswagen", model = "Golf", licensePlate = "124 OTK" },
                new Car { manufacturer = "Skoda", model = "Superb", licensePlate = "235 NOW" },
                new Car { manufacturer = "Volvo", model = "V60", licensePlate = "346 ANY" },
                new Car { manufacturer = "Ford", model = "Mondeo", licensePlate = "457 THI" },
                new Car { manufacturer = "Lexus", model = "RX450h", licensePlate = "568 NGA" },
                new Car { manufacturer = "Porsche", model = "Cayenne", licensePlate = "679 BOU" },
                new Car { manufacturer = "Land Rover", model = "Discovery", licensePlate = "780 TCA" },
                new Car { manufacturer = "Jeep", model = "Grand Cherokee", licensePlate = "891 RSO" },
                new Car { manufacturer = "Alfa Romeo", model = "Giulia", licensePlate = "902 HMY" },
                new Car { manufacturer = "Jaguar", model = "XF", licensePlate = "135 GOD" },
                new Car { manufacturer = "Citroen", model = "C4", licensePlate = "246 FIN" },
                new Car { manufacturer = "Mitsubishi", model = "Outlander", licensePlate = "357 ALL" },
                new Car { manufacturer = "Suzuki", model = "Vitara", licensePlate = "468 YWE" },
                new Car { manufacturer = "Tesla", model = "model 3", licensePlate = "275 DON" },
                new Car { manufacturer = "Tesla", model = "model X", licensePlate = "109 YES" }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void SeedOperationTypes(ApplicationDbContext context)
        {
            var operationTypes = new List<OperationType>
            {
                new OperationType { name = "Uhhh washing or smth" },
                new OperationType { name = "changing tires" },
                new OperationType { name = "repairing the uhhh engine" },
                new OperationType { name = "what else do they do" },
                new OperationType { name = "eh good enough" },
                new OperationType { name = "ik we had to do like real data" },
                new OperationType { name = "but um idk what else they can" },
                new OperationType { name = "be doing here so enjoy this" },
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
