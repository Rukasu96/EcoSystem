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

        public override Flower CreateNew(int posX, int posY)
        {
            Hogweed hogweed = new Hogweed(posX, posY);
            return hogweed;
        }
    }
}
