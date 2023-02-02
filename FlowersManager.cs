using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class FlowersManager
    {
        public List<Flower> Flowers = new List<Flower>();

        private static FlowersManager instance = new FlowersManager();
        public static FlowersManager Instance
        {
            get { return instance; }
        }

        public void AddFlower(Flower flower)
        {
            Flowers.Add(flower);
        }

        public void RemoveFlower(Flower flower)
        {
            Flowers.Remove(flower);
            flower.IsAlive = false;
            flower = null;
        }
    }
}
