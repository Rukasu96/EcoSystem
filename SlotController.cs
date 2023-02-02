using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class SlotController
    {
        public List<Slot> Slots = new List<Slot>();

        private static SlotController instance = new SlotController();
        public static SlotController Instance
        {
            get { return instance; }
        }

        public void AddSlot(int posX, int posY)
        {
            Slot slot = new Slot(posX, posY);
            Slots.Add(slot);
        }

        public void ChangeSlotEmpty(int posX, int posY)
        {
            var slotToChange = Slots.FirstOrDefault(x => x.Coordinate.X == posX && x.Coordinate.Y == posY);
            if (slotToChange != null)
            {
                slotToChange.SetEmptySlot(posX, posY);
            }
        }
        public void ChangeSlotOccupied(int posX, int posY, Animal animal)
        {
            var slotToChange = Slots.FirstOrDefault(x => x.Coordinate.X == posX && x.Coordinate.Y == posY);
            if (slotToChange != null)
            {
                slotToChange.SetSlotOccupied(posX, posY, animal);
            }
        }
        public Animal ReturnAnimal(int posX, int posY)
        {
            Slot slot = Slots.FirstOrDefault(x => x.Coordinate.X == posX && x.Coordinate.Y == posY);
            
            if (slot == null)
            {
                return null;
            }

            return slot.Animal;
        }

        public bool IsSlot(int posX, int posY)
        {
            Slot slot = Slots.FirstOrDefault(x => x.Coordinate.X == posX && x.Coordinate.Y == posY);

            if (slot == null)
            {
                return false;
            }

            return true;
        }

        public bool IsSlotEmpty(int posX, int posY)
        {
            Slot slot = Slots.FirstOrDefault(x => x.Coordinate.X == posX && x.Coordinate.Y == posY);

            if (slot == null)
            {
                return false;
            }

            return slot.IsEmpty;

        }

    }
}
