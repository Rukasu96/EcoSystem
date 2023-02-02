using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Turtle : Animal
    {
        public Turtle(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "T";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
            haveSkill = true;
        }
        public Turtle(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "T";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
            haveSkill = true;
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Turtle turtle = new Turtle(23, 3, 5, AnimPosX, AnimPosY);
            return turtle;
        }

        public override Animal UseSkill(Animal animal)
        {
            if(Power + 3 < animal.Power)
            {
                Death(this);
                return animal;
            }
            else
            {
                return this;
            }
        }
    }
}
