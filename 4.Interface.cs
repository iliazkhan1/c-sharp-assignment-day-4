using System;
using System.Collections.Generic;

interface IAnimal
{
    void Eat();
    void Sleep();
}

interface IMovable
{
    void Walk();
    void Run();
}

interface ITrainable
{
    void Train();
}

class Dog : IAnimal, IMovable, ITrainable
{
    public string Name { get; set; }

    public Dog(string name)
    {
        Name = name;
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} the Dog is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} the Dog is sleeping.");
    }

    public void Walk()
    {
        Console.WriteLine($"{Name} the Dog is walking.");
    }

    public void Run()
    {
        Console.WriteLine($"{Name} the Dog is running.");
    }

    public void Train()
    {
        Console.WriteLine($"{Name} the Dog is training.");
    }
}

class Cat : IAnimal, IMovable
{
    public string Name { get; set; }

    public Cat(string name)
    {
        Name = name;
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} the Cat is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} the Cat is sleeping.");
    }

    public void Walk()
    {
        Console.WriteLine($"{Name} the Cat is walking.");
    }

    public void Run()
    {
        Console.WriteLine($"{Name} the Cat is running.");
    }
}

class Program
{
    static void Main()
    {
        List<IAnimal> animals = new List<IAnimal>();

        Console.WriteLine("Animal Creator");
        Console.WriteLine("==============");

        while (true)
        {
            Console.Write("Enter animal type (dog/cat or 'exit' to finish): ");
            string type = Console.ReadLine()?.Trim().ToLower();

            if (type == "exit") break;

            if (type != "dog" && type != "cat")
            {
                Console.WriteLine("Invalid animal type. Please enter 'dog' or 'cat'.");
                continue;
            }

            Console.Write("Enter the animal's name: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                continue;
            }

            if (type == "dog")
            {
                animals.Add(new Dog(name));
            }
            else if (type == "cat")
            {
                animals.Add(new Cat(name));
            }

            Console.WriteLine("Animal added successfully.\n");
        }

        Console.WriteLine("\n--- Animal Actions ---\n");

        foreach (IAnimal animal in animals)
        {
            animal.Eat();
            animal.Sleep();

            if (animal is IMovable movable)
            {
                movable.Walk();
                movable.Run();
            }

            if (animal is ITrainable trainable)
            {
                trainable.Train();
            }

            Console.WriteLine();
        }
    }
}