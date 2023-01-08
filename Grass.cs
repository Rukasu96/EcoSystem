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
            Model = "G";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }

        public Grass(int flowerPosX, int flowerPosY) : base(flowerPosX,flowerPosY)
        {
            Model = "G";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Grass grass = new Grass(posX,posY);
            return grass;
        }

        
    }
}
