using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CarProject
{
    internal class Program
    {

        static void Main(string[] args)
        {   
            // Car List
            var cars = new List<Car>()
            {
            new Car() { Make = "Chevy", Model = "Corvete", Year = 1967, EngineSize = 350 },
            new Car() { Make = "Pontiac", Model = "FireBird", Year = 1967, EngineSize = 400 },
            new Car() { Make = "Dodge", Model = "Challenger", Year = 1970, EngineSize = 427 },
            new Car() { Make = "Ford", Model = "Pinto", Year = 1976, EngineSize = 208 },
            new Car() { Make = "Porche", Model = "McPorcherson ", Year = 2015, EngineSize = 450 },
            new Car() { Make = "Pontiac", Model = "Trans Am", Year = 1967, EngineSize = 350 },
            new Car() { Make = "Ford", Model = "Bronco", Year = 1985, EngineSize = 350 },
            new Car() { Make = "Chevy", Model = "Cavalier", Year = 1996, EngineSize = 287 },
            new Car() { Make = "Porche", Model = "911", Year = 1999, EngineSize = 327 }
            };

            // LINQ New List containing only model and count ordered by model
            var mostMake = cars.GroupBy(n => n.Make)
                           .Select(n => new
                           {
                               Model = n.Key,
                               ModelCount = n.Count()
                           })
                           .OrderBy(n => n.Model);

            // Determines which make appears the most in the list.
            int count = 0;
            string model = "";
            foreach (var car in mostMake)
            {
                if (car.ModelCount >= count)
                {
                    count = car.ModelCount;
                    model = car.Model;
                }
            }

            // LINQ New List ordered by Year
            var averageYear = from car in cars
                              orderby car.Year descending
                              select car;

            // Determines Average year of the list of cars
            var average = cars.Average(a => a.Year);

            // LINQ New List ordered by Engine
            var largestEngine = from car in cars
                                orderby car.EngineSize descending
                                select car;

            // LINQ All Chevy Cars
            var chevyCars = cars.Where(n => n.Make == "Chevy")
                            .Select(n => new
                            {
                                Make = "Chevrolet",
                                Model = n.Model,
                                Year = n.Year,
                                EngineSize = n.EngineSize
                            });

            // Prints all Chevy Cars with make as "Chevrolet"
            Console.WriteLine("----------------- Prints all Chevy Cars with make as Chevrolet -------------------\n");
            foreach (var car in chevyCars)
            {
                
                Console.WriteLine("Make: {0} \t Model: {1} \t Year: {2} \t Engine Size: {3} \n", car.Make, car.Model, car.Year, car.EngineSize);
            }
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            // Determine Largest and Smallest Engines and newest car year in List
            var lEngine = 0;
            var sEngine = 0;
            var totalCars = 0;
            var newest = 0;

            foreach (var car in largestEngine)
            {
                if (car.EngineSize >= lEngine)

                {
                    lEngine = car.EngineSize;

                }
                else
                {
                    sEngine = car.EngineSize;

                }
                if (car.Year >= newest)
                {
                    newest = car.Year;
                }

                // Total Count of cars in the list;
                totalCars = largestEngine.Count();
            }

            // Reverse a Model name
            char[] reverseModel = model.ToCharArray();
            Array.Reverse(reverseModel);
            Console.WriteLine("\n------------ Model name reversed --------------\n");
            Console.Write("\nModel {0} reversed: ", model);
            Console.Write(reverseModel);
            Console.WriteLine("\n-----------------------------------------------\n");

            TabPrint(cars);
            PrintMY(cars);
            PrintYMM(cars);
            PrintYears(cars);
            Print(lEngine, sEngine, totalCars, newest, average, model, count);

            Console.ReadLine();

            }


        public static void PrintMY(List<Car> cars)
        {
            Console.WriteLine("\n----------------- Model and Year -------------------\n");
            foreach (var car in cars)
            {
                // Prints only Model and Year
                Console.WriteLine("\n- Model: {0} Year: {1}\n", car.Model, car.Year);
            }
            Console.WriteLine("-------------------------------------------------------\n");
        }
        public static void PrintYMM(List<Car> cars)
        {
            Console.WriteLine("\n----------------- Year, Model and Make -------------------\n");
            foreach (var car in cars)
            {
                // Prints only Year, Model and Make
                Console.WriteLine("\n- Year: {0}, Model: {1}, Make: {2} \n", car.Year, car.Model, car.Make);
            }
            Console.WriteLine("------------------------------------------------------------\n");
        }

         public static void PrintYears(List<Car> cars)
         {
             Console.WriteLine("----------------- Car Years with a space -------------------\n");
            Console.Write("Years: ");
            foreach (var car in cars)
             {
                    // Prints Car Years with a space

                    Console.Write(car.Year + " ");
             }
             Console.WriteLine("\n------------------------------------------------------------\n");

          }

        public static void TabPrint(List<Car> cars)
        {
            // Prints TAB list of cars
            Console.WriteLine("----------------- TAB list of cars -------------------\n");
            foreach (var car in cars)
            {

                Console.WriteLine("\nMake: {0} \t Model: {1} \t Year: {2} \t Engine Size: {3} \n", car.Make, car.Model, car.Year, car.EngineSize);
            }
        }

        public static void Print(int lEngine, int sEngine, int totalCars, int newest, double average, String model, int count)
        {
                // Prints Largest Engine in List
                Console.WriteLine("------------ Largest Engine in List --------------\n");
                Console.WriteLine("\nLargest Engine size in list is {0}", lEngine);
                Console.WriteLine("--------------------------------------------------\n");
                // Prints Smallest Engine in List
                Console.WriteLine("------------ Smallest Engine in List --------------\n");
                Console.WriteLine("\nSmallest Engine size in list is {0}", sEngine);
                Console.WriteLine("---------------------------------------------------\n");
                // Print total amount of cars in List
                Console.WriteLine("------------ Total amount of cars in List --------------\n");
                Console.WriteLine("\nThe total of cars in the list is {0}", totalCars);
                Console.WriteLine("--------------------------------------------------------\n");
                // Print the newest year of the cars in the List
                Console.WriteLine("------------ Newest year of the cars in the List --------------\n");
                Console.WriteLine("\nThe car newest year in the list is {0}", newest);
                Console.WriteLine("---------------------------------------------------------------\n");
                // Print the average year of the cars in the List
                Console.WriteLine("------------ Average year of the cars in the List --------------\n");
                Console.WriteLine("\nThe average year of the cars in the list is {0}", Math.Round(average));
                Console.WriteLine("----------------------------------------------------------------\n");
                // Print which make appears the most
                Console.WriteLine("------------ Make that appears the most in the list. --------------\n");
                Console.WriteLine("\nModel:{0}, Count:{1}", model, count);
                Console.WriteLine("-------------------------------------------------------------------");
        }

    }
        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public int EngineSize { get; set; }


        }

   
}


