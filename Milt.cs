using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Milt : Flower
    {
        public Milt() : base()
        {
            Model = "M";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }
        public Milt(int flowerPosX, int flowerPosY) : base(flowerPosX, flowerPosY)
        {
            Model = "M";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Milt milt = new Milt(posX, posY);
            return milt;
        }
    }
}
