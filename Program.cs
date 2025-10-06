using System;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();
            elf.Wear();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();
            voin.Wear();

            Console.ReadLine();
        }
    }

    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        private Clothing clothing;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
            clothing = factory.CreateClothing();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Hit()
        {
            weapon.Hit();
        }

        public void Wear()
        {
            clothing.Wear();
        }
    }

    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
        public abstract Clothing CreateClothing();
    }

    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }

        public override Clothing CreateClothing()
        {
            return new LightArmor();
        }
    }

    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }

        public override Clothing CreateClothing()
        {
            return new HeavyArmor();
        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }

    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }

    abstract class Clothing
    {
        public abstract void Wear();
    }

    class LightArmor : Clothing
    {
        public override void Wear()
        {
            Console.WriteLine("Одеваем легкую эльфийскую броню");
        }
    }

    class HeavyArmor : Clothing
    {
        public override void Wear()
        {
            Console.WriteLine("Одеваем тяжелую рыцарскую броню");
        }
    }
}
