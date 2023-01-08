using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    abstract class Flower
    {
        public string Model { get; set; }
        public bool IsAlive;
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
            if(RandomNumber.GenerateNumber(0,4) == 3)
            {
                Reproduction();
            }
        }

        private void Reproduction()
        {
            bool itsDone = false;
            List<Coordinate> coordinateList = new List<Coordinate>();

            while (itsDone == false)
            {
                int randX = RandomNumber.GenerateNumber(0, 2);
                int randY = RandomNumber.GenerateNumber(0, 2);

                if (RandomNumber.GenerateNumber(0, 2) == 0)
                {
                    randX *= -1;
                }

                if (RandomNumber.GenerateNumber(0, 2) == 0)
                {
                    randY *= -1;
                }

                Coordinate coordinate = new Coordinate(randX, randY);
                coordinateList.Add(coordinate);

                if (!coordinateList.Contains(coordinate))
                {
                    coordinateList.Add(coordinate);
                }

                if (SlotController.Instance.IsSlotEmpty(FlowerPos.X + randX, FlowerPos.Y + randY))
                {
                    var flower = CreateNew(FlowerPos.X + randX, FlowerPos.Y + randY);
                    itsDone = true;
                }
            }

            if (coordinateList.Count == 8)
            {
                coordinateList.Clear();
                itsDone = true;
            }
        }

        private Slot FindEmptySlot()
        {
            bool done = false;
            Slot slot;
            do
            {
                int index = RandomNumber.GenerateNumber(0, SlotController.Instance.slots.Count);
                slot = SlotController.Instance.slots[index];

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
