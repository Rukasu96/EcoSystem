using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Human : Animal
    {
        private int moveCount = 0;
        public Human(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "H";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
        }

        public void StartUsingSkill()
        {
            if(moveCount == 0 || moveCount > 10)
            {
                haveSkill = true;
                moveCount = 0;
            }
        }

        public void MoveHuman()
        {
            if (haveSkill)
            {
                moveCount++;
            }

            if(moveCount == 5)
            {
                StopUsingSkill();
            }

            SetOldPos(AnimPos.X, AnimPos.Y);

            switch (Direct)
            {
                case Direction.Up:
                    AnimPos.Y -= 1;
                    break;
                case Direction.Down:
                    AnimPos.Y += 1;
                    break;
                case Direction.Right:
                    AnimPos.X += 1;
                    break;
                case Direction.Left:
                    AnimPos.X -= 1;
                    break;
                default:
                    break;
            }

            if (SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y) != null)
            {
                Animal anim = SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y);
                Animal winAnimal = Fight(anim);

                if(winAnimal != this)
                {
                    AnimPos.X = oldPos.X;
                    AnimPos.Y = oldPos.Y;
                    MakeMove(AnimPos.X, AnimPos.Y, this, true);
                }
                else
                {
                    MakeMove(AnimPos.X, AnimPos.Y, this, true);
                }

                
            }
            else
            {
                MakeMove(AnimPos.X, AnimPos.Y, this, true);
            }
           
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Animal human = new Human(10, 10, 10);
            return human;
        }

        public override Animal UseSkill(Animal animal)
        {
            if (RandomNumber.GenerateNumber(0, 2) == 1 || Power < animal.Power)
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y + j))
                        {
                            MakeMove(AnimPos.X + i, AnimPos.Y + j, this, true);
                        }
                        else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y + j))
                        {
                            MakeMove(AnimPos.X - i, AnimPos.Y + j, this, true);
                        }
                        else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y - j))
                        {
                            MakeMove(AnimPos.X - i, AnimPos.Y - j, this, true);
                        }
                        else if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y - j))
                        {
                            MakeMove(AnimPos.X - i, AnimPos.Y - j, this, true);
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
        private void StopUsingSkill()
        {
            haveSkill = false;
        }
    }
}
