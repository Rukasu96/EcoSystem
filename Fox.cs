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
            Model = "F";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
            haveSkill = true;
        }
        public Fox(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "F";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
            haveSkill = true;
        }
        
        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Fox fox = new Fox(4, 6, 8, AnimPosX, AnimPosY);
            return fox;
        }

        public override Animal UseSkill(Animal animal)
        {
            if(RandomNumber.GenerateNumber(0,2) == 1 || Power <= animal.Power)
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y + j))
                        {
                            MakeMove(AnimPos.X + i, AnimPos.Y + j, this, true);
                        }
                        else if(SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y + j))
                        {
                            MakeMove(AnimPos.X - i, AnimPos.Y + j, this, true);
                        }
                        else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y - j))
                        {
                            MakeMove(AnimPos.X - i, AnimPos.Y - j, this, true);
                        }
                        else if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y - j))
                        {
                            MakeMove(AnimPos.X + i, AnimPos.Y - j, this, true);
                        }
                    }
                }
            }
            else
            {
                Death(this);
            }

            return animal;

        }

       
    }
}
