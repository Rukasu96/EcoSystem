using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{

    internal class Slot
    {
        public Coordinate Coordinate { get; set; }
        public bool IsEmpty { get; set; }

        private string symbol;
        private Animal animal;
        private Flower flower;

        public Animal Animal
        {
            get { return animal; }
        }

        public Slot(int posX, int posY)
        {
            symbol = "X";
            Coordinate = new Coordinate(posX, posY);
            IsEmpty = true;
            animal = null;
        }

        public void SetEmptySlot(int posX, int posY)
        {
            IsEmpty = true;
            SetCoordinates(posX, posY);
            animal = null;
            flower = null;

            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(symbol);
        }

        public void SetSlotOccupied(int posX, int posY, Animal animal)
        {
            if (this.flower != null)
            {
                if(this.flower.Model == "G")
                {
                    animal.Power += 3;
                }else if(this.flower.Model == "D")
                {
                    if (animal.Model != "C")
                    {
                        RemoveFlowerFromSlot();
                        animal.Death(animal);
                        SetCoordinates(posX, posY);
                        return;
                    }
                }else if(this.flower.Model == "B")
                {
                    RemoveFlowerFromSlot();
                    animal.Death(animal);
                    SetCoordinates(posX, posY);
                    return;
                }

                RemoveFlowerFromSlot();
                SetCoordinates(posX, posY);
            }

            IsEmpty = false;
            this.animal = animal;

            SetCoordinates(posX, posY);

        }

        
        public void SetFlowerSlot(int posX, int posY, Flower flower)
        {
            IsEmpty = false;
            this.flower = flower;

            SetCoordinates(posX, posY);
        }
        public void SetAnimalSlot(int posX, int posY, Animal animal)
        {
            IsEmpty = false;
            this.animal = animal;

            SetCoordinates(posX, posY);
        }

        public void RemoveFlowerFromSlot()
        {
            FlowersManager.Instance.RemoveFlower(this.flower);
            this.flower = null;
        }

        private void SetCoordinates(int posX,int posY)
        {
            Coordinate.X = posX;
            Coordinate.Y = posY;
        }

    }
}
