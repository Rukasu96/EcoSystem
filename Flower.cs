using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    abstract class Flower
    {
        public string Model { get; set; }
        public bool IsAlive { get; set; }
        public Coordinate FlowerPos { get; set; }

        public Flower()
        {
            FlowerPos = new Coordinate();
            SetFlowerPosition();
            IsAlive = true;
        }
        public Flower(int flowerPosX, int flowerPosY)
        {
            FlowerPos = new Coordinate();
            FlowerPos.X = flowerPosX;
            FlowerPos.Y = flowerPosY;
            IsAlive = true;
        }


        public abstract Flower CreateNew(int posX, int posY);

        public void TryToReproduce()
        {
            if(RandomNumber.GenerateNumber(0,5) == 3)
            {
                Reproduction();
            }
        }

        private void Reproduction()
        {
            bool itsDone = false;
            List<Coordinate> coordinateList = new List<Coordinate>();
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    if (SlotController.Instance.IsSlotEmpty(FlowerPos.X + i, FlowerPos.Y + j))
                    {
                        MakeReproduction(FlowerPos.X + i, FlowerPos.Y + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X - i, FlowerPos.Y + j))
                    {
                        MakeReproduction(FlowerPos.X - i, FlowerPos.Y + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X - i, FlowerPos.Y - j))
                    {
                        MakeReproduction(FlowerPos.X - i, FlowerPos.Y - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X + i, FlowerPos.Y - j))
                    {
                        MakeReproduction(FlowerPos.X + i, FlowerPos.Y - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X + i, FlowerPos.Y + j))
                    {
                        MakeReproduction(FlowerPos.X + i, FlowerPos.Y + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X - i, FlowerPos.Y + j))
                    {
                        MakeReproduction(FlowerPos.X - i, FlowerPos.Y + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X - i, FlowerPos.Y - j))
                    {
                        MakeReproduction(FlowerPos.X - i, FlowerPos.Y - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(FlowerPos.X + i, FlowerPos.Y - j))
                    {
                        MakeReproduction(FlowerPos.X + i, FlowerPos.Y - j);
                        return;
                    }
                }
            }
           
        }

        private void MakeReproduction(int posX, int posY)
        {
            var flower = CreateNew(posX, posY);

            Slot slot = SlotController.Instance.Slots.First(x => x.Coordinate.X == flower.FlowerPos.X && x.Coordinate.Y == flower.FlowerPos.Y);
            slot.SetFlowerSlot(flower.FlowerPos.X, flower.FlowerPos.Y, flower);
        }

        private Slot FindEmptySlot()
        {
            bool done = false;
            Slot slot;
            do
            {
                int index = RandomNumber.GenerateNumber(0, SlotController.Instance.Slots.Count);
                slot = SlotController.Instance.Slots[index];

                if (slot.IsEmpty)
                {
                    done = true;
                }

            } while (!done);

            return slot;
        }

        private void SetFlowerPosition()
        {
            Slot slot = FindEmptySlot();

            FlowerPos.X = slot.Coordinate.X;
            FlowerPos.Y = slot.Coordinate.Y;

            slot.SetFlowerSlot(FlowerPos.X, FlowerPos.Y, this);
        }

    }
}
