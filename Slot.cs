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
        public Coordinate Coordinate { get; set; }
        public bool IsEmpty;


        public Slot(int posX, int posY)
        {
            symbol = "X";
            Coordinate = new Coordinate(posX, posY);
            IsEmpty = true;
        }

        public void SetEmptySlot(int posX, int posY)
        {
            IsEmpty = true;
            Coordinate.X = posX;
            Coordinate.Y = posY;
            this.animal = null;

            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(symbol);
        }

        public void SetSlotOccupied(int posX, int posY, Animal animal)
        {
            if(IsEmpty == false)
            {
                this.animal = this.animal.Fight(animal);
            }
            else
            {
                IsEmpty = false;
                this.animal = animal;

            }

            Coordinate.X = posX;
            Coordinate.Y = posY;


        }
        
    }
}
