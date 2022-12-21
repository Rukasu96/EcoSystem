using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    abstract class Animal
    {
        private int age;
        private int power;
        private int initiative;
        private string model;
        public bool isAlive;

        public enum Direction { Up, Down, Right, Left }

        public int Age { get => age; set => age = value; }
        public int Power { get => power; set => power = value; }
        public int Initiative { get => initiative; set => initiative = value; }
        public string Model { get => model; set => model = value; }

        public Direction Direct { get; set; }
        public Coordinate AnimPos { get; set; }

        public Animal(int age, int power, int initiative, int posX, int posY)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate(posX, posY);
            isAlive = true;
        }

        public Animal Fight(Animal animal)
        {
            if(this.power < animal.power)
            {
                AnimalsManager.Instance.RemoveAnimal(this);
                return animal;
            }
            else
            {
                AnimalsManager.Instance.RemoveAnimal(animal);
                return this;
            }
        }
        public abstract void Move();
        public bool TryMove(int X, int Y)
        {
            return SlotController.Instance.IsSlotEmpty(X, Y);
        }
        
    }
}
