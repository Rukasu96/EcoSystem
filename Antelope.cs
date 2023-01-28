using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Antelope : Animal
    {
        public Antelope(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "A";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }
        public Antelope(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "A";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Antelope antelope = new Antelope(20, 3, 15, AnimPosX, AnimPosY);
            return antelope;
        }
    }
}
