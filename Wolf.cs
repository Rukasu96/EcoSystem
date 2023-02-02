using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Wolf : Animal
    {
        public Wolf(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "W";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }
        public Wolf(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "W";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Wolf wolf = new Wolf(10, 12, 7, AnimPosX, AnimPosY);
            return wolf;
        }

        public override Animal UseSkill(Animal animal)
        {
            return null;
        }
    }
}
