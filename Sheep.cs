using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Sheep : Animal
    {
        public Sheep(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "S";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Sheep sheep = new Sheep(10, 1, 3, AnimPosX, AnimPosY);
            return sheep;
        }
    }
}
