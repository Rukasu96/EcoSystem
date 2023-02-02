using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class AnimalsManager
    {
        public List<Animal> animals = new List<Animal>();

        private static AnimalsManager instance = new AnimalsManager();
        public static AnimalsManager Instance
        {
            get { return instance; }
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
            animal.IsAlive = false;
            animal = null;
        }
    }
}
