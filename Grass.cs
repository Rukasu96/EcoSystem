using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Grass : Flower
    {

        public Grass() : base()
        {
            Model = "J";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
            FlowersManager.Instance.AddFlower(this);
        }

        public Grass(int flowerPosX, int flowerPosY) : base(flowerPosX,flowerPosY)
        {
            Model = "J";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
            FlowersManager.Instance.AddFlower(this);
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Grass grass = new Grass(posX,posY);
            return grass;
        }

        
    }
}
