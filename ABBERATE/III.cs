using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    // =-=-= 0 =-=-=
    class MarineAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public MarineAnimal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
        }
    }

    // =-=-= I =-=-=
    class Dolphin : MarineAnimal
    {
        public bool IsTrained { get; set; }
        public Dolphin(string name, int age, bool isTrained) : base(name, age, "Dolphin")
        {
            IsTrained = isTrained;
        }
        public void PerformTrick()
        {
            if (IsTrained)
            {
                Console.WriteLine($"{Name} performs a trick!");
            }
            else
            {
                Console.WriteLine($"{Name} is not trained to perform tricks.");
            }
        }
    }

    class Shark : MarineAnimal
    {
        public bool IsDangerous { get; set; }
        public Shark(string name, int age, bool isDangerous) : base(name, age, "Shark")
        {
            IsDangerous = isDangerous;
        }
        public void Attack()
        {
            if (IsDangerous)
            {
                Console.WriteLine($"{Name} attacks!");
            }
            else
            {
                Console.WriteLine($"{Name} is not dangerous.");
            }
        }
    }

    class Whale : MarineAnimal
    {
        public double Length { get; set; }
        public Whale(string name, int age, double length) : base(name, age, "Whale")
        {
            Length = length;
        }
        public void Sing()
        {
            Console.WriteLine($"{Name} sings a beautiful song!");
        }
    }

    class Fish : MarineAnimal
    {
        public string Color { get; set; }
        public Fish(string name, int age, string color) : base(name, age, "Fish")
        {
            Color = color;
        }
        public void Swim()
        {
            Console.WriteLine($"{Name} swims gracefully in the water.");
        }
    }

    class Octopus : MarineAnimal
    {
        public int NumberOfArms { get; set; }
        public Octopus(string name, int age, int numberOfArms) : base(name, age, "Octopus")
        {
            NumberOfArms = numberOfArms;
        }
        public void ChangeColor()
        {
            Console.WriteLine($"{Name} changes color to blend in with its surroundings.");
        }
    }

    // =-=-= II =-=-=
    class Oceanarium : IEnumerable<MarineAnimal>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<MarineAnimal> MarineAnimals { get; set; }
        public Oceanarium(string name, string location)
        {
            Name = name;
            Location = location;
            MarineAnimals = new List<MarineAnimal>();
        }
        public void AddMarineAnimal(MarineAnimal animal)
        {
            MarineAnimals.Add(animal);
        }
        public void DisplayMarineAnimals()
        {
            Console.WriteLine($"Marine Animals in {Name}:");
            foreach (var animal in MarineAnimals)
            {
                animal.DisplayInfo();
            }
        }

        public override string ToString()
        {
            return $"Oceanarium Name: {Name}, Location: {Location}, Number of Marine Animals: {MarineAnimals.Count}";
        }
        public IEnumerator<MarineAnimal> GetEnumerator()
        {
            return MarineAnimals.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return MarineAnimals.GetEnumerator();
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Octopus octopus = new Octopus("Inky", 3, 8);
            Fish fihh = new Fish("Fihh", 2, "Fihhy");
            Whale whale = new Whale("Wally", 10, 30.5);
            Shark shark = new Shark("Spike", 5, true);
            Dolphin dolphin = new Dolphin("Omnipotent Universe Devourer", 4, true);
            Oceanarium oceanarium = new Oceanarium("Exploding Feces", "Maine");

            oceanarium.AddMarineAnimal(octopus);
            oceanarium.AddMarineAnimal(fihh);
            oceanarium.AddMarineAnimal(whale);
            oceanarium.AddMarineAnimal(shark);
            oceanarium.AddMarineAnimal(dolphin);

            Console.WriteLine(oceanarium.ToString());

            foreach (MarineAnimal animal in oceanarium)
            {
                animal.DisplayInfo();
            }
            Console.WriteLine($"Total Marine Animals: {oceanarium.MarineAnimals.Count}");
            // Sincerest apologies brotato 😭
        }
    }
}
