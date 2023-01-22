using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Belladonna : Flower
    {
        public Belladonna() : base()
        {
            Model = "B";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }
        public Belladonna(int flowerPosX, int flowerPosY) : base(flowerPosX, flowerPosY)
        {
            Model = "B";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Belladonna belladonna = new Belladonna(posX, posY);
            return belladonna;
        }
    }
}
