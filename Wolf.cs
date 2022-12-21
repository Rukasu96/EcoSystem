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
            bool canMove = false;
            while (canMove == false)
            {
                int rand = RandomNumber.GenerateNumber(0, 4);
                switch (rand)
                {
                    case 0:
                        if(TryMove(AnimPos.X,AnimPos.Y - 1))
                        {
                            canMove = true;
                            SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                            AnimPos.Y--;
                        }
                        break;
                    case 1:
                        if (TryMove(AnimPos.X, AnimPos.Y + 1))
                        {
                            canMove = true;
                            SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                            AnimPos.Y++;
                        }
                        break;
                    case 2:
                        if (TryMove(AnimPos.X + 1, AnimPos.Y))
                        {
                            canMove = true;
                            SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                            AnimPos.X++;
                        }
                        break;
                    case 3:
                        if (TryMove(AnimPos.X - 1, AnimPos.Y))
                        {
                            canMove = true;
                            SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                            AnimPos.X--;
                        }
                        break;
                    default:
                        break;
                }
            }
            SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
        }
    }
}
