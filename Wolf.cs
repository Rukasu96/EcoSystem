using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Wolf : Animal
    {
        public Wolf(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "W";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
        }

        public override void Move()
        {
            SetOldPos(AnimPos.X, AnimPos.Y);

            bool canMove = false;
            while (canMove == false)
            {
                int rand = RandomNumber.GenerateNumber(0, 4);
                switch (rand)
                {
                    case 0:
                        if (TryMove(AnimPos.X, AnimPos.Y - 1))
                        {
                            canMove = true;
                            AnimPos.Y--;
                        }
                        break;
                    case 1:
                        if (TryMove(AnimPos.X, AnimPos.Y + 1))
                        {
                            canMove = true;
                            AnimPos.Y++;
                        }
                        break;
                    case 2:
                        if (TryMove(AnimPos.X + 1, AnimPos.Y))
                        {
                            canMove = true;
                            AnimPos.X++;
                        }
                        break;
                    case 3:
                        if (TryMove(AnimPos.X - 1, AnimPos.Y))
                        {
                            canMove = true;
                            AnimPos.X--;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (SlotController.Instance.CheckSlotModel(AnimPos.X, AnimPos.Y, this))
            {
                //Second animal position
                int animalPosX = AnimPos.X;
                int animalPosY = AnimPos.Y;

                AnimPos.X = OldPos.X;
                AnimPos.Y = OldPos.Y;

                Reproduction(animalPosX, animalPosY);
            }
            else if (SlotController.Instance.CheckSlotFlower(AnimPos.X,AnimPos.Y))
            {
                SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
                Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                Console.WriteLine(Model);
            }
            else
            {
                SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
                Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                Console.WriteLine(Model);
            }

        }

        private void SetOldPos(int posX, int posY)
        {
            OldPos.X = posX;
            OldPos.Y = posY;
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Wolf wolf = new Wolf(10, 01, 10, AnimPosX, AnimPosY);
            return wolf;
        }
    }
}
