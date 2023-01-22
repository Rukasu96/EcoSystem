using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Human : Animal
    {

        public Human(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "H";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
        }

        public void Move()
        {
            OldPos.X = AnimPos.X;
            OldPos.Y = AnimPos.Y;

            switch (Direct)
            {
                case Direction.Up:
                    AnimPos.Y--;
                    break;
                case Direction.Down:
                    AnimPos.Y++;
                    break;
                case Direction.Right:
                    AnimPos.X++;
                    break;
                case Direction.Left:
                    AnimPos.X--;
                    break;
                default:
                    break;
            }

            if (SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y) != null)
            {
                Animal anim = SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y);
                Animal winAnimal = Fight(anim);

                if (anim.Model == "T")
                {
                    if (winAnimal == null)
                    {
                        AnimPos.X = OldPos.X;
                        AnimPos.Y = OldPos.Y;
                    }
                    else
                    {
                        SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                        SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, winAnimal);
                        Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                        Console.WriteLine(Model);
                    }
                }
                else
                {
                    SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                    SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, winAnimal);
                    Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                    Console.WriteLine(Model);
                }

                
            }
            else
            {
                SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
                Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                Console.WriteLine(Model);
            }
           
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Animal human = new Human(10, 10, 10, AnimPosX, AnimPosY);
            return human;
        }

    }
}
