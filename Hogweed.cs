using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Hogweed : Flower
    {
        public Hogweed() : base()
        {
            Model = "D";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
            FlowersManager.Instance.AddFlower(this);
        }
        public Hogweed(int flowerPosX, int flowerPosY) : base(flowerPosX, flowerPosY)
        {
            Model = "D";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
            FlowersManager.Instance.AddFlower(this);
        }

        public void HogweedSkill()
        {
            if (RandomNumber.GenerateNumber(0, 3) == 1)
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if(SlotController.Instance.ReturnAnimal(FlowerPos.X + i, FlowerPos.Y + j) != null)
                        {
                            Animal animal = SlotController.Instance.ReturnAnimal(FlowerPos.X + i, FlowerPos.Y + j);
                            KillAnimal(animal);
                        }
                        else if (SlotController.Instance.ReturnAnimal(FlowerPos.X - i, FlowerPos.Y + j) != null)
                        {
                            Animal animal = SlotController.Instance.ReturnAnimal(FlowerPos.X - i, FlowerPos.Y + j);
                            KillAnimal(animal);
                        }
                        else if (SlotController.Instance.ReturnAnimal(FlowerPos.X - i, FlowerPos.Y - j) != null)
                        {
                            Animal animal = SlotController.Instance.ReturnAnimal(FlowerPos.X - i, FlowerPos.Y - j);
                            KillAnimal(animal);
                        }
                        else if (SlotController.Instance.ReturnAnimal(FlowerPos.X + i, FlowerPos.Y - j) != null)
                        {
                            Animal animal = SlotController.Instance.ReturnAnimal(FlowerPos.X + i, FlowerPos.Y - j);
                            KillAnimal(animal);
                        }

                    }
                }
            }
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Hogweed hogweed = new Hogweed(posX, posY);
            return hogweed;
        }
        private void KillAnimal(Animal animal)
        {
            if (animal.Model != "C")
            {
                animal.Death(animal);
            }
        }
    }
}
