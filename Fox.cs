using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Fox : Animal
    {
        public Fox(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "C";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }
        public Fox(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "C";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }
        
        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Fox fox = new Fox(10, 1, 3, AnimPosX, AnimPosY);
            return fox;
        }
    }
}
