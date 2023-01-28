using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Human : Animal
    {
        private bool Sprint;
        public int speed = 1;

        private int moveCount = 0;
        public Human(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "H";
            Sprint = false;
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
        }

        public void UsingSprint()
        {
            if(moveCount > 10 || moveCount == 0) 
            {
                Sprint = true;
                speed = 2;
                moveCount = 0;
            }
        }

        private void StopSprint()
        {
            Sprint = false;
            speed = 1;
        }

        public void Move()
        {
            if (Sprint)
            {
                moveCount++;
            }

            if(moveCount == 5)
            {
                StopSprint();
            }

            OldPos.X = AnimPos.X;
            OldPos.Y = AnimPos.Y;

            switch (Direct)
            {
                case Direction.Up:
                    AnimPos.Y -= speed;
                    break;
                case Direction.Down:
                    AnimPos.Y += speed;
                    break;
                case Direction.Right:
                    AnimPos.X += speed;
                    break;
                case Direction.Left:
                    AnimPos.X -= speed;
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
            Animal human = new Human(10, 10, 10);
            return human;
        }

    }
}
