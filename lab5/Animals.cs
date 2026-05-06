using System;

namespace Lab5_OOP
{

    abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal() { Name = "Невідомо"; Age = 0; }
        public Animal(string name) { Name = name; Age = 0; }
        public Animal(string name, int age) { Name = name; Age = age; }

        ~Animal()
        {
            Console.WriteLine($"[Деструктор] Animal ({Name}) видалено.");
        }

        public abstract void Show();
    }

    class Bird : Animal
    {
        public bool CanFly { get; set; }

        public Bird() : base() { CanFly = true; }
        public Bird(string name, bool canFly) : base(name) { CanFly = canFly; }
        public Bird(string name, int age, bool canFly) : base(name, age) { CanFly = canFly; }

        ~Bird()
        {
            Console.WriteLine($"[Деструктор] Bird ({Name}) видалено.");
        }

        public override void Show()
        {
            string flyStr = CanFly ? "літає" : "не літає";
            Console.WriteLine($"Птах: {Name}, Вік: {Age}, Статус: {flyStr}");
        }
    }

    class Mammal : Animal
    {
        public string Habitat { get; set; }

        public Mammal() : base() { Habitat = "Невідомо"; }
        public Mammal(string name, string habitat) : base(name) { Habitat = habitat; }
        public Mammal(string name, int age, string habitat) : base(name, age) { Habitat = habitat; }

        ~Mammal()
        {
            Console.WriteLine($"[Деструктор] Mammal ({Name}) видалено.");
        }

        public override void Show()
        {
            Console.WriteLine($"Савець: {Name}, Вік: {Age}, Середовище: {Habitat}");
        }
    }

    class Artiodactyl : Mammal
    {
        public bool HasHorns { get; set; }
        public Artiodactyl() : base() { HasHorns = false; }
        public Artiodactyl(string name, string habitat, bool hasHorns) : base(name, habitat) { HasHorns = hasHorns; }
        public Artiodactyl(string name, int age, string habitat, bool hasHorns) : base(name, age, habitat) { HasHorns = hasHorns; }

        ~Artiodactyl()
        {
            Console.WriteLine($"[Деструктор] Artiodactyl ({Name}) видалено.");
        }

        public override void Show()
        {
            string horns = HasHorns ? "має роги" : "без рогів";
            Console.WriteLine($"Парнокопитне: {Name}, Вік: {Age}, Середовище: {Habitat}, {horns}");
        }
    }
}
