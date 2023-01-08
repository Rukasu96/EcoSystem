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
            Model = "C";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
        }

        public override void Move()
        {
            switch (Direct)
            {
                case Direction.Up:
                    SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                    AnimPos.Y--;
                    break;
                case Direction.Down:
                    SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                    AnimPos.Y++;
                    break;
                case Direction.Right:
                    SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                    AnimPos.X++;
                    break;
                case Direction.Left:
                    SlotController.Instance.ChangeSlotEmpty(AnimPos.X, AnimPos.Y);
                    AnimPos.X--;
                    break;
                default:
                    break;
            }
            SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Animal human = new Human(10, 10, 10, AnimPosX, AnimPosY);
            return human;
        }

    }
}
