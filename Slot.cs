using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{

    internal class Slot
    {
        private string symbol;
        private Animal animal;
        private Flower flower;
        public Animal Animal
        {
            get { return animal; }
        }
        public Coordinate Coordinate { get; set; }
        public bool IsEmpty;


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
            Coordinate.X = posX;
            Coordinate.Y = posY;
            animal = null;
            flower = null;

            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(symbol);
        }

        public void SetSlotOccupied(int posX, int posY, Animal animal)
        {
            /*if(this.animal != null)
            {
                MakeFight(animal);
            }*/
           
            if (this.flower != null)
            {
                if(this.flower.Model == "G")
                {
                    animal.Power += 3;
                }else if(this.flower.Model == "B")
                {
                    AnimalsManager.Instance.RemoveAnimal(animal);
                }

                RemoveFlowerFromSlot();
            }

            IsEmpty = false;
            this.animal = animal;

            Coordinate.X = posX;
            Coordinate.Y = posY;
        }

        
        public void SetFlowerSlot(int posX, int posY, Flower flower)
        {
            IsEmpty = false;
            this.flower = flower;

            Coordinate.X = posX;
            Coordinate.Y = posY;
        }
        public void RemoveFlowerFromSlot()
        {
            FlowersManager.Instance.RemoveFlower(this.flower);
            this.flower = null;
        }

        public bool IsTheSameModel(Animal animal)
        {
            if (this.animal == null)
            {
                return false;
            }

            if (this.animal.Model == animal.Model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlowerNull()
        {
            return this.flower == null;
        }

       /* private void MakeFight(Animal animal)
        {
            if (IsEmpty == false && this.animal.Model != animal.Model)
            {
                this.animal = this.animal.Fight(animal);
            }
        }*/

    }
}
