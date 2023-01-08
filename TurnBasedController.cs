using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class TurnBasedController
    {

        public TurnBasedController()
        {
        }

        public void StartTurn(List<Animal> animals, List<Flower> flowers)
        {
            var animalGroup = animals.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Age).ToList();
            animalGroup.ForEach(x => x.Move());

            flowers.ForEach(x => x.TryToReproduce());
        }
        




    }
}
