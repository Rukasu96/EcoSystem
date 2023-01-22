using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Guarana : Flower
    {
        public Guarana() : base()
        {
            Model = "G";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }
        public Guarana(int flowerPosX, int flowerPosY) : base(flowerPosX, flowerPosY)
        {
            Model = "G";
            Console.SetCursorPosition(FlowerPos.X, FlowerPos.Y);
            Console.WriteLine(Model);
        }

        public override Flower CreateNew(int posX, int posY)
        {
            Guarana guarana = new Guarana(posX, posY);
            return guarana;
        }
    }
}
